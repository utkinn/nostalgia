using System.Collections.Generic;
using Nostalgia.Proxies;

namespace Nostalgia.Tests
{
    /// <summary>
    /// Fake Lua table class which uses <see cref="Dictionary{TKey,TValue}"/> to store values.
    /// </summary>
    class FakeTable : ITable
    {
        private readonly Dictionary<object, object> contents = new ();

        /// <inheritdoc/>
        public object this[object key] { get => contents[key]; set => contents[key] = value; }
    }
}
