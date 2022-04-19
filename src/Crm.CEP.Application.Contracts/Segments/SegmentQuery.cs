using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
namespace Crm.CEP.Segments
{
    public class SegmentQuery
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
    }
}
