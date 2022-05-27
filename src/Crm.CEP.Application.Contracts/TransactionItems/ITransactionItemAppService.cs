using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Crm.CEP.TransactionItems
{
    public interface ITransactionItemAppService : ICrudAppService<
            TransactionItemDto,
            long,
            PagedAndSortedResultRequestDto,
            CreateUpdateTransactionItemDto>
    {

    }
}
