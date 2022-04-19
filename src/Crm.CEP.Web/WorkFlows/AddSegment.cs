using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Elsa.Attributes;
using Elsa.Services;
using Elsa.Services.Models;
using Crm.CEP.Segments;
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
using Elsa.Metadata;
using Elsa.Design;
using System.Reflection;
using Volo.Abp.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.CEP.Web.WorkFlows
{
    //this is not an activity
    [Action]
    public class AddSegment : Activity, IActivityPropertyOptionsProvider, IRuntimeSelectListItemsProvider
    {
       
        private readonly SegmentAppService _segmentRepository;
        public AddSegment(SegmentAppService segmentRepository)
        {
            _segmentRepository = segmentRepository;
        }


        public string SegmentName { get; set; }
        public string SegmentId { get; set; }

        [Obsolete]
        public object GetOptions(PropertyInfo property)
        {

            using (var scope = _segmentRepository.ServiceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<ISegmentAppService>();
                List<DropdownSegmentDto> datas = service.GetSegDropdownsAsync().Result;
                //return datas;
                if (datas == null)
                {
                    throw new EntityNotFoundException();
                }
                else
                {
                    return new RuntimeSelectListItemsProviderSettings(GetType(), new SegmentContext(datas));
                }
            }

        }




        public ValueTask<IEnumerable<SelectListItem>> GetItemsAsync(object context, CancellationToken cancellationToken = default)
        {
            var segmentContext = (SegmentContext)context!;
            var seg = segmentContext.Segments;
            //var segments = _segmentRepository.GetSegDropdownsAsync().Result;
            var segments = seg.Select(x => new SelectListItem(Name = x.Name, Id=x.Id.ToString())).ToList(); ;
            return new ValueTask<IEnumerable<SelectListItem>>(segments);
        }

        protected override IActivityExecutionResult OnExecute() => Done(SegmentId);


    }

    public record SegmentContext(List<DropdownSegmentDto> Segments);



}
