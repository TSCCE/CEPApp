using Crm.CEP.Items;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Crm.CEP
{
    public interface  IItemAppService : ICrudAppService<
            ItemDto,
            long,
            PagedAndSortedResultRequestDto,
            CreateUpdateItemDto>
    {
    }
}
