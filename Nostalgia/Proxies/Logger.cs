using System;

namespace Nostalgia.Proxies
{
    /// <summary>
    /// <see cref="Sandbox.Logger"/> proxy for testability.
    /// </summary>
    class Logger
    {
        private readonly Sandbox.Logger logger = new("Nostalgia");

        /// <summary>
        /// Writes a regular severity message.
        /// </summary>
        /// <param name="message">Message to write.</param>
        public virtual void Info(string message) => logger.Info(message);

        /// <summary>
        /// Writes an "error" severity message.
        /// </summary>
        /// <param name="message">Message to write.</param>
        public virtual void Error(string message) => logger.Error(message);

        /// <summary>
        /// Writes an exception stack trace with the "error" severity.
        /// </summary>
        /// <param name="exception">Exception which stack trace to write.</param>
        public virtual void Error(Exception exception) => logger.Error(exception);
    }
}
