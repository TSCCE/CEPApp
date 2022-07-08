using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Crm.CEP.Terms
{
    public class TermsConditions:AuditedAggregateRoot<long>
    {
        public string Terms { get; set; }
    }
}
