using Newtonsoft.Json;

namespace BitventureCodingTestProject.Models.Responses
{
    public class GeoPluginModel
    {
        [JsonProperty("geoplugin_request")]
        public string GeopluginRequest { get; set; }

        [JsonProperty("geoplugin_city")]
        public string GeopluginCity { get; set; }

    }
}
