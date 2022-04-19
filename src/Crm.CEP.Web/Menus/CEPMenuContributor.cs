using System.Threading.Tasks;
using Crm.CEP.Localization;
using Crm.CEP.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Crm.CEP.Web.Menus;

public class CEPMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<CEPResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                CEPMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );
        context.Menu.Items.Insert(
   1,
   new ApplicationMenuItem(
       CEPMenus.Home,
       "Workflow",
       "~/workflow",
       icon: "fas fa-code-branch",
       order: 1

   )
);

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        var segmentMenu = new ApplicationMenuItem(
                          "Segment",
                          "Segment",
                          url: "/Segment",
                          icon: "fa fa-handshake-o"
                          );
        context.Menu.AddItem(segmentMenu);

        var journeyMenu = new ApplicationMenuItem(
                           "Journey",
                           "Journey Mapping",
                        url: "/Journey",
                        icon: "fa fa-gift-card"
                        );
        context.Menu.AddItem(journeyMenu);
    }
}
