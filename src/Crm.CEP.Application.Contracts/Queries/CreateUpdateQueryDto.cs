using Crm.CEP.Segments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Crm.CEP.Queries
{
    public class CreateUpdateQueryDto
    {
        public long SegmentId { get; set; }

        [Required]
        public string JSONQueryField { get; set; }
    }
}
