using Nostalgia.Proxies;

namespace Nostalgia.LuaModules
{
    /// <summary>
    /// Root module which loads all other modules.
    /// </summary>
    class RootModule
    {
        private readonly Host host;
        private readonly Logger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="RootModule"/> class.
        /// </summary>
        /// <param name="host"><see cref="Host"/> instance. Some modules require it to add client- or server-side specific symbols.</param>
        /// <param name="logger"><see cref="Logger"/> instance. Required by <see cref="ConsoleModule"/>.</param>
        public RootModule(Host host, Logger logger)
        {
            this.host = host;
            this.logger = logger;
        }

        /// <summary>
        /// Inserts symbols into the Lua global namespace.
        /// </summary>
        /// <param name="runtime">Lua runtime to operate on.</param>
        public void Init(ILuaRuntime runtime)
        {
            new GlobalConstantsModule(host).Init(runtime);
            new ConsoleModule(logger).Init(runtime);
        }
    }
}
