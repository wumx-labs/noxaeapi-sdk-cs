using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WumxLabs.NoxAeApi.Http;

namespace WumxLabs.NoxAeApi.Modules
{
    public class SkillsModule
    {
        private readonly ApiClient _http;
        public SkillsModule(ApiClient http) => _http = http;

        public Task<Dictionary<string, object>?> GetPlayerSkillsAsync(string uuid, CancellationToken ct = default)
            => _http.GetAsync<Dictionary<string, object>>($"/skills/players/{uuid}", null, ct);

        public Task<object?> AddExpAsync(string uuid, string skill, double exp, CancellationToken ct = default)
            => _http.PostAsync<object>($"/skills/players/{uuid}/{skill}/add-exp", new { exp }, null, ct);

        public Task<object?> SetLevelAsync(string uuid, string skill, int level, CancellationToken ct = default)
            => _http.PostAsync<object>($"/skills/players/{uuid}/{skill}/set-level", new { level }, null, ct);
    }
}
