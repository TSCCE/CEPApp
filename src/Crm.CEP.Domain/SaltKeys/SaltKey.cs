using Crm.CEP.Passwords;
using Crm.CEP.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Crm.CEP.SaltKeys
{
    public class SaltKey:AuditedAggregateRoot<long>
    {
        public string SaltKeyvalue { get; set; }
        public Password password { get; set; }
     

    }
}
