using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Nostalgia.Proxies;

namespace Nostalgia
{
    /// <summary>
    /// Discovers installed addons in <c>(Sandbox root)/data/local/nostalgia/addons</c>.
    /// </summary>
    class AddonDiscoverer
    {
        private readonly FileSystem fileSystem;
        private readonly Logger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddonDiscoverer"/> class.
        /// </summary>
        /// <param name="fileSystem"><see cref="FileSystem"/> instance to discover addons with.</param>
        /// <param name="logger"><see cref="Logger"/> instance to report addon loading errors with.</param>
        public AddonDiscoverer(FileSystem fileSystem, Logger logger)
        {
            this.fileSystem = fileSystem;
            this.logger = logger;
        }

        /// <summary>
        /// Discovers installed addons in <c>(Sandbox root)/data/local/nostalgia/addons</c>.
        /// </summary>
        /// <returns><see cref="IEnumerable{Addon}"/> of discovered addons. Broken addons, such as those having invalid or no <c>addons.json</c>, are excluded.</returns>
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
