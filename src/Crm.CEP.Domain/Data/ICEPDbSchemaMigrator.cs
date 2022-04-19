using System.Threading.Tasks;

namespace Crm.CEP.Data;

public interface ICEPDbSchemaMigrator
{
    Task MigrateAsync();
}
