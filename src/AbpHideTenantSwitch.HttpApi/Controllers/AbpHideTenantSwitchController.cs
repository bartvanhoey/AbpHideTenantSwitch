using AbpHideTenantSwitch.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpHideTenantSwitch.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AbpHideTenantSwitchController : AbpControllerBase
    {
        protected AbpHideTenantSwitchController()
        {
            LocalizationResource = typeof(AbpHideTenantSwitchResource);
        }
    }
}