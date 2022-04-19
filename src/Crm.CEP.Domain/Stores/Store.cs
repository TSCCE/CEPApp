using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Crm.CEP.Stores
{
    public class Store: AuditedAggregateRoot<long>
    {
        public string StoreID { get; set; }
        public string StoreName { get; set; }
        public string StoreManager { get; set;}
        public string StoreLocation { get; set;}

    }
}
