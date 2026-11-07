using System.Threading;
using System.Threading.Tasks;
using WumxLabs.NoxAeApi.Http;
using WumxLabs.NoxAeApi.Models;

namespace WumxLabs.NoxAeApi.Modules
{
    public class NoxAuthModule
    {
        private readonly ApiClient _http;
        public NoxAuthModule(ApiClient http) => _http = http;

        public Task<NoxAuthPlayerInfo?> GetPlayerAsync(string uuid, CancellationToken ct = default)
            => _http.GetAsync<NoxAuthPlayerInfo>($"/noxauth/players/{uuid}", null, ct);

        public Task<bool> CheckPasswordAsync(string name, string password, CancellationToken ct = default)
            => _http.PostAsync<bool>("/noxauth/check-password", new { name, password }, null, ct);

        public Task<object?> SetPasswordAsync(string uuid, string password, CancellationToken ct = default)
            => _http.PostAsync<object>($"/noxauth/players/{uuid}/password", new { password }, null, ct);

        public Task<object?> RegisterAsync(string name, string password, string? email = null, CancellationToken ct = default)
            => _http.PostAsync<object>("/noxauth/register", new { name, password, email }, null, ct);

        public Task<object?> UnregisterAsync(string uuid, CancellationToken ct = default)
            => _http.DeleteAsync<object>($"/noxauth/players/{uuid}", null, ct);
    }
}
