using Volo.Abp.Modularity;

namespace Crm.CEP;

[DependsOn(
    typeof(CEPApplicationModule),
    typeof(CEPDomainTestModule)
    )]
public class CEPApplicationTestModule : AbpModule
{

}
