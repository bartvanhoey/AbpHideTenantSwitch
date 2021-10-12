using AbpHideTenantSwitch.Localization;
using Volo.Abp.AspNetCore.Components;

namespace AbpHideTenantSwitch.Blazor
{
    public abstract class AbpHideTenantSwitchComponentBase : AbpComponentBase
    {
        protected AbpHideTenantSwitchComponentBase()
        {
            LocalizationResource = typeof(AbpHideTenantSwitchResource);
        }
    }
}
