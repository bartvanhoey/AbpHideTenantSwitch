using AbpHideTenantSwitch.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AbpHideTenantSwitch.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpHideTenantSwitchEntityFrameworkCoreModule),
    typeof(AbpHideTenantSwitchApplicationContractsModule)
    )]
public class AbpHideTenantSwitchDbMigratorModule : AbpModule
{
}
