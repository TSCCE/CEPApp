using Crm.CEP.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Crm.CEP.Coupons
{
    public interface ICouponAppService:
         ICrudAppService<
            CouponDto,            
            long,
            PagedAndSortedResultRequestDto,
            CreateUpdateCouponDto>
         
    {
        // Task MapCustomercoupon(CustomerCouponDto customerCoupon);
        Task<List<DropdownCouponDto>> GetCoupDropdownsAsync();
    }
}
