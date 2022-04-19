using Crm.CEP.Coupons;
using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Design;
using Elsa.Metadata;
using Elsa.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Crm.CEP.Web.WorkFlows
{

    [Action]
    public class CouponActivity : Activity, IActivityPropertyOptionsProvider, IRuntimeSelectListItemsProvider
    {

        private readonly CouponAppService _couponRepository;
        public CouponActivity(CouponAppService couponRepository)
        {
            _couponRepository = couponRepository;
        }

        // [ActivityInput(
        //    UIHint = ActivityInputUIHints.Dropdown,
        //    OptionsProvider = typeof(SegmentActivity),
        //    DefaultSyntax = SyntaxNames.Literal,
        //      Hint = "Select a segment",
        //    SupportedSyntaxes = new[] { SyntaxNames.Literal, SyntaxNames.Json, SyntaxNames.JavaScript, SyntaxNames.Liquid }
        //)]

        public string CouponName { get; set; }

        [Obsolete]
        public object GetOptions(PropertyInfo property)
        {

            //using(var scope = _segmentRepository.GetSegDropdownsAsync())
            //{
            //    var data = scope.Result;
            //    return new RuntimeSelectListItemsProviderSettings(GetType(), new SegmentContext(data));

            //}
            //var data = _segmentRepository.GetSegDropdownsAsync().Result;
            //return new RuntimeSelectListItemsProviderSettings(GetType(), new SegmentContext(zq    1`data));
            using (var scope = _couponRepository.ServiceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<ICouponAppService>();
                List<DropdownCouponDto> datas = service.GetCoupDropdownsAsync().Result;
                //return datas;
                return new RuntimeSelectListItemsProviderSettings(GetType(), new CouponContext(datas));
            }

        }
        



        public ValueTask<IEnumerable<SelectListItem>> GetItemsAsync(object context, CancellationToken cancellationToken = default)
        {
            var couponContext = (CouponContext)context!;
            var coup = couponContext.Coupons;
            //var segments = _segmentRepository.GetSegDropdownsAsync().Result;
            var coupons = coup.Select(x => new SelectListItem(Name = x.Name)).ToList(); ;
            return new ValueTask<IEnumerable<SelectListItem>>(coupons);
        }

        protected override IActivityExecutionResult OnExecute() => Done(CouponName);


    }

    public record CouponContext(List<DropdownCouponDto> Coupons);










  

}
