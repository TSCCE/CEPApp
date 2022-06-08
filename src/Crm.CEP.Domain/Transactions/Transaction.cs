using Crm.CEP.Customers;
using Crm.CEP.TransactionsItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Crm.CEP.Transactions
{
    public class Transaction : AuditedAggregateRoot<long>
    {
        public string TransactionId { get; set; }

        public string InvoiceValue { get; set; }

       // [DataType(DataType.DateTime)]
        public string PurchaseDate { get; set; }

        [ForeignKey(nameof(Customer))]
        public string CustomerId { get; set; }

        public string TransactionStatus { get; set; }

        public string TransactionItem { get; set; }

        public string Discount { get; set; }
        public string ATV { get; set; }
        public string UPT { get; set; }
        public string StoreIDOfTransaction { get; set; }
        public string  StoreName { get; set; }
        public Transaction()
        {

        }


        public Customer Customer { get; set; }


        public IList<TransactionItem> TransactionItems { get; set; }
    }
}
