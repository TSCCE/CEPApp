using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Crm.CEP.Stores
{
    public interface IStoreAppService : ICrudAppService<
            StoreDto,
            long,
            PagedAndSortedResultRequestDto,
            CreateUpdateStoreDto>
    {

    }
}
