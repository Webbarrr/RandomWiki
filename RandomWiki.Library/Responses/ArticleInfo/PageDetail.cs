using Newtonsoft.Json;
using System;

namespace RandomWiki.Library.Responses.ArticleInfo
{
    public class PageDetail
    {
        [JsonProperty("pageid")]
        public int Pageid { get; set; }

        [JsonProperty("ns")]
        public int Ns { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("contentmodel")]
        public string Contentmodel { get; set; }

        [JsonProperty("pagelanguage")]
        public string Pagelanguage { get; set; }

        [JsonProperty("pagelanguagehtmlcode")]
        public string Pagelanguagehtmlcode { get; set; }

        [JsonProperty("pagelanguagedir")]
        public string Pagelanguagedir { get; set; }

        [JsonProperty("touched")]
        public DateTime Touched { get; set; }

        [JsonProperty("lastrevid")]
        public int Lastrevid { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("fullurl")]
        public string Fullurl { get; set; }

        [JsonProperty("editurl")]
        public string Editurl { get; set; }

        [JsonProperty("canonicalurl")]
        public string Canonicalurl { get; set; }
    }
}