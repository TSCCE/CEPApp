using Crm.CEP.Items;
using Crm.CEP.Transactions;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Crm.CEP.TransactionsItems
{
    public class TransactionItem : AuditedAggregateRoot<long>
    {
        public string ItemID { get; set; }
        public Item Item { get; set; }

        public string TransactionID { get; set; }
       
        public Transaction Transaction { get; set; }

        public int ItemQuantity { get; set; }
        public int ItemDiscount { get; set; }
        
       
        
        public TransactionItem()
        {

        }


        public override object[] GetKeys()
        {
            return new object[] { TransactionID, ItemID };
        }
    }
}
