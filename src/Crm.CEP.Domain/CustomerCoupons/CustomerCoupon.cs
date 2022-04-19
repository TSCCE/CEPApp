using Crm.CEP.Coupons;
using Crm.CEP.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Crm.CEP.CustomerCoupons
{
    public class CustomerCoupon : AuditedAggregateRoot<long>
    {
        public string CustomerId { get; set; }

        public Customer Customer { get; set; }
        public long CouponId { get; set; }
        public Coupon Coupon { get; set; }
        public CustomerCoupon()
        {

        }


        public override object[] GetKeys()
        {
            return new object[] { CustomerId, CouponId };
        }


    }
}
