using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Crm.CEP.Terms
{
    public class CreateUpdateTermsDto : AuditedEntityDto<long>
    {
        public string TermsID { get; set; }
        public string Terms { get; set; }
    }
}
