using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Crm.CEP.Segments
{
    
    public class DropdownSegmentDto: AuditedEntityDto<long>
    {
        public string Name { get; set; }
        public long Id { get; set; }
    }
}
