using System.Collections.Generic;

namespace Nostalgia.Proxies
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Sandbox.BaseFileSystem proxy for testability")]
    internal class FileSystem
    {
        private static Sandbox.BaseFileSystem FsData => Sandbox.FileSystem.Data;

        public virtual IEnumerable<string> FindDirectory(string folder) => FsData.FindDirectory(folder);

        public virtual IEnumerable<string> FindFile(string folder, string pattern = "*") => FsData.FindFile(folder, pattern);

        public virtual string ReadAllText(string file) => FsData.ReadAllText(file);

        public virtual T ReadJson<T>(string file) => FsData.ReadJson<T>(file);
    }
}
