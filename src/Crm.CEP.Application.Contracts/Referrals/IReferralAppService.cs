using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Crm.CEP.Referrals
{
    public interface IReferralAppService : ICrudAppService<
            ReferralDto,
            long,
            PagedAndSortedResultRequestDto,
            CreateUpdateReferralDto>
    {
    }
}
