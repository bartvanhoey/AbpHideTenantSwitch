﻿using Volo.Abp.Settings;

namespace AbpHideTenantSwitch.Settings;

public class AbpHideTenantSwitchSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AbpHideTenantSwitchSettings.MySetting1));
    }
}
