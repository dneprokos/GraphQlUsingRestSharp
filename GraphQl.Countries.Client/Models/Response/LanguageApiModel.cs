using Newtonsoft.Json;

namespace GraphQl.Countries.Client.Models.Response
{
    public class LanguageApiModel
    {
        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("native")]
        public string? Native { get; set; }

        [JsonProperty("rtl")]
        public int? Rtl { get; set; }
    }
}
