using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using OrchardCore.DisplayManagement.Entities;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Environment.Shell;
using TarteAuCitron.OrchardCore.Settings;
using TarteAuCitron.OrchardCore.ViewModels;
using OrchardCore.Settings;

namespace TarteAuCitron.OrchardCore.Drivers
{
    public class CookiesSettingsDisplayDriver : SectionDisplayDriver<ISite, CookiesSettings>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IShellHost _shellHost;
        private readonly ShellSettings _shellSettings;

        public CookiesSettingsDisplayDriver(
            IAuthorizationService authorizationService,
            IHttpContextAccessor httpContextAccessor,
            IShellHost shellHost,
            ShellSettings shellSettings)
        {
            _authorizationService = authorizationService;
            _httpContextAccessor = httpContextAccessor;
            _shellHost = shellHost;
            _shellSettings = shellSettings;
        }

        public override async Task<IDisplayResult> EditAsync(CookiesSettings settings, BuildEditorContext context)
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user == null || !await _authorizationService.AuthorizeAsync(user, Permissions.ManageCookies))
            {
                return null;
            }

            return Initialize<CookiesSettingsViewModel>("CookiesSettings_Edit", model =>
            {
                model.ServicesScript = settings.ServicesScript;
                model.PrivacyUrl = settings.PrivacyUrl;
                model.CookieName = settings.CookieName;
                model.Orientation = settings.Orientation;
                model.ShowAlertSmall = settings.ShowAlertSmall;
                model.Cookieslist = settings.Cookieslist;
                model.AdBlocker = settings.AdBlocker;
                model.AcceptAllCta = settings.AcceptAllCta;
                model.HighPrivacy = settings.HighPrivacy;
                model.HandleBrowserDNTRequest = settings.HandleBrowserDNTRequest;
                model.RemoveCredit = settings.RemoveCredit;
                model.MoreInfoLink = settings.MoreInfoLink;
                model.ReadMoreLink = settings.ReadMoreLink;
            }).Location("Content:5").OnGroup(CookiesConstants.Features.Cookies);
        }

        public override async Task<IDisplayResult> UpdateAsync(CookiesSettings settings, BuildEditorContext context)
        {
            if (context.GroupId == CookiesConstants.Features.Cookies)
            {
                var user = _httpContextAccessor.HttpContext?.User;
                if (user == null || !await _authorizationService.AuthorizeAsync(user, Permissions.ManageCookies))
                {
                    return null;
                }

                var model = new CookiesSettingsViewModel();
                await context.Updater.TryUpdateModelAsync(model, Prefix);

                if (context.Updater.ModelState.IsValid)
                {
                    settings.ServicesScript = model.ServicesScript;
                    settings.Orientation = model.Orientation;
                    settings.CookieName = model.CookieName;
                    settings.Orientation = model.Orientation;
                    settings.ShowAlertSmall = model.ShowAlertSmall;
                    settings.Cookieslist = model.Cookieslist;
                    settings.AdBlocker = model.AdBlocker;
                    settings.AcceptAllCta = model.AcceptAllCta;
                    settings.HighPrivacy = model.HighPrivacy;
                    settings.HandleBrowserDNTRequest = model.HandleBrowserDNTRequest;
                    settings.RemoveCredit = model.RemoveCredit;
                    settings.MoreInfoLink = model.MoreInfoLink;
                    settings.ReadMoreLink = model.ReadMoreLink;
                }
            }
            return await EditAsync(settings, context);
        }
    }
}