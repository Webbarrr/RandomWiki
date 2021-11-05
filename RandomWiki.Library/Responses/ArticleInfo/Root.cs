using Newtonsoft.Json;

namespace RandomWiki.Library.Responses.ArticleInfo
{
    public class Root
    {
        [JsonProperty("batchcomplete")]
        public string Batchcomplete { get; set; }

        [JsonProperty("query")]
        public Query Query { get; set; }
    }
}