using Newtonsoft.Json;

namespace RandomWiki.Library.Responses.ArticleInfo
{
    public class Query
    {
        [JsonProperty("pages")]
        public Pages Pages { get; set; }
    }
}