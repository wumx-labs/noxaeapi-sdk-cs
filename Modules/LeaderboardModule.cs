using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WumxLabs.NoxAeApi.Http;

namespace WumxLabs.NoxAeApi.Modules
{
    public class LeaderboardModule
    {
        private readonly ApiClient _http;
        public LeaderboardModule(ApiClient http) => _http = http;

        public Task<List<object>?> GetSourcesAsync(CancellationToken ct = default)
            => _http.GetAsync<List<object>>("/leaderboard/sources", null, ct);

        public Task<List<object>?> GetAsync(string source, int limit = 10, int offset = 0, CancellationToken ct = default)
            => _http.GetAsync<List<object>>($"/leaderboard/{source}", new Dictionary<string, string> { ["limit"] = limit.ToString(), ["offset"] = offset.ToString() }, ct);
    }
}
