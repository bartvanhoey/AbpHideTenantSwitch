using Volo.Abp.Modularity;

namespace AbpHideTenantSwitch;

[DependsOn(
    typeof(AbpHideTenantSwitchApplicationModule),
    typeof(AbpHideTenantSwitchDomainTestModule)
)]
public class AbpHideTenantSwitchApplicationTestModule : AbpModule
{

}
