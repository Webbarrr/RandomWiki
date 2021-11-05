using Newtonsoft.Json;

namespace RandomWiki.Library.Responses.RandomArticles
{
    public class Root
    {
        [JsonProperty("batchcomplete")]
        public string Batchcomplete { get; set; }

        [JsonProperty("continue")]
        public Continue Continue { get; set; }

        [JsonProperty("query")]
        public Query Query { get; set; }
    }
}