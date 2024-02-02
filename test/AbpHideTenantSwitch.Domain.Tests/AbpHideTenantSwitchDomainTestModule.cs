using Volo.Abp.Modularity;

namespace AbpHideTenantSwitch;

[DependsOn(
    typeof(AbpHideTenantSwitchDomainModule),
    typeof(AbpHideTenantSwitchTestBaseModule)
)]
public class AbpHideTenantSwitchDomainTestModule : AbpModule
{

}
