using Crm.CEP.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Crm.CEP.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CEPController : AbpControllerBase
{
    protected CEPController()
    {
        LocalizationResource = typeof(CEPResource);
    }
}
