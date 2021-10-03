using Moq;
using Nostalgia.LuaModules;
using Nostalgia.Proxies;
using Xunit;

namespace Nostalgia.Tests.LuaModules
{
    public class ConsoleModuleTests
    {
        private readonly FakeTable globals;
        private readonly Mock<Logger> logger;

        public ConsoleModuleTests()
        {
            var runtime = new Mock<ILuaRuntime>();
            globals = new FakeTable();
            runtime.SetupGet(mock => mock.Globals).Returns(globals);
            logger = new Mock<Logger>();
            var module = new ConsoleModule(logger.Object);
            module.Init(runtime.Object);
        }

        [Fact]
        public void ProvidesPrint()
        {
            var print = (ConsoleModule.PrintDelegate)globals["print"];
            print(1, "string");

            logger.Verify(mock => mock.Info("1\tstring\n"));
        }

        [Fact]
        public void ProvidesMsg()
        {
            var msg = (ConsoleModule.PrintDelegate)globals["Msg"];

            msg(1, "string");
            logger.Verify(mock => mock.Info("1string"), Times.Never, "should not log anything until a call with new line");
            msg("hey\n");
            logger.Verify(mock => mock.Info("1stringhey\n"));
        }

        [Fact]
        public void ProvidesMsgN()
        {
            var msgn = (ConsoleModule.PrintDelegate)globals["MsgN"];

            msgn(1, "string");
            logger.Verify(mock => mock.Info("1string\n"));
        }
    }
}