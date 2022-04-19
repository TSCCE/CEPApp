using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Crm.CEP.Transactions
{
    public class TransactionDto: AuditedEntityDto<long>
    {

   
        [DataType(DataType.DateTime)]
        public DateTime PurchaseDate { get; set; }

        public string InvoiceValue { get; set; }

        public TransactionStatusEnum Status { get; set; }
        public string CustomerId { get; set; }
    }
}
