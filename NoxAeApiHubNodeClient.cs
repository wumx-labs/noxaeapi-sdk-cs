using WumxLabs.NoxAeApi.Http;
using WumxLabs.NoxAeApi.Modules;

namespace WumxLabs.NoxAeApi
{
    public class NoxAeApiHubNodeClient
    {
        private readonly ApiClient _http;
        public string NodeId { get; }

        public PlayersModule Players { get; }
        public ServerModule Server { get; }
        public EconomyModule Economy { get; }
        public LeaderboardModule Leaderboard { get; }
        public LuckPermsModule LuckPerms { get; }
        public NoxAuthModule NoxAuth { get; }
        public PluginsModule Plugins { get; }
        public WorldsModule Worlds { get; }
        public SkillsModule Skills { get; }
        public IdentityModule Identity { get; }
        public IntegrationsModule Integrations { get; }
        public RankForgeModule RankForge { get; }
        public MiscModule Misc { get; }

        public NoxAeApiHubNodeClient(ApiClient http, string nodeId)
        {
            NodeId = nodeId;
            _http = http.WithHeader("X-Velocity-Node", nodeId);

            Players = new PlayersModule(_http);
            Server = new ServerModule(_http);
            Economy = new EconomyModule(_http);
            Leaderboard = new LeaderboardModule(_http);
            LuckPerms = new LuckPermsModule(_http);
            NoxAuth = new NoxAuthModule(_http);
            Plugins = new PluginsModule(_http);
            Worlds = new WorldsModule(_http);
            Skills = new SkillsModule(_http);
            Identity = new IdentityModule(_http);
            Integrations = new IntegrationsModule(_http);
            RankForge = Integrations.RankForge;
            Misc = new MiscModule(_http);
        }
    }
}
