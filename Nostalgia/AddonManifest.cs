using System.Collections.Generic;

namespace Nostalgia
{
    /// <summary>
    /// Addon metadata described in <c>(Addon root)/addon.json</c>.
    /// </summary>
    /// <seealso>https://wiki.facepunch.com/gmod/Workshop_Addon_Creation#addonjson</seealso>
    record AddonManifest(string Title, string Type, IEnumerable<string> Tags);
}
