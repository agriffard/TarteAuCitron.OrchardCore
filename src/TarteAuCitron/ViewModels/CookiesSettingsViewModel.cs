using System.ComponentModel.DataAnnotations;

namespace TarteAuCitron.OrchardCore.ViewModels
{
    public class CookiesSettingsViewModel
    {
        public string ServicesScript { get; set; }
        public string PrivacyUrl { get; set; }
        public string CookieName { get; set; }
        public string Orientation { get; set; }
        public bool ShowAlertSmall { get; set; }
        public bool Cookieslist { get; set; }
        public bool AdBlocker { get; set; }
        public bool AcceptAllCta { get; set; }
        public bool HighPrivacy { get; set; }
        public bool HandleBrowserDNTRequest { get; set; }
        public bool RemoveCredit { get; set; }
        public bool MoreInfoLink { get; set; }
        public string ReadMoreLink { get; set; }
    }
}
