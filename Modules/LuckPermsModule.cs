using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WumxLabs.NoxAeApi.Http;

namespace WumxLabs.NoxAeApi.Modules
{
    public class LuckPermsModule
    {
        private readonly ApiClient _http;
        public LuckPermsModule(ApiClient http) => _http = http;

        public Task<List<string>?> GetGroupsAsync(CancellationToken ct = default)
            => _http.GetAsync<List<string>>("/luckperms/groups", null, ct);

        public Task<object?> GetGroupAsync(string name, CancellationToken ct = default)
            => _http.GetAsync<object>($"/luckperms/groups/{name}", null, ct);

        public Task<object?> CreateGroupAsync(string name, CancellationToken ct = default)
            => _http.PostAsync<object>("/luckperms/groups", new { name }, null, ct);

        public Task<object?> DeleteGroupAsync(string name, CancellationToken ct = default)
            => _http.DeleteAsync<object>($"/luckperms/groups/{name}", null, ct);

        public Task<List<string>?> GetUserPermissionsAsync(string uuid, CancellationToken ct = default)
            => _http.GetAsync<List<string>>($"/luckperms/users/{uuid}/permissions", null, ct);

        public Task<object?> AddUserPermissionAsync(string uuid, string permission, bool value = true, long expiry = 0, CancellationToken ct = default)
            => _http.PostAsync<object>($"/luckperms/users/{uuid}/permissions", new { permission, value, expiry }, null, ct);

        public Task<object?> RemoveUserPermissionAsync(string uuid, string permission, CancellationToken ct = default)
            => _http.DeleteAsync<object>($"/luckperms/users/{uuid}/permissions", new Dictionary<string, string> { ["permission"] = permission }, ct);

        public Task<List<string>?> GetUserGroupsAsync(string uuid, CancellationToken ct = default)
            => _http.GetAsync<List<string>>($"/luckperms/users/{uuid}/groups", null, ct);

        public Task<object?> AddUserGroupAsync(string uuid, string group, CancellationToken ct = default)
            => _http.PostAsync<object>($"/luckperms/users/{uuid}/groups", new { group }, null, ct);

        public Task<object?> RemoveUserGroupAsync(string uuid, string group, CancellationToken ct = default)
            => _http.DeleteAsync<object>($"/luckperms/users/{uuid}/groups", new Dictionary<string, string> { ["group"] = group }, ct);
    }
}
