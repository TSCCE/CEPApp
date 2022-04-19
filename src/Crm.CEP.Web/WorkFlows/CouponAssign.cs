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

namespace Crm.CEP.Web.WorkFlows
{
    public class CouponAssign : Activity
    {
        private readonly CustCouponAppService _custcouponRepository;
        public CouponAssign(CustCouponAppService custcouponRepository)
        {
            _custcouponRepository = custcouponRepository;
        }
        protected override async ValueTask<IActivityExecutionResult> OnExecuteAsync(ActivityExecutionContext context)
        {
            //CreatupdateList = ObjectMapper.Map<CustCouponAddViewModel, CreateUpdateCustCouponDto>(CouponList);
            CreateUpdateCustCouponDto createUpdateCustCouponDto = new CreateUpdateCustCouponDto
            {
                //CustomerId = SegmentName,
              //  CouponId = CouponName
            };
            var segmentDto = await _custcouponRepository.CreateAsync(createUpdateCustCouponDto);


            return Done();
        }
    }
}
