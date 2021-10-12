using AbpHideTenantSwitch.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpHideTenantSwitch.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpHideTenantSwitchEntityFrameworkCoreModule),
        typeof(AbpHideTenantSwitchApplicationContractsModule)
        )]
    public class AbpHideTenantSwitchDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
