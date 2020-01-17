using Microsoft.AspNetCore.Http;

namespace TarteAuCitron.OrchardCore.Settings
{
    public class CookiesSettings
    {
        public string ServicesScript { get; set; }
        public string PrivacyUrl { get; set; }
        public string CookieName { get; set; } = "tarteaucitron";
        public string Orientation { get; set; } = "bottom";
        public bool ShowAlertSmall { get; set; } = true;
        public bool Cookieslist { get; set; } = true;
        public bool AdBlocker { get; set; }
        public bool AcceptAllCta { get; set; } = true;
        public bool HighPrivacy { get; set; } = true;
        public bool HandleBrowserDNTRequest { get; set; }
        public bool RemoveCredit { get; set; }
        public bool MoreInfoLink { get; set; } = true;
        public string ReadMoreLink { get; set; }
    }
}
