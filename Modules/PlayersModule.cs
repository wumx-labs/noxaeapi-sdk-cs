using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WumxLabs.NoxAeApi.Http;
using WumxLabs.NoxAeApi.Models;

namespace WumxLabs.NoxAeApi.Modules
{
    public class PlayersModule
    {
        private readonly ApiClient _http;
        public PlayersModule(ApiClient http) => _http = http;

        public Task<List<OnlinePlayer>?> GetOnlineAsync(CancellationToken ct = default)
            => _http.GetAsync<List<OnlinePlayer>>("/players", null, ct);

        public Task<OnlinePlayer?> GetAsync(string uuid, CancellationToken ct = default)
            => _http.GetAsync<OnlinePlayer>($"/players/{uuid}", null, ct);

        public Task<OfflinePlayer?> GetOfflineAsync(string uuid, CancellationToken ct = default)
            => _http.GetAsync<OfflinePlayer>($"/players/{uuid}/offline", null, ct);

        public Task<object?> GetInventoryAsync(string uuid, CancellationToken ct = default)
            => _http.GetAsync<object>($"/players/{uuid}/inventory", null, ct);

        public Task<object?> GetEnderChestAsync(string uuid, CancellationToken ct = default)
            => _http.GetAsync<object>($"/players/{uuid}/enderchest", null, ct);

        public Task<object?> GetStatsAsync(string uuid, CancellationToken ct = default)
            => _http.GetAsync<object>($"/players/{uuid}/stats", null, ct);

        public Task<object?> KickAsync(string uuid, string reason = "Kicked by operator", CancellationToken ct = default)
            => _http.PostAsync<object>($"/players/{uuid}/kick", new { reason }, null, ct);

        public Task<object?> BanAsync(string uuid, string reason = "Banned", string? expires = null, CancellationToken ct = default)
            => _http.PostAsync<object>($"/players/{uuid}/ban", new { reason, expires }, null, ct);

        public Task<object?> UnbanAsync(string uuid, CancellationToken ct = default)
            => _http.PostAsync<object>($"/players/{uuid}/unban", null, null, ct);

        public Task<object?> SetWhitelistAsync(string uuid, bool whitelisted, CancellationToken ct = default)
            => _http.PostAsync<object>($"/players/{uuid}/whitelist", new { whitelisted }, null, ct);

        public Task<object?> TeleportAsync(string uuid, double x, double y, double z, string? world = null, CancellationToken ct = default)
            => _http.PostAsync<object>($"/players/{uuid}/teleport", new { x, y, z, world }, null, ct);

        public Task<object?> SendMessageAsync(string uuid, string message, CancellationToken ct = default)
            => _http.PostAsync<object>($"/players/{uuid}/message", new { message }, null, ct);

        public Task<object?> SetHealthAsync(string uuid, double health, CancellationToken ct = default)
            => _http.PostAsync<object>($"/players/{uuid}/health", new { health }, null, ct);

        public Task<object?> SetFoodAsync(string uuid, int food, double saturation = 5.0, CancellationToken ct = default)
            => _http.PostAsync<object>($"/players/{uuid}/food", new { food, saturation }, null, ct);

        public Task<object?> SetOpAsync(string uuid, bool op, CancellationToken ct = default)
            => _http.PostAsync<object>($"/players/{uuid}/op", new { op }, null, ct);

        public Task<object?> SetGamemodeAsync(string uuid, string gamemode, CancellationToken ct = default)
            => _http.PostAsync<object>($"/players/{uuid}/gamemode", new { gamemode }, null, ct);
    }
}
