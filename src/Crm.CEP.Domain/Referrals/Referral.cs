using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Crm.CEP.Referrals
{
   
   public class Referral : AuditedAggregateRoot<long>
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
