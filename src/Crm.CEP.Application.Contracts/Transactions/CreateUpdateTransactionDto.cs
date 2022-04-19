using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Crm.CEP.Transactions
{
    public class CreateUpdateTransactionDto  : AuditedEntityDto<long>
    {
        
        [DataType(DataType.DateTime)]
        public DateTime PurchaseDate { get; set; }

        public decimal InvoiceValue { get; set; }

        public TransactionStatusEnum Status { get; set; }
        public long CustomerId { get; set; }
    }
}
