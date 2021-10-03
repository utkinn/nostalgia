namespace Nostalgia.Proxies
{
    /// <summary>
    /// <see cref="MoonSharp.Interpreter.Table"/> wrapper interface for testability.
    /// </summary>
    public interface ITable
    {
        /// <summary>
        /// Accesses underlying table's symbols.
        /// </summary>
        /// <param name="key">Key of wanted value.</param>
        /// <returns>Wanted value.</returns>
        public object this[object key] { get; set; }
    }
}