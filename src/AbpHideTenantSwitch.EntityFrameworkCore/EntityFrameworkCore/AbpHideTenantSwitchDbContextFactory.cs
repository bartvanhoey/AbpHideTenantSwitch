using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AbpHideTenantSwitch.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class AbpHideTenantSwitchDbContextFactory : IDesignTimeDbContextFactory<AbpHideTenantSwitchDbContext>
    {
        public AbpHideTenantSwitchDbContext CreateDbContext(string[] args)
        {
            AbpHideTenantSwitchEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<AbpHideTenantSwitchDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new AbpHideTenantSwitchDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../AbpHideTenantSwitch.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
