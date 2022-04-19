using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Crm.CEP.Segments
{
    public class SearchResultDto: AuditedEntityDto<long>
    {
       
        public string Name { get; set; }
    }
}
