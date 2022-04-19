using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Elsa.Attributes;
using Elsa.Services;
using Elsa.Services.Models;
using Volo.Abp.Domain.Repositories;
using Elsa.Expressions;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Elsa.ActivityResults;
using System.IO;
using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Crm.CEP.CustomerCoupons;
using Elsa.Metadata;
using System.Reflection;
using Elsa.Design;
using Crm.CEP.Segments;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Crm.CEP.Web.WorkFlows;

namespace Crm.CEP.Web.Activities
{
    //public class AssignCoupon: Activity
    //{
    //    private readonly CustCouponAppService _custcouponRepository;
    //   // public CustCouponAddViewModel CouponList { get; set; }
    //   // public CreateUpdateCustCouponDto CreatupdateList { get; set; }
    //    public AssignCoupon(CustCouponAppService custcouponRepository)
    //    {
    //        _custcouponRepository = custcouponRepository;
    //    }
    //    [ActivityInput(Label = "Select a Segment")]
    //    public long SegmentName { get; set; }

    //    [ActivityInput(Label = "Select a Coupon")]
    //    public long CouponName { get; set; }

    //protected override async ValueTask<IActivityExecutionResult> OnExecuteAsync(ActivityExecutionContext context)
    //{
    //    //CreatupdateList = ObjectMapper.Map<CustCouponAddViewModel, CreateUpdateCustCouponDto>(CouponList);
    //    CreateUpdateCustCouponDto createUpdateCustCouponDto = new CreateUpdateCustCouponDto
    //    {
    //        CustomerId = SegmentName,
    //        CouponId = CouponName
    //    };
    //    var segmentDto = await _custcouponRepository.CreateAsync(createUpdateCustCouponDto);


    //    return Done();
    //}

    // }

    [Action]
    public class AssignCoupon : Activity
    {

        //private readonly SegmentAppService _segmentRepository;
        //public AssignCoupon(SegmentAppService segmentRepository)
        //{
        //    _segmentRepository = segmentRepository;
        //}

        // [ActivityInput(
        //    UIHint = ActivityInputUIHints.Dropdown,
        //    OptionsProvider = typeof(SegmentActivity),
        //    DefaultSyntax = SyntaxNames.Literal,
        //      Hint = "Select a segment",
        //    SupportedSyntaxes = new[] { SyntaxNames.Literal, SyntaxNames.Json, SyntaxNames.JavaScript, SyntaxNames.Liquid }
        //)]

        [ActivityInput(UIHint = ActivityInputUIHints.Dropdown,
       Hint = "Select a segment",
               OptionsProvider = typeof(AddSegment)
      )]

        public string SegmentName { get; set; }

        public string SegmentId { get; set; }

        [ActivityInput(UIHint = ActivityInputUIHints.Dropdown,
       Hint = "Select a coupon",
               OptionsProvider = typeof(CouponActivity)
      )]
        public string CouponName { get; set; }

        //    [Obsolete]
        //    public object GetOptions(PropertyInfo property)
        //    {

        //        //using(var scope = _segmentRepository.GetSegDropdownsAsync())
        //        //{
        //        //    var data = scope.Result;
        //        //    return new RuntimeSelectListItemsProviderSettings(GetType(), new SegmentContext(data));

        //        //}
        //        //var data = _segmentRepository.GetSegDropdownsAsync().Result;
        //        //return new RuntimeSelectListItemsProviderSettings(GetType(), new SegmentContext(zq    1`data));
        //        using (var scope = _segmentRepository.ServiceProvider.CreateScope())
        //        {
        //            var service = scope.ServiceProvider.GetService<ISegmentAppService>();
        //            List<DropdownSegmentDto> datas = service.GetSegDropdownsAsync().Result;
        //            //return datas;
        //            if (datas == null)
        //            {
        //                throw new EntityNotFoundException();
        //            }
        //            else
        //            {
        //                return new RuntimeSelectListItemsProviderSettings(GetType(), new SegmentContext(datas));
        //            }
        //        }

        //    }



        //    public ValueTask<IEnumerable<SelectListItem>> GetItemsAsync(object context, CancellationToken cancellationToken = default)
        //    {
        //        var segmentContext = (SegmentContext)context!;
        //        var seg = segmentContext.Segments;
        //        //var segments = _segmentRepository.GetSegDropdownsAsync().Result;
        //        var segments = seg.Select(x => new SelectListItem(Name = x.Name)).ToList(); ;
        //        return new ValueTask<IEnumerable<SelectListItem>>(segments);
        //    }

        //    protected override IActivityExecutionResult OnExecute() => Done(SegmentName);


        //}

        //public record SegmentContext(List<DropdownSegmentDto> Segments);

        private readonly CustCouponAppService _custcouponRepository;
        public AssignCoupon(CustCouponAppService custcouponRepository)
        {
            _custcouponRepository = custcouponRepository;
        }
        protected override async ValueTask<IActivityExecutionResult> OnExecuteAsync(ActivityExecutionContext context)
        {
            //CreatupdateList = ObjectMapper.Map<CustCouponAddViewModel, CreateUpdateCustCouponDto>(CouponList);
            CreateUpdateCustCouponDto createUpdateCustCouponDto = new CreateUpdateCustCouponDto
            {
                CustomerId = long.Parse(SegmentName)
                //  CouponId = CouponName
            };
            var segmentDto = await _custcouponRepository.CreateAsync(createUpdateCustCouponDto);


            return Done();
        }

        public class CustCouponAddViewModel
        {
            public long CustomerId { get; set; }
            public long CouponId { get; set; }

        }
    }
}
