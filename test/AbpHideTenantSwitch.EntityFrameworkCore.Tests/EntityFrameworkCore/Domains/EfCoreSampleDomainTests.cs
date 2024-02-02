using AbpHideTenantSwitch.Samples;
using Xunit;

namespace AbpHideTenantSwitch.EntityFrameworkCore.Domains;

[Collection(AbpHideTenantSwitchTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AbpHideTenantSwitchEntityFrameworkCoreTestModule>
{

}
