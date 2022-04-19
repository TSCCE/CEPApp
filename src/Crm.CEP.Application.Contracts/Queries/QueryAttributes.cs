using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.CEP.Queries
{
    public class QueryAttributes
    {
        [JsonProperty("segmentMode")]
        public string SegmentMode { get; set; }
        [JsonProperty("segmentAttribute")]
        public string SegmentAttribute { get; set; }
        [JsonProperty("segmentOperation")]
        public string SegmentOperation { get; set; }
        [JsonProperty("segmentValue")]
        public string SegmentValue { get; set; }
        [JsonProperty("nextCondition")]
        public string NextCondition { get; set; }
        public string CustomerID { get; set; }
        public string TransactionID { get; set; }
        public string DOB { get; set; }
        public string InvoiceValue { get; set; }

    }
}
