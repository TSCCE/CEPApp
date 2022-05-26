using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Crm.CEP.Transactions
{
    public class TransactionDto: AuditedEntityDto<long>
    {
        public string TransactionId { get; set; }

        public decimal InvoiceValue { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PurchaseDate { get; set; }

        public string CustomerId { get; set; }

        public string TransactionStatus { get; set; }

        public string TransactionItem { get; set; }

        public string Discount { get; set; }
        public decimal ATV { get; set; }
        public decimal UPT { get; set; }
        public string StoreIDOfTransaction { get; set; }
        public string StoreName { get; set; }
    }
}
