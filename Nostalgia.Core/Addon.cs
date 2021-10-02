using Nostalgia.Core.Proxies;

namespace Nostalgia.Core
{
    internal record Addon(AddonManifest Manifest, string DirName)
    {
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
