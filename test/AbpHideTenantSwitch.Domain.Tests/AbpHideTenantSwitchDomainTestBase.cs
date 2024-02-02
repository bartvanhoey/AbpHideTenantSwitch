using Volo.Abp.Modularity;

namespace AbpHideTenantSwitch;

/* Inherit from this class for your domain layer tests. */
public abstract class AbpHideTenantSwitchDomainTestBase<TStartupModule> : AbpHideTenantSwitchTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
