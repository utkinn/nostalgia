using System.Collections.Generic;

namespace Nostalgia.Proxies
{
    /// <summary>
    /// <see cref="Sandbox.BaseFileSystem"/> proxy for testability.
    /// </summary>
    class FileSystem
    {
        private static Sandbox.BaseFileSystem FsData => Sandbox.FileSystem.Data;

        /// <summary>Gets a list of directories in a directory.</summary>
        /// <param name="folder">Directory path to search in.</param>
        /// <returns>Found directories.</returns>
        public virtual IEnumerable<string> FindDirectory(string folder) => FsData.FindDirectory(folder);

        /// <summary>Gets a list of files in a directory.</summary>
        /// <param name="folder">Directory path to search in, relative to <c>(Sandbox root)/data/local/nostalgia</c>.</param>
        /// <param name="pattern">Glob pattern to match the file names against.</param>
        /// <returns>Found files.</returns>
        public virtual IEnumerable<string> FindFile(string folder, string pattern = "*") => FsData.FindFile(folder, pattern);

        /// <summary>
        /// Reads a text file contents.
        /// </summary>
        /// <param name="file">Text file to read.</param>
        /// <returns><see cref="file"/>'s contents.</returns>
        public virtual string ReadAllText(string file) => FsData.ReadAllText(file);

        /// <summary>
        /// Reads a JSON file contents and deserializes it into an object.
        /// </summary>
        /// <typeparam name="T">Deserialized JSON object type.</typeparam>
        /// <param name="file">JSON file to read.</param>
        /// <returns>Deserialized JSON object.</returns>
        public virtual T ReadJson<T>(string file) => FsData.ReadJson<T>(file);
    }
}
