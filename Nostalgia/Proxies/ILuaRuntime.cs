using MoonSharp.Interpreter;

namespace Nostalgia.Proxies
{
    public interface ILuaRuntime
    {
        Table Globals { get; }

        void DoString(string code);
    }
}