using Crm.CEP.Segments;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Crm.CEP.Queries
{
    public class QueryDto : AuditedEntityDto<long>
    {
        public long SegmentId { get; set; }

        public string SegmentName { get; set; }

        public string JsonQueryField { get; set; }
    }
}
