using Nostalgia.Proxies;

namespace Nostalgia.LuaModules
{
    internal class RootModule
    {
        private readonly Host host;
        private readonly Logger logger;

        public RootModule(Host host, Logger logger)
        {
            this.host = host;
            this.logger = logger;
        }

        public void Init(ILuaRuntime runtime)
        {
            new RealmsModule(host).Init(runtime);
            new ConsoleModule(logger).Init(runtime);
        }
    }
}
