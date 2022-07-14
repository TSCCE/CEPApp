using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Crm.CEP.Stores
{
    public class Store : AuditedAggregateRoot<long>
    {
        public string StoreID { get; set; }
        public string Unit { get; set; }
        public string Profile { get; set; }
        public string Emirate { get; set; }
        public string Area { get; set; }
        public string AreaCode { get; set; }
        public string AreaManager { get; set; }
        public string Username { get; set; }
        public string Key { get; set; }

    }
}
