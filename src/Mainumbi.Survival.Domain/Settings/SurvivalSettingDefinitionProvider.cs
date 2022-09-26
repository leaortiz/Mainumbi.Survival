using Volo.Abp.Settings;

namespace Mainumbi.Survival.Settings;

public class SurvivalSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(SurvivalSettings.MySetting1));
    }
}
