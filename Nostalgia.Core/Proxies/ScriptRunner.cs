using MoonSharp.Interpreter;

namespace Nostalgia.Core.Proxies
{
    public class ScriptRunner
    {
        public virtual void Run(string script) => Script.RunString(script);
    }
}
