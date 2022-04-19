using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Crm.CEP.CustomerCoupons
{
    public class CustomerCouponDto : AuditedEntityDto<long>
    {
        public long CustomerId { get; set; }  
        public long CouponId { get; set; }
    }
}
