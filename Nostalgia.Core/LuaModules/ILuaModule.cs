using Nostalgia.Core.Proxies;

namespace Nostalgia.Core.LuaModules
{
    internal interface ILuaModule
    {
        void Init(ILuaRuntime runtime);
    }
}
