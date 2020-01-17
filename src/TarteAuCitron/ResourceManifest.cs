using OrchardCore.ResourceManagement;

namespace TarteAuCitron.OrchardCore
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(IResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

            manifest
                .DefineScript("TarteAuCitron")
                .SetUrl("~/TarteAuCitron.OrchardCore/Scripts/tarteaucitron.min.js", "~/TarteAuCitron.OrchardCore/Scripts/tarteaucitron.js")
                //.SetCdn("https://cdn.jsdelivr.net/gh/AmauriC/tarteaucitron.js@1.3/tarteaucitron.js")
                //.SetCdnIntegrity("")
                .SetVersion("1.3.1");

            manifest
                .DefineScript("TarteAuCitron.Services")
                .SetUrl("~/TarteAuCitron.OrchardCore/Scripts/tarteaucitron.services.min.js", "~/TarteAuCitron.OrchardCore/Scripts/tarteaucitron.services.js")
                //.SetCdn("https://cdn.jsdelivr.net/gh/AmauriC/tarteaucitron.js@1.3/tarteaucitron.services.js")
                //.SetCdnIntegrity("")
                .SetVersion("1.3.1");

            manifest
                .DefineStyle("TarteAuCitron")
                .SetUrl("~/TarteAuCitron.OrchardCore/Styles/tarteaucitron.min.css", "~/TarteAuCitron.OrchardCore/Styles/tarteaucitron.css")
                .SetVersion("1.3.1");
        }
    }
}
