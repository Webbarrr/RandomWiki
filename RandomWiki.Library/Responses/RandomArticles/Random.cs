using Newtonsoft.Json;

namespace RandomWiki.Library.Responses.RandomArticles
{
    public class Random
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("ns")]
        public int Ns { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}