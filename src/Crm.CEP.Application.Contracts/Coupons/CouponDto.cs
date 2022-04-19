using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Crm.CEP.Coupons
{
    public class CouponDto: AuditedEntityDto<long>
    {
        public string Name { get; set; }
        public CouponStatusEnum Status { get; set; }


    }
}
