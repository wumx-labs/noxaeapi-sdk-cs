using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WumxLabs.NoxAeApi.Http;

namespace WumxLabs.NoxAeApi.Modules
{
    public class IntegrationsModule
    {
        private readonly ApiClient _http;
        public RankForgeModule RankForge { get; }

        public IntegrationsModule(ApiClient http)
        {
            _http = http;
            RankForge = new RankForgeModule(http);
        }

        public Task<T?> GetAsync<T>(string plugin, string endpoint, Dictionary<string, string>? query = null, CancellationToken ct = default)
            => _http.GetAsync<T>($"/integrations/{plugin}/{endpoint.TrimStart('/')}", query, ct);

        public Task<T?> PostAsync<T>(string plugin, string endpoint, object? body = null, Dictionary<string, string>? query = null, CancellationToken ct = default)
            => _http.PostAsync<T>($"/integrations/{plugin}/{endpoint.TrimStart('/')}", body, query, ct);
    }
}
