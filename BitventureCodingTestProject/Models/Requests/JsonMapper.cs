using Newtonsoft.Json;

namespace BitventureCodingTestProject.Models.Requests
{
    public class JsonMapper
    {
        [JsonProperty("services")]
        public Service[] Services { get; set; }
    }
}
