using Volo.Abp.Modularity;

namespace AbpHideTenantSwitch;

public abstract class AbpHideTenantSwitchApplicationTestBase<TStartupModule> : AbpHideTenantSwitchTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
