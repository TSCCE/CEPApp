using Crm.CEP.CustomerCoupons;
using Elsa.Activities.Signaling.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Crm.CEP.Web.WorkFlowSignal
{
    public class WorkFlowSignalController : Controller
    {
        private readonly CustCouponAppService _custcouponAppService;
        private readonly ISignaler _signaler;
        public WorkFlowSignalController(CustCouponAppService custcouponAppService, ISignaler signaler)
        {
            _custcouponAppService = custcouponAppService;
            _signaler = signaler;
        }
        public async Task JourneyMap(string Test)
        {
            //  await _signaler.TriggerSignalAsync(signal: "AssignCoupon");
            await _signaler.TriggerSignalAsync(signal: Test);
        }
    }
}
