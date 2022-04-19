using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
namespace Crm.CEP.Segments
{
    public class GetSegmentQueryDto : AuditedEntityDto<long>
    {

        public string Name { get; set; }
        public List<SegmentQueryDto> Segments { get; set; }
    }
}