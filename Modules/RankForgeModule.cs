using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WumxLabs.NoxAeApi.Http;
using WumxLabs.NoxAeApi.Models;

namespace WumxLabs.NoxAeApi.Modules
{
    public class RankForgeModule
    {
        private readonly ApiClient _http;
        public RankForgeModule(ApiClient http) => _http = http;

        public Task<RankForgePlayerStats?> GetPlayerStatsAsync(string uuid, CancellationToken ct = default)
            => _http.GetAsync<RankForgePlayerStats>($"/integrations/rankforge/players/{uuid}", null, ct);

        public Task<int> GetPointsAsync(string uuid, CancellationToken ct = default)
            => _http.GetAsync<int>($"/integrations/rankforge/players/{uuid}/points", null, ct);

        public Task<object?> SetPointsAsync(string uuid, int points, CancellationToken ct = default)
            => _http.PostAsync<object>($"/integrations/rankforge/players/{uuid}/points", new { points }, null, ct);

        public Task<object?> AddPointsAsync(string uuid, int points, CancellationToken ct = default)
            => _http.PostAsync<object>($"/integrations/rankforge/players/{uuid}/points/add", new { points }, null, ct);

        public Task<object?> RemovePointsAsync(string uuid, int points, CancellationToken ct = default)
            => _http.PostAsync<object>($"/integrations/rankforge/players/{uuid}/points/remove", new { points }, null, ct);

        public Task<List<string>?> GetTiersAsync(CancellationToken ct = default)
            => _http.GetAsync<List<string>>("/integrations/rankforge/tiers", null, ct);

        public Task<List<RankForgeTopEntry>?> GetTopAsync(int limit = 10, int offset = 0, CancellationToken ct = default)
            => _http.GetAsync<List<RankForgeTopEntry>>("/integrations/rankforge/top", new Dictionary<string, string> { ["limit"] = limit.ToString(), ["offset"] = offset.ToString() }, ct);

        public Task<object?> SaveAsync(CancellationToken ct = default)
            => _http.PostAsync<object>("/integrations/rankforge/save", null, null, ct);
    }
}
