using Microsoft.AspNetCore.Mvc;
using Crm.CEP.Web.WorkFlows;
using Microsoft.Extensions.DependencyInjection;
using Crm.CEP.Web.Activities;
using Elsa.Options;

namespace Crm.CEP.Web.Extensions
{
    public static class UserServiceCollectionExtension
    {
        public static ElsaOptionsBuilder AddUserActivities(this ElsaOptionsBuilder services)
        {
            
            return services
               .AddActivity<CouponAssign>();
           
        }
    }
}
