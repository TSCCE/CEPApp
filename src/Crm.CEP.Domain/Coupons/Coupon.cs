using Crm.CEP.CustomerCoupons;
using Crm.CEP.Items;
using Crm.CEP.Shared;
using Crm.CEP.Terms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Crm.CEP.Coupons
{
    public class Coupon : AuditedAggregateRoot<long>
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

        [ForeignKey(nameof(TermsConditions))]
        public long TermsId { get; set; }
        public TermsConditions Terms { get; set; }
        public Coupon()
        {

        }

        //relationships
        public IList<CustomerCoupon> CustomerCoupons { get; set; }
        public IList<Item> ValidProducts { get; set; }
        
    }
}
