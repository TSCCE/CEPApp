using Crm.CEP.Queries;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Crm.CEP.Segments
{
    public class Segment : AuditedAggregateRoot<long>
    {
        public string Name { get; set; }


        public Segment()
        {

        }




        public Query Query { get; set; }

    }

}
