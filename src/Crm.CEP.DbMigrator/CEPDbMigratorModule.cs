using Crm.CEP.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Crm.CEP.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CEPEntityFrameworkCoreModule),
    typeof(CEPApplicationContractsModule)
    )]
public class CEPDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
