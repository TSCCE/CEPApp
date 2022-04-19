using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Crm.CEP.Data;
using Volo.Abp.DependencyInjection;

namespace Crm.CEP.EntityFrameworkCore;

public class EntityFrameworkCoreCEPDbSchemaMigrator
    : ICEPDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreCEPDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the CEPDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<CEPDbContext>()
            .Database
            .MigrateAsync();
    }
}
