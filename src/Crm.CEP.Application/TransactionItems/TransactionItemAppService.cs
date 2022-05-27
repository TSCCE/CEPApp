using Crm.CEP.TransactionItems;
using Crm.CEP.TransactionsItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Crm.CEP
{
    public class TransactionItemAppService : CrudAppService<
             TransactionItem,
             TransactionItemDto,
             long,
             PagedAndSortedResultRequestDto,
             CreateUpdateTransactionItemDto>,
        ITransactionItemAppService
    {
        private readonly IRepository<TransactionItem, long> _transitemRepository;
        public TransactionItemAppService(IRepository<TransactionItem, long> trepository) : base(trepository)
        {
            _transitemRepository = trepository;
        }
      
    }
}
