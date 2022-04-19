using Volo.Abp.Settings;

namespace Crm.CEP.Settings;

public class CEPSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(CEPSettings.MySetting1));
    }
}
