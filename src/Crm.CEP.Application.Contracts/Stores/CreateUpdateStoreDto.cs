using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Crm.CEP.Stores
{
    public class CreateUpdateStoreDto:AuditedEntityDto<long>
    {
        public string StoreID { get; set; }
        public string StoreName { get; set; }
        public string StoreManager { get; set; }
        public string StoreLocation { get; set; }
    }
}
