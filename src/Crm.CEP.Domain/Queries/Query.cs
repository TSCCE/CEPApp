using Crm.CEP.Segments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Crm.CEP.Queries
{
    public class Query : AuditedAggregateRoot<long>
    {
        
        public string JSONQueryField { get; set; }

        [ForeignKey(nameof(Segment))]
        public long SegmentId { get; set; }

        public Segment Segment { get; set; }
    }
}
