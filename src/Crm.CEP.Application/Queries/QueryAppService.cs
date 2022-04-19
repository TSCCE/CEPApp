using Crm.CEP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Crm.CEP.Queries
{
    public class QueryAppService : 
        CrudAppService<
            Query,
            QueryDto,
            long,
            PagedAndSortedResultRequestDto,
            CreateUpdateQueryDto>
    {
        public QueryAppService(
            IRepository<Query, long> repository) 
            : base(repository)
        {
        }

        public override async Task<QueryDto> GetAsync(long id)
        {
            var query = await Repository.GetAsync(id);

            if (query == null)
                throw new EntityNotFoundException(typeof(Query), id);

            var queryDto = ObjectMapper.Map<Query, QueryDto>(query);

            return queryDto;
        }

        public override async Task<PagedResultDto<QueryDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Get Query with filters

            var data = await Repository.WithDetailsAsync(x => x.Segment);

            List<Query> queries = data
                 .OrderBy(AppHelper.NormalizeSorting(input.Sorting))
                 .Skip(input.SkipCount)
                 .Take(input.MaxResultCount)
                 .ToList();

            //Convert to Dto's
            var queryDtos = queries.Select(x =>
            {
                var queryDto = ObjectMapper.Map<Query, QueryDto>(x);
                queryDto.SegmentName = x.Segment.Name;
                return queryDto;
            }).ToList();

            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<QueryDto>(
                totalCount,
                queryDtos);
        }
    }
}
