using Newtonsoft.Json;

namespace GraphQl.Countries.Client.Models.Response
{
    public class LanguagesApiModel
    {
        [JsonProperty("languages")]
        public List<LanguageApiModel>? Languages { get; set; }
    }
}
