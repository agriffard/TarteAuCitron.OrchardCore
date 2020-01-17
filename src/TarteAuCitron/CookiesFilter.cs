using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchardCore.Admin;
using OrchardCore.Entities;
using OrchardCore.ResourceManagement;
using OrchardCore.Settings;
using TarteAuCitron.OrchardCore.Settings;

namespace TarteAuCitron.OrchardCore
{
    public class CookiesFilter : IAsyncResultFilter
    {
        private readonly IResourceManager _resourceManager;
        private readonly ISiteService _siteService;

        private HtmlString _scriptsCache;

        public CookiesFilter(
            IResourceManager resourceManager,
            ISiteService siteService)
        {
            _resourceManager = resourceManager;
            _siteService = siteService;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            // Should only run on the front-end for a full view
            if ((context.Result is ViewResult || context.Result is PageResult) &&
                !AdminAttribute.IsApplied(context.HttpContext))
            {
                if (_scriptsCache == null)
                {
                    var settings = (await _siteService.GetSiteSettingsAsync()).As<CookiesSettings>();

                    //if (!string.IsNullOrWhiteSpace(settings?.ServicesScript))
                    //{
                    _scriptsCache = new HtmlString($"<script src=\"/TarteAuCitron.OrchardCore/Scripts/tarteaucitron.js\"></script>\n<script>tarteaucitron.init({{ \"privacyUrl\": \"{settings.PrivacyUrl}\", \"hashtag\": \"#tarteaucitron\", \"cookieName\": \"{settings.CookieName}\", \"orientation\": \"{settings.Orientation}\", \"showAlertSmall\": {settings.ShowAlertSmall.ToString().ToLower()}, \"cookieslist\": {settings.Cookieslist.ToString().ToLower()}, \"adblocker\": {settings.AdBlocker.ToString().ToLower()}, \"AcceptAllCta\" : {settings.AcceptAllCta.ToString().ToLower()}, \"highPrivacy\": {settings.HighPrivacy.ToString().ToLower()}, \"handleBrowserDNTRequest\": {settings.HandleBrowserDNTRequest.ToString().ToLower()}, \"removeCredit\": {settings.RemoveCredit.ToString().ToLower()}, \"moreInfoLink\": {settings.MoreInfoLink.ToString().ToLower()}, \"useExternalCss\": false, \"readmoreLink\": \"{settings.ReadMoreLink}\"}});</script>\n<script>{settings.ServicesScript}</script>");
                    //}
                }

                if (_scriptsCache != null)
                {
                    //_resourceManager.RegisterLink();
                    _resourceManager.RegisterHeadScript(_scriptsCache);
                }
            }

            await next.Invoke();
        }
    }
}
