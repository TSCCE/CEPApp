using Crm.CEP.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Crm.CEP.Transactions
{
    public class TransactionAppService:CrudAppService<Transaction,
            TransactionDto,
            long,
            PagedAndSortedResultRequestDto,
            CreateUpdateTransactionDto>
    {
    private readonly IRepository<Transaction, long> _transactionRepository;
    public TransactionAppService(IRepository<Transaction, long> repository) : base(repository)
    {
            _transactionRepository = repository;
        }
        public override async Task<TransactionDto> CreateAsync(CreateUpdateTransactionDto transaction)
        {
            var newctransaction = ObjectMapper.Map<CreateUpdateTransactionDto, Transaction>(transaction);
            var createdtransaction = await _transactionRepository.InsertAsync(newctransaction);
            return ObjectMapper.Map<Transaction, TransactionDto>(createdtransaction);
        }

        //TODO: Commented by Anoop (Swagger Gen Issue)
        /*public async Task<List<Customer>> GetTransactionLookup(Func<TransactionDto, bool> predicate)
        {
            //List<TransactionDto> transaction = Repository
            //    .Select(x => new TransactionDto { CustomerId = x.CustomerId })
            //    .Where(predicate)
            //    .ToList();

            var data = await Repository.GetQueryableAsync();

            List<TransactionDto> transaction = data
                .Select(x => new TransactionDto { CustomerId = x.CustomerId, InvoiceValue = x.InvoiceValue.ToString() })
                .Where(predicate).ToList()
                .ToList();
            //  List<TransactionDto> filteredTransactions =transaction.Select(x=> new TransactionDto { CustomerId=x.CustomerId}).ToList();
            //return transaction;
            var custid = transaction.Select(x => new CreateUpdateCustomerDto { Id = Convert.ToInt64(x.CustomerId) })                
                .ToList();
            // var tran = ObjectMapper.Map<List<Transaction>, List<TransactionDto>>(transaction);
            return ObjectMapper.Map<List<CreateUpdateCustomerDto>, List<Customer>>(custid);

        }*/


    }
}
