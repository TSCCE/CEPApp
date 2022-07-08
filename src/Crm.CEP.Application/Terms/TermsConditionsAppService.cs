using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Crm.CEP.Terms
{
    public class TermsConditionsAppService : CrudAppService<TermsConditions,
            TermsDto,
            long,
            PagedAndSortedResultRequestDto,
            CreateUpdateTermsDto>
    {
        private readonly IRepository<TermsConditions, long> _termsRepository;

        public TermsConditionsAppService(IRepository<TermsConditions, long> repository) : base(repository)
        {
            _termsRepository = repository;
        }
        public override async Task<TermsDto> CreateAsync(CreateUpdateTermsDto referral)
        {
            var newref = ObjectMapper.Map<CreateUpdateTermsDto, TermsConditions>(referral);
            var createdref = await _termsRepository.InsertAsync(newref);
            return ObjectMapper.Map<TermsConditions, TermsDto>(createdref);
        }
    }
}
