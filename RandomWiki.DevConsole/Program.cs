using RandomWiki.Library;
using System;

namespace RandomWiki.DevConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var articles = WikiWebRequest.GetRandomArticles();

            foreach (var article in articles.Root.Query.Random)
            {
                Console.WriteLine(article.Title);
            }

            Console.ReadLine();
        }
    }
}