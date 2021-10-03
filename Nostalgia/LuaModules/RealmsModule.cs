using Nostalgia.Proxies;

namespace Nostalgia.LuaModules
{
    /// <summary>
    /// Module providing <see href="https://wiki.facepunch.com/gmod/Global_Variables#client">CLIENT</see>
    /// and <see href="https://wiki.facepunch.com/gmod/Global_Variables#server">SERVER</see> global constants.
    /// </summary>
    class RealmsModule
    {
        private readonly Host host;

        /// <summary>
        /// Initializes a new instance of the <see cref="RealmsModule"/> class.
        /// </summary>
        /// <param name="host"><see cref="Host"/> instance to determine whether we're on the client or the server side.</param>
        public RealmsModule(Host host)
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
        }
    }
}
