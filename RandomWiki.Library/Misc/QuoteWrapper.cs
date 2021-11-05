using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace RandomWiki.Library.Misc
{
    public class QuoteWrapper
    {
        public static List<string> GetQuotes(string callingNamespace)
        {
            var filePath = GetFilePath(callingNamespace);

            using (var file = File.OpenText(filePath))
            {
                var serializer = new JsonSerializer();
                return (List<string>)serializer.Deserialize(file, typeof(List<string>));
            }
        }

        private static string GetFilePath(string callingNamespace)
        {
            var path = Utilities.AssemblyDirectory.Replace(callingNamespace, "Library");
            return Path.Combine(path, "Misc", "quotes.json");
        }
    }
}