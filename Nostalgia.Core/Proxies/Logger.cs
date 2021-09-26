using System;

namespace Nostalgia.Core.Proxies
{
    internal class Logger
    {
        private readonly Sandbox.Logger logger = new ("Nostalgia");

        public virtual void Error(string message) => logger.Error(message);

        public virtual void Error(Exception exception) => logger.Error(exception);
    }
}
