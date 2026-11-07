using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WumxLabs.NoxAeApi.Http;
using WumxLabs.NoxAeApi.Models;

namespace WumxLabs.NoxAeApi.Modules
{
    public class IdentityModule
    {
        private readonly ApiClient _http;
        public IdentityModule(ApiClient http) => _http = http;

        public Task<IdentityResolveResult?> ResolveAsync(string name, CancellationToken ct = default)
            => _http.GetAsync<IdentityResolveResult>("/identity/resolve", new Dictionary<string, string> { ["name"] = name }, ct);

        public Task<List<string>?> GetNetworkServersAsync(CancellationToken ct = default)
            => _http.GetAsync<List<string>>("/identity/network/servers", null, ct);

        public Task<object?> GetNetworkPlayerAsync(string uuid, CancellationToken ct = default)
            => _http.GetAsync<object>($"/identity/network/players/{uuid}", null, ct);
    }
}
