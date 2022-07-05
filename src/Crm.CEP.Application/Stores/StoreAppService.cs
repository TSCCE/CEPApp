using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Crm.CEP.Stores
{
    public class StoreAppService: CrudAppService<
            Store,
            StoreDto,
            long,
            PagedAndSortedResultRequestDto,
            CreateUpdateStoreDto>,
        IStoreAppService
    {
        private readonly IRepository<Store, long> _storeRepository;
        public StoreAppService(
            IRepository<Store, long> repository)
            : base(repository)
        {
            _storeRepository = repository;
        }
        public override async Task<StoreDto> CreateAsync(CreateUpdateStoreDto store)
        {
            var newitem = ObjectMapper.Map<CreateUpdateStoreDto, Store>(store);
            var createditem = await _storeRepository.InsertAsync(newitem);
            return ObjectMapper.Map<Store, StoreDto>(createditem);
        }
    }
}
