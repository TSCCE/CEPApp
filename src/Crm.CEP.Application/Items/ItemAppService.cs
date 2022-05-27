using Crm.CEP.Items;
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
    public class ItemAppService : CrudAppService<
            Item,
            ItemDto,
            long,
            PagedAndSortedResultRequestDto,
            CreateUpdateItemDto>,
        IItemAppService
    {
        private readonly IRepository<Item, long> _itemRepository;
        private readonly IRepository<TransactionsItems.TransactionItem> _transItemRepository;

        public ItemAppService(IRepository<Item, long> repository, IRepository<TransactionsItems.TransactionItem> transitemRepository) : base(repository)
        {
            _itemRepository = repository;
            _transItemRepository = transitemRepository;
        }
        public override async Task<ItemDto> CreateAsync(CreateUpdateItemDto item)
        {
            var newitem = ObjectMapper.Map<CreateUpdateItemDto, Item>(item);
            var createditem = await _itemRepository.InsertAsync(newitem);
            return ObjectMapper.Map<Item, ItemDto>(createditem);
        }

    }
}
