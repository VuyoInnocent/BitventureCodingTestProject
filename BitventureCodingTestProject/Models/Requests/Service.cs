using Newtonsoft.Json;

namespace BitventureCodingTestProject.Models.Requests
{
    public class Service
    {
        [JsonProperty("baseURL")]
        public string BaseUrl { get; set; }

        [JsonProperty("datatype")]
        public string Datatype { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("endpoints")]
        public Endpoint[] Endpoints { get; set; }

        [JsonProperty("identifiers")]
        public Identifier[] Identifiers { get; set; }
    }
}
