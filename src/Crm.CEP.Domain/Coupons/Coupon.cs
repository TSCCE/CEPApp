using Crm.CEP.CustomerCoupons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Crm.CEP.Coupons
{
    public class Coupon : AuditedAggregateRoot<long>
    {

        public string Name { get; set; }

        public CouponStatusEnum Status { get; set; }


        public Coupon()
        {

        }

        public IList<CustomerCoupon> CustomerCoupons { get; set; }
    }
}
