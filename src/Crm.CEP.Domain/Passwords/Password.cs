using Crm.CEP.SaltKeys;
using Crm.CEP.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Crm.CEP.Passwords
{
    public class Password: AuditedAggregateRoot<long>
    {
        public string PasswordValue { get; set; }

        [ForeignKey(nameof(SaltKey))]
        public long SaltKeyID { get; set; }
        public Setting Setting { get; set; }

        public SaltKey SaltKey { get; set; }    
    }
}
