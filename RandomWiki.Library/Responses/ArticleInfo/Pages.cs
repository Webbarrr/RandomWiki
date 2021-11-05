using Newtonsoft.Json;

namespace RandomWiki.Library.Responses.ArticleInfo
{
    public class Pages
    {
        [JsonProperty("pagedetail")]
        public PageDetail PageDetail { get; set; }
    }
}