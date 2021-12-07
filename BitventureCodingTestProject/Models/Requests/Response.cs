using Newtonsoft.Json;

namespace BitventureCodingTestProject.Models.Requests
{
    public class Response
    {
        [JsonProperty("element")]
        public string Element { get; set; }

        [JsonProperty("identifier", NullValueHandling = NullValueHandling.Ignore)]
        public string Identifier { get; set; }

        [JsonProperty("regex", NullValueHandling = NullValueHandling.Ignore)]
        public string Regex { get; set; }
    }
}
