using MSTable = MoonSharp.Interpreter.Table;

namespace Nostalgia.Proxies
{
    /// <summary>
    /// <see cref="ITable"/> real implementation.
    /// </summary>
    class Table : ITable
    {
        private readonly MSTable moonSharpTable;

        /// <summary>
        /// Initializes a new instance of the <see cref="Table"/> class.
        /// </summary>
        /// <param name="moonSharpTable">Real MoonSharp table instance to wrap.</param>
        public Table(MSTable moonSharpTable)
        {
            this.moonSharpTable = moonSharpTable;
        }

        /// <summary>
        /// Accesses underlying table's symbols.
        /// </summary>
        /// <param name="key">Key of wanted value.</param>
        /// <returns>Wanted value.</returns>
        public object this[object key]
        {
            get => moonSharpTable[key];
            set => moonSharpTable[key] = value;
        }
    }
}
