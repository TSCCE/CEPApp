using Crm.CEP.CustomerCoupons;
using Crm.CEP.Segments;
using Elsa.Activities.Signaling.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crm.CEP.Web.Pages.Journey
{
    public class IndexModel : PageModel
    {
        private readonly CustCouponAppService _custcouponAppService;
        private readonly ISignaler _signaler;
        private readonly ISegmentAppService _segmentAppService;
        public IEnumerable<DropdownSegmentDto> DropdownSegment { get; set; }
        public IndexModel(CustCouponAppService custcouponAppService,ISignaler signaler, ISegmentAppService segmentAppService)
        {
            _segmentAppService = segmentAppService;
           _custcouponAppService =custcouponAppService;
            _signaler = signaler;
        }


        public async Task OnGetAsync()
        {
            DropdownSegment = await _segmentAppService.GetSegDropdownsAsync();


        }
    }
}
