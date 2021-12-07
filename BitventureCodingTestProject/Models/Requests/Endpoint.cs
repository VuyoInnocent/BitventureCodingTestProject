using Newtonsoft.Json;

namespace BitventureCodingTestProject.Models.Requests
{
    public class Endpoint
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("resource")]
        public string Resource { get; set; }

        [JsonProperty("response")]
        public Response[] Response { get; set; }

        [JsonProperty("requestBody", NullValueHandling = NullValueHandling.Ignore)]
        public string RequestBody { get; set; }
    }
}
