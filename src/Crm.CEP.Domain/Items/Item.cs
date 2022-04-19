using Crm.CEP.Transactions;
using Crm.CEP.TransactionsItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Crm.CEP.Items
{
    public class Item : AuditedAggregateRoot<long>
    {
        public string ItemID { get; set; }
        public string Name { get; set; }

        public Item()
        {

        }


        public IList<TransactionItem> TransactionItems { get; set; }
    }
}
