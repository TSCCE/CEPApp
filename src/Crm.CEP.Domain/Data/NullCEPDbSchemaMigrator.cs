using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Crm.CEP.Data;

/* This is used if database provider does't define
 * ICEPDbSchemaMigrator implementation.
 */
public class NullCEPDbSchemaMigrator : ICEPDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
