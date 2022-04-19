using Crm.CEP.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Crm.CEP.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class CEPPageModel : AbpPageModel
{
    protected CEPPageModel()
    {
        LocalizationResourceType = typeof(CEPResource);
    }
}
