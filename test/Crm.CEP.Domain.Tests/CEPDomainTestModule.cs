using Crm.CEP.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Crm.CEP;

[DependsOn(
    typeof(CEPEntityFrameworkCoreTestModule)
    )]
public class CEPDomainTestModule : AbpModule
{

}
