using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WumxLabs.NoxAeApi.Http;

namespace WumxLabs.NoxAeApi.Modules
{
    public class MiscModule
    {
        private readonly ApiClient _http;
        public MiscModule(ApiClient http) => _http = http;

        public Task<object?> PingAsync(CancellationToken ct = default)
            => _http.GetAsync<object>("/ping", null, ct);

        public Task<object?> HealthAsync(CancellationToken ct = default)
            => _http.GetAsync<object>("/health", null, ct);
    }
}
