using Newtonsoft.Json;

namespace RandomWiki.Library.Responses.RandomArticles
{
    public class Continue
    {
        [JsonProperty("rncontinue")]
        public string Rncontinue { get; set; }

        [JsonProperty("continue")]
        public string ContinueString { get; set; }
    }
}