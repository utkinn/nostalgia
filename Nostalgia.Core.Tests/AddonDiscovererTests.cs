using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FluentAssertions;
using Moq;
using Nostalgia.Core.Proxies;
using Xunit;

namespace Nostalgia.Core.Tests
{
    public class AddonDiscovererTests
    {
        private readonly Mock<FileSystem> fsMock = new ();
        private readonly Mock<Logger> loggerMock = new ();
        private readonly AddonDiscoverer discoverer;

        public AddonDiscovererTests()
        {
            discoverer = new AddonDiscoverer(fsMock.Object, loggerMock.Object);
        }

        public static IEnumerable<object[]> ManifestProblems { get; } = new object[][]
        {
            new object[] { new JsonException(),  "malformed" },
            new object[] { new FileNotFoundException(),  "missing" },
        };

        [Fact]
        public void DiscoversAddons()
        {
            fsMock.Setup(fs => fs.FindDirectory("addons")).Returns(new[] { "addon1", "addon2" });
            var manifest1 = new AddonManifest("Addon1", "tool", Array.Empty<string>());
            var manifest2 = new AddonManifest("Addon2", "entity", new[] { "fun" });
            fsMock.Setup(fs => fs.ReadJson<AddonManifest>("addons/addon1/addon.json")).Returns(manifest1);
            fsMock.Setup(fs => fs.ReadJson<AddonManifest>("addons/addon2/addon.json")).Returns(manifest2);

            var addons = discoverer.Discover();

            addons.Should().BeEquivalentTo(
                new List<Addon>(new[]
                {
                new Addon(manifest1, "addon1"),
                new Addon(manifest2, "addon2"),
                }));
        }

        [Theory]
        [MemberData(nameof(ManifestProblems))]
        public void TolerantToProblematicAddonManifests(Exception exception, string problem)
        {
            fsMock.Setup(fs => fs.FindDirectory("addons")).Returns(new[] { "addon1" });
            fsMock.Setup(fs => fs.ReadJson<AddonManifest>("addons/addon1/addon.json")).Throws(exception);

            var addons = discoverer.Discover();

            addons.Should().BeEquivalentTo(new List<Addon>());
            loggerMock.Verify(mock => mock.Error(It.Is<string>(s => s.Contains($"{problem} manifest"))));
            loggerMock.Verify(mock => mock.Error(exception));
        }
    }
}
