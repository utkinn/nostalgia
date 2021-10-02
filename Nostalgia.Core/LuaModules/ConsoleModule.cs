using System;
using Nostalgia.Core.Proxies;

namespace Nostalgia.Core.LuaModules
{
    /// <summary>
    /// Implements console output functions such as <c>print</c>, <c>Msg</c> and so on.
    /// </summary>
    internal class ConsoleModule
    {
        private readonly Logger logger;

        public ConsoleModule(Logger logger)
        {
            this.logger = logger;  // TODO: Use separate loggers for each addon
        }

        private delegate void PrintDelegate(params object[] args);

        public void Init(ILuaRuntime runtime)
        {
            runtime.Globals["print"] = (PrintDelegate)Print;
        }

        private void Print(params object[] args)
        {
            logger.Info(string.Join(string.Empty, args));
        }
    }
}
