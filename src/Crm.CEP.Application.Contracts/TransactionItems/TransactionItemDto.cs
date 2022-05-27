using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Crm.CEP.TransactionItems
{
    public class TransactionItemDto:AuditedEntityDto<long>
    {
        public string ItemID { get; set; }
   
        public string TransactionID { get; set; }


        public int ItemQuantity { get; set; }
        public int ItemDiscount { get; set; }
    }
}
