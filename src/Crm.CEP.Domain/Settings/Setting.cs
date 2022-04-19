using Crm.CEP.Passwords;
using Crm.CEP.SaltKeys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Crm.CEP.Settings
{
    public class Setting: AuditedAggregateRoot<long>
    {
        public string Settingskey { get; set; }
        public string Settingsvalue { get; set; }
        public string UserId { get; set; }

        [ForeignKey(nameof(Password))]
        public long PasswordId { get; set; }
        public string URL { get; set; }
       
        public Password Password { get; set; }
        
    }
}
