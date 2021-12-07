using Newtonsoft.Json;

namespace BitventureCodingTestProject.Models.Responses
{
    public class ContentsModel
    {
        [JsonProperty("translation")]
        public string Translation { get; set; }
    }
}
