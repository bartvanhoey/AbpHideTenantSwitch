﻿using Xunit;

namespace AbpHideTenantSwitch.EntityFrameworkCore;

[CollectionDefinition(AbpHideTenantSwitchTestConsts.CollectionDefinitionName)]
public class AbpHideTenantSwitchEntityFrameworkCoreCollection : ICollectionFixture<AbpHideTenantSwitchEntityFrameworkCoreFixture>
{

}
