using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Crm.CEP.CustomerCoupons
{
    public class CustCouponAppService : CrudAppService<
            CustomerCoupon,
            CustomerCouponDto,
            long,
            PagedAndSortedResultRequestDto,
            CreateUpdateCustCouponDto>,
        ICustCouponAppService
    {
        private readonly IRepository<CustomerCoupon, long> _custcouponRepository;
        public CustCouponAppService(IRepository<CustomerCoupon, long> repository) : base(repository)
        {
            _custcouponRepository= repository;
        }
        public override async Task<CustomerCouponDto> CreateAsync(CreateUpdateCustCouponDto coupon)
        {
            var newcoupon = ObjectMapper.Map<CreateUpdateCustCouponDto, CustomerCoupon>(coupon);
            var createdcoupon = await _custcouponRepository.InsertAsync(newcoupon);
            return ObjectMapper.Map<CustomerCoupon, CustomerCouponDto>(createdcoupon);
        }
    }
}
