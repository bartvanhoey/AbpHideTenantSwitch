using AbpHideTenantSwitch.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpHideTenantSwitch
{
    [DependsOn(
        typeof(AbpHideTenantSwitchEntityFrameworkCoreTestModule)
        )]
    public class AbpHideTenantSwitchDomainTestModule : AbpModule
    {

    }
}