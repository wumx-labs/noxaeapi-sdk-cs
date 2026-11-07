using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WumxLabs.NoxAeApi.Http;
using WumxLabs.NoxAeApi.Models;

namespace WumxLabs.NoxAeApi.Modules
{
    public class PluginsModule
    {
        private readonly ApiClient _http;
        public PluginsModule(ApiClient http) => _http = http;

        public Task<List<PluginInfo>?> GetAllAsync(CancellationToken ct = default)
            => _http.GetAsync<List<PluginInfo>>("/plugins", null, ct);

        public Task<PluginInfo?> GetAsync(string name, CancellationToken ct = default)
            => _http.GetAsync<PluginInfo>($"/plugins/{name}", null, ct);

        public Task<object?> EnableAsync(string name, CancellationToken ct = default)
            => _http.PostAsync<object>($"/plugins/{name}/enable", null, null, ct);

        public Task<object?> DisableAsync(string name, CancellationToken ct = default)
            => _http.PostAsync<object>($"/plugins/{name}/disable", null, null, ct);
    }
}
