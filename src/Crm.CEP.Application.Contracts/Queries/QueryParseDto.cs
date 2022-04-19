using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.CEP.Queries
{
    public class QueryParseDto
    {
        public string segmentMode { get; set; }
        public string segmentAttribute { get; set; }
        public string segmentOperation { get; set; }
        public string segmentValue { get; set; }
        public string nextCondition { get; set; }
    }
}
