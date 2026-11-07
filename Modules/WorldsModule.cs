using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WumxLabs.NoxAeApi.Http;
using WumxLabs.NoxAeApi.Models;

namespace WumxLabs.NoxAeApi.Modules
{
    public class WorldsModule
    {
        private readonly ApiClient _http;
        public WorldsModule(ApiClient http) => _http = http;

        public Task<List<WorldInfo>?> GetAllAsync(CancellationToken ct = default)
            => _http.GetAsync<List<WorldInfo>>("/worlds", null, ct);

        public Task<WorldInfo?> GetAsync(string name, CancellationToken ct = default)
            => _http.GetAsync<WorldInfo>($"/worlds/{name}", null, ct);

        public Task<object?> SaveAsync(string name, CancellationToken ct = default)
            => _http.PostAsync<object>($"/worlds/{name}/save", null, null, ct);

        public Task<object?> SetTimeAsync(string name, long time, CancellationToken ct = default)
            => _http.PostAsync<object>($"/worlds/{name}/time", new { time }, null, ct);

        public Task<object?> SetWeatherAsync(string name, string weather, int duration = 6000, CancellationToken ct = default)
            => _http.PostAsync<object>($"/worlds/{name}/weather", new { weather, duration }, null, ct);

        public Task<object?> SetDifficultyAsync(string name, string difficulty, CancellationToken ct = default)
            => _http.PostAsync<object>($"/worlds/{name}/difficulty", new { difficulty }, null, ct);
    }
}
