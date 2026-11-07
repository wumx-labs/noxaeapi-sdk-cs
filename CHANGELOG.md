# Changelog

All notable changes to the `noxaeapi-sdk-cs` will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.7.3] - 2026-11-07

### Added
- Official documentation link (`https://noxapi.noxlydev.xyz`) across package metadata and `README.md`.
- Updated `PackageProjectUrl` to `https://noxapi.noxlydev.xyz`.

## [0.7.2] - 2026-11-07

### Changed
- Cleaned up documentation links to avoid internal monorepo references.

## [0.7.1] - 2026-11-07

### Added
- Embedded `README.md` documentation into NuGet package metadata (`<PackageReadmeFile>`).
- Updated repository and project URLs to `https://github.com/wumx-labs/noxaeapi-sdk-cs`.

## [0.7.0] - 2026-11-07

### Added
- Initial official release of the C# / .NET SDK for NoxAeApi ecosystem.
- Targets `netstandard2.0` and `net8.0` with full async/await and nullable annotations.
- Complete support for all NoxAeApi core modules:
  - `Players`: Online/offline players, inventories, ender chests, health/food, teleportation, kicks, bans, whitelist.
  - `Server`: Health metrics, TPS, commands, broadcasts, server properties.
  - `Economy`: Vault economy, multi-currency support, top balances.
  - `Leaderboard`: Multiple leaderboard sources and rankings.
  - `LuckPerms`: Full LuckPerms permissions, groups, nodes management.
  - `NoxAuth`: In-game authentication, registration, password verification.
  - `Plugins`: Plugin state query, enable, disable.
  - `Worlds`: World management, weather, time, gamerules.
  - `Skills`: Player skill levels, experience, power levels.
  - `Identity`: Velocity cross-server identity resolution and server listing.
  - `RankForge`: PvP stats, seasonal tiers, points, top rankings.
  - `Integrations`: Direct access to 16+ supported Spigot/Paper plugins.
  - `Misc`: Ping, health check, runtime status.
- Velocity network node client via `client.HubNode(nodeId)`.
