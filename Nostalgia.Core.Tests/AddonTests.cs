using System;
using Moq;
using Nostalgia.Core.Proxies;
using Xunit;

namespace Nostalgia.Core.Tests
{
    public class AddonTests
    {
        [Fact]
        public void RunsSharedAutorunScripts()
        {
            var sharedAutorunDir = "addons/addondir/lua/autorun";
            var fsMock = new Mock<FileSystem>();
            fsMock.Setup(mock => mock.FindFile(sharedAutorunDir, "*.lua")).Returns(new[] { "auto1.lua", "auto2.lua", "somethingelse.txt" });
            var script = "print 'Hello'";
            fsMock.Setup(mock => mock.ReadAllText(sharedAutorunDir + "/auto1.lua")).Returns(script + "1");
            fsMock.Setup(mock => mock.ReadAllText(sharedAutorunDir + "/auto2.lua")).Returns(script + "2");
            var runtimeMock = new Mock<ILuaRuntime>();
            var addon = new Addon(new AddonManifest("Addon", "type", Array.Empty<string>()), "addondir");

            addon.Autorun(fsMock.Object, runtimeMock.Object);

            fsMock.Verify(mock => mock.FindFile(sharedAutorunDir, "*.lua"));
            runtimeMock.Verify(mock => mock.DoString(script + "1"));
            runtimeMock.Verify(mock => mock.DoString(script + "2"));
        }
    }
}
