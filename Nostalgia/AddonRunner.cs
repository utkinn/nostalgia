using Nostalgia.Proxies;

namespace Nostalgia
{
    /// <summary>
    /// Discovers installed addons and runs their autorun code.
    /// </summary>
    class AddonRunner
    {
        private readonly FileSystem fs;
        private readonly ILuaRuntime runtime;
        private readonly AddonDiscoverer discoverer;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddonRunner"/> class.
        /// </summary>
        /// <param name="fs"><see cref="FileSystem"/> instance to discover addons with.</param>
        /// <param name="runtime">Lua runtime in whose context the addon code will be executed.</param>
        /// <param name="discoverer"><see cref="AddonDiscoverer"/> instance to discover addons with.</param>
        public AddonRunner(FileSystem fs, ILuaRuntime runtime, AddonDiscoverer discoverer)
        {
            this.fs = fs;
            this.runtime = runtime;
            this.discoverer = discoverer;
        }

        /// <summary>
        /// Discovers installed addons and runs their autorun code.
        /// </summary>
        public void RunAll()
        {
            foreach (var addon in discoverer.Discover())
            {
                addon.Autorun(fs, runtime);
            }
        }
    }
}
