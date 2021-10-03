using Nostalgia.Proxies;

namespace Nostalgia.LuaModules
{
    /// <summary>
    /// Module providing <see href="https://wiki.facepunch.com/gmod/Global_Variables">global variables</see>.
    /// </summary>
    class GlobalConstantsModule
    {
        private readonly Host host;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalConstantsModule"/> class.
        /// </summary>
        /// <param name="host"><see cref="Host"/> instance to determine whether we're on the client or the server side.</param>
        public GlobalConstantsModule(Host host)
        {
            this.host = host;
        }

        /// <summary>
        /// Inserts symbols into the Lua global namespace.
        /// </summary>
        /// <param name="runtime">Lua runtime to operate on.</param>
        public void Init(ILuaRuntime runtime)
        {
            runtime.Globals["CLIENT"] = runtime.Globals["CLIENT_DLL"] = host.IsClient;
            runtime.Globals["SERVER"] = runtime.Globals["GAME_DLL"] = host.IsServer;
            runtime.Globals["VERSION"] = "202110";
            runtime.Globals["VERSIONSTR"] = "2021.10.03";
            runtime.Globals["BRANCH"] = "unknown";
            runtime.Globals["GAMEMODE_NAME"] = "Nostalgia";  // TODO: Change after conversion to addon
        }
    }
}
