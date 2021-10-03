using Nostalgia.Proxies;

namespace Nostalgia
{
    record Addon(AddonManifest Manifest, string DirName)
    {
        /// <summary>
        /// Executes the addon autorun code.
        /// </summary>
        /// <param name="fs"><see cref="FileSystem"/> instance to discover autorun scripts with.</param>
        /// <param name="runner">Lua runtime in whose context the addon code will be executed.</param>
        public void Autorun(FileSystem fs, ILuaRuntime runner)
        {
            foreach (var autorunFile in fs.FindFile($"addons/{DirName}/lua/autorun", "*.lua"))
            {
                var script = fs.ReadAllText($"addons/{DirName}/lua/autorun/{autorunFile}");
                runner.DoString(script);
            }
        }
    }
}
