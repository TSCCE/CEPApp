using Crm.CEP.CustomerCoupons;
using Crm.CEP.Segments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Crm.CEP.Coupons
{
    public class CouponAppService : CrudAppService<
            Coupon,
            CouponDto,
            long,
            PagedAndSortedResultRequestDto,
            CreateUpdateCouponDto>, ICouponAppService
    {
        private readonly IRepository<Coupon, long> _couponRepository;
        private readonly IRepository<CustomerCoupon> _custcouponRepository;
        public CouponAppService(IRepository<Coupon, long> repository, IRepository<CustomerCoupon> custcouponRepository) : base(repository)
        {
            _couponRepository = repository;
            _custcouponRepository = custcouponRepository;
        }
        public override async Task<CouponDto> CreateAsync(CreateUpdateCouponDto coupon)
        {
            var newcoupon = ObjectMapper.Map<CreateUpdateCouponDto, Coupon>(coupon);
            var createdcoupon = await _couponRepository.InsertAsync(newcoupon);
            return ObjectMapper.Map<Coupon,CouponDto>(createdcoupon);
        }
      
        public override async Task<CouponDto> GetAsync(long id)
        {
            var coupon = await Repository.GetAsync(id);

            if (coupon == null)
                throw new EntityNotFoundException(typeof(Coupon), id);

            var couponDto = ObjectMapper.Map<Coupon, CouponDto>(coupon);

            return couponDto;
        }
        //public async Task MapCustomercoupon(CustomerCouponDto customerCoupon)
        //{
        //    var coupon = ObjectMapper.Map<CustomerCouponDto, CustomerCoupon>(customerCoupon);
        //    var c = coupon;
        //    await _custcouponRepository.InsertAsync(coupon);
        //}


        public async Task<List<DropdownCouponDto>> GetCoupDropdownsAsync()
        {
            var data = await Repository.GetQueryableAsync();

            List<CouponDto> coupons = data
                .OrderBy(x => x.Name)
                .Select(x => new CouponDto { Name = x.Name, Id = x.Id })
                .ToList();

            var DropdownCouponDtos = coupons.Select(x =>
            {
                var couponDto = ObjectMapper.Map<CouponDto, DropdownCouponDto>(x);
                return couponDto;
            }).ToList();

            return DropdownCouponDtos;
        }

    }
    }
