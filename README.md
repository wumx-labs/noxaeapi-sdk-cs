# NoxAeApi C# / .NET SDK

Official .NET SDK for the NoxAeApi Minecraft REST API suite and Velocity Network Hub.

## Features

- Targets `.NET Standard 2.0` and `.NET 8.0`
- Full async/await API pattern using `System.Net.Http` and `System.Text.Json`
- Complete module coverage:
  - Players, Server, Economy, Leaderboards, LuckPerms, NoxAuth
  - Plugins, Worlds, Skills, Identity, Integrations (RankForge, etc.), Misc
- Velocity Hub Node routing support via `client.HubNode("server-1")`

## Installation

```bash
dotnet add package WumxLabs.NoxAeApi
```

## Quick Start

```csharp
using System;
using System.Threading.Tasks;
using WumxLabs.NoxAeApi;

var client = new NoxAeApiClient("your-api-key", "http://localhost:8080");

// Get online players
var players = await client.Players.GetOnlineAsync();
foreach (var p in players)
{
    Console.WriteLine($"Player: {p.DisplayName} ({p.Uuid})");
}

// Forward request to specific backend via Velocity Hub
var hubNode = client.HubNode("survival-1");
var serverInfo = await hubNode.Server.GetInfoAsync();
Console.WriteLine($"Server TPS: {serverInfo?.Tps}");
```

## License

MIT © Wumx Labs & NoxAeApi Contributors
