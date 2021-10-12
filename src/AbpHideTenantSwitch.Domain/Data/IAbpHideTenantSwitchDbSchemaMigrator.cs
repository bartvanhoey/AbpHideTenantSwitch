using System.Threading.Tasks;

namespace AbpHideTenantSwitch.Data
{
    public interface IAbpHideTenantSwitchDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
