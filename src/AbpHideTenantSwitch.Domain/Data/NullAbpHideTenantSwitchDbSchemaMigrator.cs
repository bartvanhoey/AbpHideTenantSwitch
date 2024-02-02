using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpHideTenantSwitch.Data;

/* This is used if database provider does't define
 * IAbpHideTenantSwitchDbSchemaMigrator implementation.
 */
public class NullAbpHideTenantSwitchDbSchemaMigrator : IAbpHideTenantSwitchDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
