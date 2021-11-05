using Newtonsoft.Json;
using System.Collections.Generic;

namespace RandomWiki.Library.Responses.RandomArticles
{
    public class Query
    {
        [JsonProperty("random")]
        public List<Random> Random { get; set; }
    }
}