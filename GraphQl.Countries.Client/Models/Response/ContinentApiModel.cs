using Newtonsoft.Json;

namespace GraphQl.Countries.Client.Models.Response
{
    public class ContinentApiModel
    {
        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
