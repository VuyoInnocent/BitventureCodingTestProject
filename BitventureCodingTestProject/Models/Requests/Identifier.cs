using Newtonsoft.Json;

namespace BitventureCodingTestProject.Models.Requests
{
    public class Identifier
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
