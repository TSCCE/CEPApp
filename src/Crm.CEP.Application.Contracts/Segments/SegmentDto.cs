using Crm.CEP.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Crm.CEP.Segments
{
    public class SegmentDto : AuditedEntityDto<long>
    {
        public string Name { get; set; }
    }
}
