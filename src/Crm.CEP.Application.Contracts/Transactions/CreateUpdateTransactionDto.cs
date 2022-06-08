using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Crm.CEP.Transactions
{
    public class CreateUpdateTransactionDto  : AuditedEntityDto<long>
    {
        public string TransactionId { get; set; }

        public string InvoiceValue { get; set; }

        // [DataType(DataType.DateTime)]
        public string PurchaseDate { get; set; }

        
        public string CustomerId { get; set; }

        public string TransactionStatus { get; set; }

        public string TransactionItem { get; set; }

        public string Discount { get; set; }
        public string ATV { get; set; }
        public string UPT { get; set; }
        public string StoreIDOfTransaction { get; set; }
        public string StoreName { get; set; }
    }
}
