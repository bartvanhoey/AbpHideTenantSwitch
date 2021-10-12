using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpHideTenantSwitch.Data;
using Volo.Abp.DependencyInjection;

namespace AbpHideTenantSwitch.EntityFrameworkCore
{
    public class EntityFrameworkCoreAbpHideTenantSwitchDbSchemaMigrator
        : IAbpHideTenantSwitchDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreAbpHideTenantSwitchDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the AbpHideTenantSwitchDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<AbpHideTenantSwitchDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
