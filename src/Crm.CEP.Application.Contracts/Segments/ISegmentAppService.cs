using Crm.CEP.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Crm.CEP.Segments
{
    public interface ISegmentAppService :
        ICrudAppService<
            SegmentDto,
            long,
            PagedAndSortedResultRequestDto,
            CreateUpdateSegmentDto>
    {
        Task<PagedResultDto<SegmentDto>> FilterSegment(FilterSegmentDto text);

        Task<GetSegmentQueryDto> GetSegmentQuery(long id);

        Task<List<DropdownSegmentDto>> GetSegDropdownsAsync();

    }
}