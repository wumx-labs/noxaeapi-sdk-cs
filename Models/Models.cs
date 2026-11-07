using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WumxLabs.NoxAeApi.Models
{
    public class OnlinePlayer
    {
        [JsonPropertyName("uuid")] public string Uuid { get; set; } = string.Empty;
        [JsonPropertyName("displayName")] public string DisplayName { get; set; } = string.Empty;
        [JsonPropertyName("address")] public string? Address { get; set; }
        [JsonPropertyName("port")] public int? Port { get; set; }
        [JsonPropertyName("exhaustion")] public double Exhaustion { get; set; }
        [JsonPropertyName("exp")] public double Exp { get; set; }
        [JsonPropertyName("expLevel")] public long ExpLevel { get; set; }
        [JsonPropertyName("whitelisted")] public bool Whitelisted { get; set; }
        [JsonPropertyName("banned")] public bool Banned { get; set; }
        [JsonPropertyName("op")] public bool Op { get; set; }
        [JsonPropertyName("balance")] public double? Balance { get; set; }
        [JsonPropertyName("location")] public List<double>? Location { get; set; }
        [JsonPropertyName("dimension")] public string? Dimension { get; set; }
        [JsonPropertyName("health")] public double Health { get; set; }
        [JsonPropertyName("hunger")] public long Hunger { get; set; }
        [JsonPropertyName("saturation")] public double Saturation { get; set; }
        [JsonPropertyName("gamemode")] public string Gamemode { get; set; } = string.Empty;
        [JsonPropertyName("lastPlayed")] public long LastPlayed { get; set; }
        [JsonPropertyName("authenticated")] public bool? Authenticated { get; set; }
        [JsonPropertyName("registered")] public bool? Registered { get; set; }
    }

    public class OfflinePlayer
    {
        [JsonPropertyName("uuid")] public string Uuid { get; set; } = string.Empty;
        [JsonPropertyName("displayName")] public string DisplayName { get; set; } = string.Empty;
        [JsonPropertyName("whitelisted")] public bool Whitelisted { get; set; }
        [JsonPropertyName("banned")] public bool Banned { get; set; }
        [JsonPropertyName("op")] public bool Op { get; set; }
        [JsonPropertyName("balance")] public double? Balance { get; set; }
        [JsonPropertyName("lastPlayed")] public long LastPlayed { get; set; }
    }

    public class ServerHealth
    {
        [JsonPropertyName("cpus")] public int Cpus { get; set; }
        [JsonPropertyName("uptime")] public long Uptime { get; set; }
        [JsonPropertyName("totalMemory")] public long TotalMemory { get; set; }
        [JsonPropertyName("maxMemory")] public long MaxMemory { get; set; }
        [JsonPropertyName("freeMemory")] public long FreeMemory { get; set; }
    }

    public class ServerInfo
    {
        [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
        [JsonPropertyName("motd")] public string Motd { get; set; } = string.Empty;
        [JsonPropertyName("version")] public string Version { get; set; } = string.Empty;
        [JsonPropertyName("bukkitVersion")] public string BukkitVersion { get; set; } = string.Empty;
        [JsonPropertyName("tps")] public string Tps { get; set; } = string.Empty;
        [JsonPropertyName("health")] public ServerHealth? Health { get; set; }
        [JsonPropertyName("maxPlayers")] public int MaxPlayers { get; set; }
        [JsonPropertyName("onlinePlayers")] public int OnlinePlayers { get; set; }
    }

    public class EconomyInfo
    {
        [JsonPropertyName("available")] public bool Available { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
        [JsonPropertyName("currencyNameSingular")] public string CurrencyNameSingular { get; set; } = string.Empty;
        [JsonPropertyName("currencyNamePlural")] public string CurrencyNamePlural { get; set; } = string.Empty;
        [JsonPropertyName("fractionalDigits")] public int FractionalDigits { get; set; }
    }

    public class TopBalanceEntry
    {
        [JsonPropertyName("uuid")] public string Uuid { get; set; } = string.Empty;
        [JsonPropertyName("balance")] public double Balance { get; set; }
    }

    public class CurrencyBalance
    {
        [JsonPropertyName("uuid")] public string Uuid { get; set; } = string.Empty;
        [JsonPropertyName("currency")] public string Currency { get; set; } = string.Empty;
        [JsonPropertyName("balance")] public double Balance { get; set; }
    }

    public class CurrencyTopEntry
    {
        [JsonPropertyName("uuid")] public string Uuid { get; set; } = string.Empty;
        [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
        [JsonPropertyName("balance")] public double Balance { get; set; }
    }

    public class RankForgePlayerStats
    {
        [JsonPropertyName("uuid")] public string Uuid { get; set; } = string.Empty;
        [JsonPropertyName("points")] public int Points { get; set; }
        [JsonPropertyName("kills")] public int Kills { get; set; }
        [JsonPropertyName("deaths")] public int Deaths { get; set; }
        [JsonPropertyName("tier")] public string Tier { get; set; } = string.Empty;
    }

    public class RankForgeTopEntry
    {
        [JsonPropertyName("uuid")] public string Uuid { get; set; } = string.Empty;
        [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
        [JsonPropertyName("points")] public int Points { get; set; }
        [JsonPropertyName("tier")] public string Tier { get; set; } = string.Empty;
    }

    public class IdentityResolveResult
    {
        [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
        [JsonPropertyName("uuid")] public string Uuid { get; set; } = string.Empty;
    }

    public class NoxAuthPlayerInfo
    {
        [JsonPropertyName("uuid")] public string Uuid { get; set; } = string.Empty;
        [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
        [JsonPropertyName("registered")] public bool Registered { get; set; }
        [JsonPropertyName("authenticated")] public bool Authenticated { get; set; }
        [JsonPropertyName("lastIp")] public string? LastIp { get; set; }
    }

    public class PluginInfo
    {
        [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
        [JsonPropertyName("version")] public string Version { get; set; } = string.Empty;
        [JsonPropertyName("enabled")] public bool Enabled { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
    }

    public class WorldInfo
    {
        [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
        [JsonPropertyName("uuid")] public string Uuid { get; set; } = string.Empty;
        [JsonPropertyName("time")] public long Time { get; set; }
        [JsonPropertyName("storm")] public bool Storm { get; set; }
        [JsonPropertyName("thundering")] public bool Thundering { get; set; }
        [JsonPropertyName("difficulty")] public string Difficulty { get; set; } = string.Empty;
    }
}
