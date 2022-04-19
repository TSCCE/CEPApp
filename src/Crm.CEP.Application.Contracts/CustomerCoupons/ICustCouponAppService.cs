using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Crm.CEP.CustomerCoupons
{
    public interface ICustCouponAppService:
        ICrudAppService<
            CustomerCouponDto,
            long,
            PagedAndSortedResultRequestDto,
            CreateUpdateCustCouponDto>
    {
    }
}
