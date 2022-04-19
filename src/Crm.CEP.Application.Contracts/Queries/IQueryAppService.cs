using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Crm.CEP.Queries
{
    public interface IQueryAppService : 
        ICrudAppService<
            QueryDto,
            long,
            PagedAndSortedResultRequestDto,
            CreateUpdateQueryDto>
    {
    }
}
