using System;
using Nostalgia.Proxies;

namespace Nostalgia.LuaModules
{
    /// <summary>
    /// Implements console output functions such as <see href="https://wiki.facepunch.com/gmod/Global.print">print</see>,
    /// <see href="https://wiki.facepunch.com/gmod/Global.Msg">Msg</see> and so on.
    /// </summary>
    internal class ConsoleModule
    {
        private readonly Logger logger;
        private string msgBuffer = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleModule"/> class.
        /// </summary>
        /// <param name="logger"><see cref="Logger"/> instance to print with.</param>
        public ConsoleModule(Logger logger)
        {
            this.logger = logger;  // TODO: Use separate loggers for each addon
        }

        private delegate void PrintDelegate(params object[] args);

        /// <summary>
        /// Inserts symbols into the Lua global namespace.
        /// </summary>
        /// <param name="runtime">Lua runtime to operate on.</param>
        public void Init(ILuaRuntime runtime)
        {
            runtime.Globals["print"] = (PrintDelegate)Print;
            runtime.Globals["Msg"] = (PrintDelegate)Msg;
            runtime.Globals["MsgN"] = (PrintDelegate)MsgN;
        }

        private void Print(params object[] args)
        {
            logger.Info(string.Join('\t', args));
        }

        private void Msg(params object[] args)
        {
            var concatenated = string.Join(string.Empty, args);
            if (concatenated.EndsWith('\n'))
            {
                logger.Info(msgBuffer + concatenated);
                msgBuffer = string.Empty;
            }
            else
            {
                // Workaround to keep subsequent Msg calls in the same log message
                msgBuffer += concatenated;
            }
        }

        private void MsgN(params object[] args)
        {
            Msg(args, "\n");
        }
    }
}
