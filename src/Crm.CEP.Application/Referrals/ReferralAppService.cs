using Crm.CEP.Referrals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Crm.CEP.Referrals
{
    public class ReferralAppService : CrudAppService<Referral,
            ReferralDto,
            long,
            PagedAndSortedResultRequestDto,
            CreateUpdateReferralDto>
    {
        private readonly IRepository<Referral, long> _referralRepository;
        public ReferralAppService(IRepository<Referral, long> repository) : base(repository)
        {
            _referralRepository = repository;
        }


        public override async Task<ReferralDto> CreateAsync(CreateUpdateReferralDto referral)
        {
            var newref = ObjectMapper.Map<CreateUpdateReferralDto, Referral>(referral);
            var createdref = await _referralRepository.InsertAsync(newref);
            return ObjectMapper.Map<Referral, ReferralDto>(createdref);
        }

    }
}
