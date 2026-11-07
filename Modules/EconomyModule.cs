using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WumxLabs.NoxAeApi.Http;
using WumxLabs.NoxAeApi.Models;

namespace WumxLabs.NoxAeApi.Modules
{
    public class EconomyModule
    {
        private readonly ApiClient _http;
        public EconomyModule(ApiClient http) => _http = http;

        public Task<EconomyInfo?> GetInfoAsync(CancellationToken ct = default)
            => _http.GetAsync<EconomyInfo>("/economy", null, ct);

        public Task<double> GetBalanceAsync(string uuid, CancellationToken ct = default)
            => _http.GetAsync<double>($"/economy/balance/{uuid}", null, ct);

        public Task<object?> SetBalanceAsync(string uuid, double amount, CancellationToken ct = default)
            => _http.PostAsync<object>($"/economy/balance/{uuid}", new { amount }, null, ct);

        public Task<object?> AddBalanceAsync(string uuid, double amount, CancellationToken ct = default)
            => _http.PostAsync<object>($"/economy/balance/{uuid}/add", new { amount }, null, ct);

        public Task<object?> RemoveBalanceAsync(string uuid, double amount, CancellationToken ct = default)
            => _http.PostAsync<object>($"/economy/balance/{uuid}/remove", new { amount }, null, ct);

        public Task<List<TopBalanceEntry>?> GetTopAsync(int limit = 10, int offset = 0, CancellationToken ct = default)
            => _http.GetAsync<List<TopBalanceEntry>>("/economy/top", new Dictionary<string, string> { ["limit"] = limit.ToString(), ["offset"] = offset.ToString() }, ct);

        public Task<CurrencyBalance?> GetCurrencyBalanceAsync(string uuid, string currency, CancellationToken ct = default)
            => _http.GetAsync<CurrencyBalance>($"/economy/{currency}/balance/{uuid}", null, ct);

        public Task<object?> SetCurrencyBalanceAsync(string uuid, string currency, double amount, CancellationToken ct = default)
            => _http.PostAsync<object>($"/economy/{currency}/balance/{uuid}", new { amount }, null, ct);

        public Task<object?> AddCurrencyBalanceAsync(string uuid, string currency, double amount, CancellationToken ct = default)
            => _http.PostAsync<object>($"/economy/{currency}/balance/{uuid}/add", new { amount }, null, ct);

        public Task<object?> RemoveCurrencyBalanceAsync(string uuid, string currency, double amount, CancellationToken ct = default)
            => _http.PostAsync<object>($"/economy/{currency}/balance/{uuid}/remove", new { amount }, null, ct);

        public Task<List<CurrencyTopEntry>?> GetCurrencyTopAsync(string currency, int limit = 10, int offset = 0, CancellationToken ct = default)
            => _http.GetAsync<List<CurrencyTopEntry>>($"/economy/{currency}/top", new Dictionary<string, string> { ["limit"] = limit.ToString(), ["offset"] = offset.ToString() }, ct);
    }
}
