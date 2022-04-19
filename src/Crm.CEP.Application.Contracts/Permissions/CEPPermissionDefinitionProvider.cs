using Crm.CEP.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Crm.CEP.Permissions;

public class CEPPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CEPPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(CEPPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CEPResource>(name);
    }
}
