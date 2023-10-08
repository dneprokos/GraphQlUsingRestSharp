using Newtonsoft.Json;

namespace GraphQl.Countries.Client.Models.Response
{
    public class CountryDataResponseApiModel
    {
        [JsonProperty("data")]
        public Data? Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("country")]
        public CountryApiModel? Country { get; set; }
    }

    public class CountryApiModel
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("native")]
        public string? Native { get; set; }

        [JsonProperty("capital")]
        public string? Capital { get; set; }

        [JsonProperty("emoji")]
        public string? Emoji { get; set; }

        [JsonProperty("currency")]
        public string? Currency { get; set; }

        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("phone")]
        public string? Phone { get; set; }

        [JsonProperty("emojiU")]
        public string? EmojiU { get; set; }

        [JsonProperty("states")]
        public List<StateApiModel>? States { get; set; }

        [JsonProperty("languages")]
        public List<LanguageApiModel>? Languages { get; set; }

        [JsonProperty("continent")]
        public ContinentApiModel? Continent { get; set; }
    }
}
