using MoonSharp.Interpreter;

namespace Nostalgia.Proxies
{
    /// <summary>
    /// <see cref="Script"/> proxy for testability.
    /// </summary>
    interface ILuaRuntime
    {
        /// <summary>
        /// Gets the table with global Lua symbols.
        /// </summary>
        public ITable Globals { get; }

        /// <summary>
        /// Executes Lua code.
        /// </summary>
        /// <param name="code">Lua code to execute.</param>
        void DoString(string code);
    }
}