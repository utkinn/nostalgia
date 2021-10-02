using Nostalgia.Core.Proxies;

namespace Nostalgia.Core
{
    class AddonRunner
    {
        private readonly FileSystem fs;
        private readonly ILuaRuntime runtime;
        private readonly AddonDiscoverer discoverer;

        public AddonRunner(FileSystem fs, ILuaRuntime runtime, AddonDiscoverer discoverer)
        {
            this.fs = fs;
            this.runtime = runtime;
            this.discoverer = discoverer;
        }

        public void RunAll()
        {
            foreach (var addon in discoverer.Discover())
            {
                addon.Autorun(fs, runtime);
            }
        }
    }
}
