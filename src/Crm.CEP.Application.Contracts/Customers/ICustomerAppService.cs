using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Crm.CEP.Customers
{
    public interface ICustomerAppService : ICrudAppService<
            CustomerDto,
            long,
            PagedAndSortedResultRequestDto,
            CreateUpdateCustomerDto>
    {
        Task<List<CustomerDto>> GetCustomerLookupAsync();
    }
}
