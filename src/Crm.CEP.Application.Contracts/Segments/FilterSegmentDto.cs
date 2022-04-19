using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.CEP.Segments
{
    public class FilterSegmentDto
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string segmentText { get; set; }
    }
}
