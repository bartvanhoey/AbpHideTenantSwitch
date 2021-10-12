using System;
using System.Collections.Generic;
using System.Text;
using AbpHideTenantSwitch.Localization;
using Volo.Abp.Application.Services;

namespace AbpHideTenantSwitch
{
    /* Inherit your application services from this class.
     */
    public abstract class AbpHideTenantSwitchAppService : ApplicationService
    {
        protected AbpHideTenantSwitchAppService()
        {
            LocalizationResource = typeof(AbpHideTenantSwitchResource);
        }
    }
}
