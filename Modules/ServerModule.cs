using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WumxLabs.NoxAeApi.Http;
using WumxLabs.NoxAeApi.Models;

namespace WumxLabs.NoxAeApi.Modules
{
    public class ServerModule
    {
        private readonly ApiClient _http;
        public ServerModule(ApiClient http) => _http = http;

        public Task<ServerInfo?> GetInfoAsync(CancellationToken ct = default)
            => _http.GetAsync<ServerInfo>("/server", null, ct);

        public Task<ServerHealth?> GetHealthAsync(CancellationToken ct = default)
            => _http.GetAsync<ServerHealth>("/server/health", null, ct);

        public Task<string?> GetTpsAsync(CancellationToken ct = default)
            => _http.GetAsync<string>("/server/tps", null, ct);

        public Task<List<PluginInfo>?> GetPluginsAsync(CancellationToken ct = default)
            => _http.GetAsync<List<PluginInfo>>("/server/plugins", null, ct);

        public Task<List<WorldInfo>?> GetWorldsAsync(CancellationToken ct = default)
            => _http.GetAsync<List<WorldInfo>>("/server/worlds", null, ct);

        public Task<object?> ExecuteCommandAsync(string command, CancellationToken ct = default)
            => _http.PostAsync<object>("/server/command", new { command }, null, ct);

        public Task<object?> BroadcastAsync(string message, CancellationToken ct = default)
            => _http.PostAsync<object>("/server/broadcast", new { message }, null, ct);
    }
}
