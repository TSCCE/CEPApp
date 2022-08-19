using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Crm.CEP.Customers
{
    [Authorize]
    public class CustomerAppService : CrudAppService<Customer,
            CustomerDto,
            long,
            PagedAndSortedResultRequestDto,
            CreateUpdateCustomerDto>
    {
        private readonly IRepository<Customer, long> _customerRepository;
        public CustomerAppService(IRepository<Customer, long> repository) : base(repository)
        {
            _customerRepository = repository;
        }
         
        public override async Task<CustomerDto> CreateAsync(CreateUpdateCustomerDto customer)
        {
            var newcustomer = ObjectMapper.Map<CreateUpdateCustomerDto, Customer>(customer);
            var createdcustomer = await _customerRepository.InsertAsync(newcustomer);
            return ObjectMapper.Map<Customer, CustomerDto>(createdcustomer);
        }
        public async Task<List<Customer>> GetCustomerLookupAsync()
        {
            List<Customer> customer = await Repository.GetListAsync();

            return customer;

            //return CustomerDto(ObjectMapper.Map<List<Customer>, List<CustomerDto>>(customer));


        }
    }
}
