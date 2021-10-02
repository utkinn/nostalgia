using Nostalgia.Core.Proxies;

namespace Nostalgia.Core.LuaModules
{
    internal class RootModule : ILuaModule
    {
        private readonly Host host;

        public RootModule(Host host)
        {
            this.host = host;
        }

        public void Init(ILuaRuntime runtime)
        {
            new RealmsModule(host).Init(runtime);
        }
    }
}
