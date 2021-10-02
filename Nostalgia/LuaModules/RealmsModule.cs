using Nostalgia.Proxies;

namespace Nostalgia.LuaModules
{
    internal class RealmsModule
    {
        private readonly Host host;

        public RealmsModule(Host host)
        {
            this.host = host;
        }

        public void Init(ILuaRuntime runtime)
        {
            runtime.Globals["CLIENT"] = host.IsClient;
            runtime.Globals["SERVER"] = host.IsServer;
        }
    }
}
