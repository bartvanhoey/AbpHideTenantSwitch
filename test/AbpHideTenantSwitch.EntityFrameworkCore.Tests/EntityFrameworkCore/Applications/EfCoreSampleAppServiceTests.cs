using AbpHideTenantSwitch.Samples;
using Xunit;

namespace AbpHideTenantSwitch.EntityFrameworkCore.Applications;

[Collection(AbpHideTenantSwitchTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AbpHideTenantSwitchEntityFrameworkCoreTestModule>
{

}
