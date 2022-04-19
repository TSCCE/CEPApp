using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Crm.CEP.Transactions
{
   public interface ITransactionAppService : ICrudAppService<
           TransactionDto,
           long,
           PagedAndSortedResultRequestDto,
           CreateUpdateTransactionDto>
    {
       
    }
}

