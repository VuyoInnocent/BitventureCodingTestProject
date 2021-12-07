using Newtonsoft.Json;

namespace BitventureCodingTestProject.Models.Responses
{
    public class ResponseJsonModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("director")]
        public string Director { get; set; }

        [JsonProperty("contents")]
        public ContentsModel Contents { get; set; }

        [JsonProperty("geoPlugin")]
        public GeoPluginModel GeoPlugin { get; set; }
    }
}
