using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Nostalgia.Core.Proxies;

namespace Nostalgia.Core
{
    internal class AddonDiscoverer
    {
        private readonly FileSystem fileSystem;
        private readonly Logger logger;

        public AddonDiscoverer(FileSystem fileSystem, Logger logger)
        {
            this.fileSystem = fileSystem;
            this.logger = logger;
        }

        public IEnumerable<Addon> Discover()
        {
            var addons = new List<Addon>();

            foreach (var addonDir in fileSystem.FindDirectory("addons"))
            {
                try
                {
                    var manifest = fileSystem.ReadJson<AddonManifest>($"addons/{addonDir}/addon.json");
                    addons.Add(new Addon(manifest, addonDir));
                }
                catch (JsonException e)
                {
                    LogManifestProblem(addonDir, e, "malformed");
                }
                catch (FileNotFoundException e)
                {
                    LogManifestProblem(addonDir, e, "missing");
                }
            }

            return addons;
        }

        private void LogManifestProblem(string addonDir, Exception e, string problem)
        {
            logger.Error($"Failed to load addon {addonDir} ({problem} manifest)");
            logger.Error(e);
        }
    }
}
