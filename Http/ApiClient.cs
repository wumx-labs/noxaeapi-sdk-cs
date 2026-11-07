using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WumxLabs.NoxAeApi.Exceptions;

namespace WumxLabs.NoxAeApi.Http
{
    public class ApiClient
    {
        private readonly HttpClient _http;
        private readonly string _baseUrl;
        private readonly string _apiKey;
        private readonly Dictionary<string, string> _customHeaders;

        public ApiClient(string apiKey, string baseUrl = "http://localhost:8080", HttpClient? httpClient = null, Dictionary<string, string>? customHeaders = null)
        {
            _apiKey = apiKey;
            _baseUrl = baseUrl.TrimEnd('/');
            _http = httpClient ?? new HttpClient();
            _customHeaders = customHeaders ?? new Dictionary<string, string>();
        }

        public ApiClient WithHeader(string name, string value)
        {
            var headers = new Dictionary<string, string>(_customHeaders)
            {
                [name] = value
            };
            return new ApiClient(_apiKey, _baseUrl, _http, headers);
        }

        public async Task<T?> SendAsync<T>(HttpMethod method, string path, object? body = null, Dictionary<string, string>? query = null, CancellationToken ct = default)
        {
            var url = $"{_baseUrl}/{path.TrimStart('/')}";
            if (query != null && query.Count > 0)
            {
                var sb = new StringBuilder();
                foreach (var kvp in query)
                {
                    if (sb.Length > 0) sb.Append('&');
                    sb.Append(Uri.EscapeDataString(kvp.Key)).Append('=').Append(Uri.EscapeDataString(kvp.Value));
                }
                url += $"?{sb}";
            }

            using var req = new HttpRequestMessage(method, url);
            req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            req.Headers.Add("X-API-Key", _apiKey);

            foreach (var kvp in _customHeaders)
            {
                req.Headers.TryAddWithoutValidation(kvp.Key, kvp.Value);
            }

            if (body != null)
            {
                var json = JsonSerializer.Serialize(body);
                req.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            using var resp = await _http.SendAsync(req, ct).ConfigureAwait(false);
            var content = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!resp.IsSuccessStatusCode)
            {
                if (resp.StatusCode == System.Net.HttpStatusCode.Unauthorized || resp.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    throw new AuthenticationException($"Authentication failed: {resp.StatusCode}", resp.StatusCode, content);
                if (resp.StatusCode == System.Net.HttpStatusCode.NotFound)
                    throw new NotFoundException($"Resource not found: {resp.StatusCode}", resp.StatusCode, content);

                throw new NoxAeApiException($"HTTP Request failed with status {resp.StatusCode}", resp.StatusCode, content);
            }

            if (string.IsNullOrWhiteSpace(content)) return default;

            if (typeof(T) == typeof(string)) return (T)(object)content;

            return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public Task<T?> GetAsync<T>(string path, Dictionary<string, string>? query = null, CancellationToken ct = default)
            => SendAsync<T>(HttpMethod.Get, path, null, query, ct);

        public Task<T?> PostAsync<T>(string path, object? body = null, Dictionary<string, string>? query = null, CancellationToken ct = default)
            => SendAsync<T>(HttpMethod.Post, path, body, query, ct);

        public Task<T?> PutAsync<T>(string path, object? body = null, Dictionary<string, string>? query = null, CancellationToken ct = default)
            => SendAsync<T>(HttpMethod.Put, path, body, query, ct);

        public Task<T?> DeleteAsync<T>(string path, Dictionary<string, string>? query = null, CancellationToken ct = default)
            => SendAsync<T>(HttpMethod.Delete, path, null, query, ct);
    }
}
