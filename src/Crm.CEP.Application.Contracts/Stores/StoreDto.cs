using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Crm.CEP.Stores
{
    public class StoreDto:AuditedEntityDto<long>
    {
        public string StoreID { get; set; }
        public string Unit { get; set; }
        public string Profile { get; set; }
        public string Emirate { get; set; }
        public string Area { get; set; }
        public string AreaCode { get; set; }
        public string AreaManager { get; set; }
        public string Username { get; set; }
        public string Key { get; set; }

    }
}
