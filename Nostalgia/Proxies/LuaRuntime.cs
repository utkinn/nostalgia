using MoonSharp.Interpreter;

namespace Nostalgia.Proxies
{
    /// <summary>
    /// <see cref="ILuaRuntime"/> default implementation.
    /// </summary>
    public class LuaRuntime : ILuaRuntime
    {
        private readonly Script script = new();

        /// <inheritdoc/>
        public Table Globals => script.Globals;

        /// <inheritdoc/>
        public virtual void DoString(string code) => script.DoString(code);
    }
}
