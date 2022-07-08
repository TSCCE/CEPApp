using Crm.CEP.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Crm.CEP.Coupons
{
    public class CouponDto: AuditedEntityDto<long>
    {
        public string Name { get; set; }
        public string CampaignType { get; set; }
        public string Prefix { get; set; }
        public string ValidityStart { get; set; }
        public string ValidityEnd { get; set; }
        public WeekDays ValidDays { get; set; }
        public string ValidHoursStart { get; set; }
        public string ValidHoursEnd { get; set; }
        public string DiscountDetails { get; set; }
        public string Threshold { get; set; }
        public string MaxDiscount { get; set; }
        public CouponStatusEnum Status { get; set; }
        public string TotalIssued { get; set; }
        public string TotalRedeemed { get; set; }
        public long TermsId { get; set; }


    }
}
