using MoonSharp.Interpreter;

namespace Nostalgia.Core.Proxies
{
    public interface ILuaRuntime
    {
        Table Globals { get; }

        void DoString(string code);
    }
}