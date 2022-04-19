using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Crm.CEP.Web;

[Dependency(ReplaceServices = true)]
public class CEPBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CEP";
}
