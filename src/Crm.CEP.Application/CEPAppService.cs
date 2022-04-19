using System;
using System.Collections.Generic;
using System.Text;
using Crm.CEP.Localization;
using Volo.Abp.Application.Services;

namespace Crm.CEP;

/* Inherit your application services from this class.
 */
public abstract class CEPAppService : ApplicationService
{
    protected CEPAppService()
    {
        LocalizationResource = typeof(CEPResource);
    }
}
