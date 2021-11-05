using Newtonsoft.Json;
using RandomWiki.Library.Responses.ArticleInfo;
using RandomWiki.Library.Responses.RandomArticles;
using System.IO;
using System.Net;
using Random = RandomWiki.Library.Responses.RandomArticles.Random;

namespace RandomWiki.Library
{
    public class WikiWebRequest
    {
        public static RandomResponse GetRandomArticles()
        {
            // create the request
            var request = WebRequest.Create("https://en.wikipedia.org/w/api.php?action=query&list=random&rnnamespace=0&rnlimit=10&format=json");

            // get the response
            var response = request.GetResponse();

            using (var dataStream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(dataStream))
                {
                    var json = reader.ReadToEnd();

                    var root = JsonConvert.DeserializeObject<Responses.RandomArticles.Root>(json);

                    return new RandomResponse { Root = root };
                }
            }
        }

        public static ArticleResponse GetArticleUrl(Random article)
        {
            // create the request
            var request = WebRequest.Create($"https://en.wikipedia.org/w/api.php?action=query&prop=info&pageids={article.Id}&inprop=url&format=json");

            // get the response
            var response = request.GetResponse();

            using (var dataStream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(dataStream))
                {
                    // ugly string manipulation
                    var json = reader.ReadToEnd();
                    json = json.Replace($"{(char)34}{article.Id}{(char)34}", "pagedetail");

                    var root = JsonConvert.DeserializeObject<Responses.ArticleInfo.Root>(json);

                    return new ArticleResponse { Root = root };
                }
            }
        }
    }
}