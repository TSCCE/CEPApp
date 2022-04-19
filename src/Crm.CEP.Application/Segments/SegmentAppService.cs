using Crm.CEP.Customers;
using Crm.CEP.Transactions;
using Crm.CEP.DBHelper;
using Crm.CEP.Helpers;
using Crm.CEP.Queries;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;


namespace Crm.CEP.Segments
{
    //TODO : Permission needs to be added
    public class SegmentAppService :
        CrudAppService<
            Segment,
            SegmentDto,
            long,
            PagedAndSortedResultRequestDto,
            CreateUpdateSegmentDto>,
        ISegmentAppService
    {

        private readonly IRepository<Segment, long> _segmentRepository;
        private readonly CustomerAppService _customerRepository;
        //private readonly TransactionAppService _transactionRepository;
        public SegmentAppService(
            IRepository<Segment, long> repository, CustomerAppService custrepository)
            : base(repository)
        {
            _segmentRepository = repository;
            _customerRepository = custrepository;
           // _transactionRepository = transactionrepo;
        }



        public async Task<PagedResultDto<SegmentDto>> FilterSegment(FilterSegmentDto input)
        {
            //Get Segments with filters
            List<Segment> segments = await Repository.GetListAsync();

            if (input.segmentText != null)
                segments = segments.Where(x => x.Name.Contains(input.segmentText)).ToList();

            segments = segments.Where(x => x.CreationTime >= input.startDate && x.CreationTime <= input.endDate).ToList();

            var segmentDtos = segments.Select(x =>
            {
                var segmentDto = ObjectMapper.Map<Segment, SegmentDto>(x);
                return segmentDto;
            }).ToList();
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<SegmentDto>(
                totalCount,
                segmentDtos);

        }



        public async Task<GetSegmentQueryDto> GetSegmentQuery(long id)
        {
            var data = await Repository.WithDetailsAsync(x => x.Query);

            var segmentQuery = data
                 .Where(x => x.Id == id)
                 .FirstOrDefault();

            var json = segmentQuery.Query.JSONQueryField;

            var seg = JsonConvert.DeserializeObject<IList<SegmentQuery>>(json);

            var segmentQueryDtos = seg.Select(x =>
            {
                var segmentQueryDto = ObjectMapper.Map<SegmentQuery, SegmentQueryDto>(x);
                segmentQueryDto.Id = id;
                return segmentQueryDto;
            }).ToList();
            var totalCount = await Repository.GetCountAsync();


            return new GetSegmentQueryDto
            {
                Name = segmentQuery.Name,
                Segments = segmentQueryDtos
            };
        }



        public async Task<List<Customer>> GetParsedSegmentQuery(long id)
        {
            List<Customer> custid = new List<Customer>();
            
            var rdata = await Repository.WithDetailsAsync(x => x.Query);

                        var segmentQuery = rdata
                 .Where(x => x.Id == id)
                 .FirstOrDefault();

            var strquery = segmentQuery.Query.JSONQueryField;

            var json = JsonConvert.DeserializeObject(strquery);
            JsonReader reader = new JsonTextReader(new StringReader(json.ToString()));
            var token = JToken.Load(reader);

            var nextCondition = token.ToObject<List<QueryAttributes>>();

            var jsonExpressionParser = new SegmentParseDBHelper();
            //var nextCondition = json.ToObject<IList<QueryAttributes>>();
            var jsonDocument = JsonDocument.Parse(strquery);
            foreach (var obj in nextCondition)
            {
                if (obj.SegmentMode == "Customer")
                {
                    var predicate = jsonExpressionParser
                                        .ParsePredicateOf<Customer>(obj);
                    List<Customer> data = await _customerRepository.GetCustomerLookupAsync();

                    var filteredTransactions = data.Where(predicate).ToList();
                    
                    custid.AddRange(filteredTransactions);
                }
                else
                {
                    if (obj.SegmentMode == "Transactions")
                    {
                        var predicate = jsonExpressionParser
                                            .ParsePredicateOf<TransactionDto>(obj);
                        //ObjectMapper.Map<List<TransactionDto>, List<Customer>>(filteredTransactions);
                        //List<Customer> data = _transactionRepository.GetTransactionLookup(predicate);
                        // var filteredTransactions = data.Where(predicate).ToList();
                        List<Customer> data = new List<Customer>();
                         custid.AddRange(data);
                        var test = data;
                    }
                    
                }
                //  var predicate = jsonExpressionParser
                //  .ParsePredicateOf<QueryAttributes>(jsonDocument);
                // .ParsePredicateOf<Customer>(jsonDocument);
            }
            //var predicate = jsonExpressionParser
            // .ParsePredicateOf<QueryAttributes>(jsonDocument);
            //List<Customer> data = await _customerRepository.GetCustomerLookupAsync();
            //var query = data.Select(x =>
            //{
            //    var queryattr = ObjectMapper.Map<Customer, QueryAttributes>(x);
            //    return queryattr;
            //}).ToList();
            //var filteredTransactions = query.Where(predicate).ToList();
            //List<CustomerDto> custdto = ObjectMapper.Map<List<Customer>, List<CustomerDto>>(custid);
            return custid;
        }

        public override async Task<SegmentDto> GetAsync(long id)
        {
            var data = await Repository.WithDetailsAsync(x => x.Query);

            var segment = data
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (segment == null)
                throw new EntityNotFoundException(typeof(Segment), id);

            var segmentDto = ObjectMapper.Map<Segment, SegmentDto>(segment);

            return segmentDto;
        }


        public override async Task<PagedResultDto<SegmentDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var data = await Repository.WithDetailsAsync(x => x.Query);

            //Get Segments with filters
            List<Segment> segments = data
                 .OrderBy(AppHelper.NormalizeSorting(input.Sorting))
                 .Skip(input.SkipCount)
                 .Take(input.MaxResultCount)
                 .ToList();

            //Convert to Dto's
            var segmentDtos = segments.Select(x =>
            {
                var segmentDto = ObjectMapper.Map<Segment, SegmentDto>(x);
                return segmentDto;
            }).ToList();

            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<SegmentDto>(
                totalCount,
                segmentDtos);
        }
        public async Task<ListResultDto<SegmentDto>> GetSegmentLookupAsync()
        {
            List<Segment> segments = await Repository.GetListAsync();


            return new ListResultDto<SegmentDto>(ObjectMapper.Map<List<Segment>, List<SegmentDto>>(segments));


        }
        public async Task<List<DropdownSegmentDto>> GetSegDropdownsAsync()
        {
            var data = await Repository.GetQueryableAsync();

            List<SegmentDto> segments = data
                .OrderBy(x => x.Name)
                .Select(x => new SegmentDto { Name = x.Name, Id = x.Id })
                .ToList();


            var SegDropdownDtos = segments.Select(x =>
            {
                var segmentDto = ObjectMapper.Map<SegmentDto, DropdownSegmentDto>(x);
                return segmentDto;
            }).ToList();

            return SegDropdownDtos;
        }
        //public override async Task<SegmentDto> CreateAsync(CreateUpdateSegmentDto input)
        //{
        //    var segmentCheck = await Repository.AnyAsync(x =>
        //    x.Name.Trim().ToLower() == input.Name.Trim().ToLower());

        //    if (segmentCheck)
        //        throw new SegmentAlreadyExistsException(input.Name);

        //    var segment = ObjectMapper.Map<CreateUpdateSegmentDto, Segment>(input);

        //    await Repository.InsertAsync(segment);

        //    var segmentDto = ObjectMapper.Map<Segment, SegmentDto>(segment);

        //    return segmentDto;
        //}

    }

}
