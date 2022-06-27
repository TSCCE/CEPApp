using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Crm.CEP.Referrals
{
    public class ReferralDto : AuditedEntityDto<long>
    {
        public string ReferralID { get; set; }
        public string Name { get; set; }
        public string PointsOfReferrer { get; set; }
        public string EndDate { get; set; }
        public string PointsOfReferree { get; set; }
        public string StartDate { get; set; }
        public string ExpiryInDays { get; set; }

    }
}
