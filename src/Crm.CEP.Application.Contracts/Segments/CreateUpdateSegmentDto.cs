using Crm.CEP.Segments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Crm.CEP.Segments
{
    public class CreateUpdateSegmentDto
    {

        [Required]
        [StringLength(SegmentConsts.MaxNameLength)]
        public string Name { get; set; }
    }
}
