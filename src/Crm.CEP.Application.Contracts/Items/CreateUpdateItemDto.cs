using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Crm.CEP.Items
{
    public class CreateUpdateItemDto:AuditedEntityDto<long>
    {
        public string ItemID { get; set; }
        public string Name { get; set; }
    }
}
