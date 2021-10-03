using Nostalgia.LuaModules;
using Nostalgia.Proxies;

namespace Nostalgia
{
    /// <summary>
    /// Nostalgia composition root and entry point.
    /// </summary>
    internal static class Nostalgia
    {
        /// <summary>
        /// Initializes Nostalgia internal dependencies, then discovers addons and runs their autorun code.
        /// </summary>
        public static void Start()
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
