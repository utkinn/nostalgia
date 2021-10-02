using Nostalgia.Core.LuaModules;
using Nostalgia.Core.Proxies;

namespace Nostalgia.Core
{
    internal class Nostalgia
    {
        public void Start()
        {
            var host = new Host();
            var logger = new Logger();
            var rootModule = new RootModule(host, logger);
            var runtime = new LuaRuntime();
            rootModule.Init(runtime);
            var fs = new FileSystem();

            var discoverer = new AddonDiscoverer(fs, logger);
            new AddonRunner(fs, runtime, discoverer).RunAll();
        }
    }
}
