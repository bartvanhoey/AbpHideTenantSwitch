using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpHideTenantSwitch.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class AbpHideTenantSwitchBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpHideTenantSwitch";
    }
}
