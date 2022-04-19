using Crm.CEP.Segments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.ObjectMapping;

namespace Crm.CEP.Web.Pages.Segment
{
    public class EditSegmentModel : CEPPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public long Id { get; set; }

        [BindProperty]


        public CreateUpdateSegmentQueryDto Segment { get; set; }

        private readonly ISegmentAppService _segmentAppService;



        public EditSegmentModel(ISegmentAppService segmentAppService)
        {
            _segmentAppService = segmentAppService;
        }

        public async Task OnGetAsync(long Id)
        {
            //var segmentDto = await _segmentAppService.GetAsync(Id);
            var data = await _segmentAppService.GetSegmentQuery(Id);
            Segment = ObjectMapper.Map<GetSegmentQueryDto, CreateUpdateSegmentQueryDto>(data);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            //await _segmentAppService.UpdateAsync(Id, Segment);
            return NoContent();
        }

        //public async Task OnGetAsync()
        //{
        //    var queryDto = await _queryAppService.GetAsync(Id);
        //    Query = ObjectMapper.Map<QueryDto, CreateUpdateQueryDto>(queryDto);
        //}
    }
}
