using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace RandomWiki.Library.History
{
    public class HistoryWrapper
    {
        private readonly string _callingNamespace;

        public HistoryWrapper(string callingNamespace)
        {
            _callingNamespace = callingNamespace;
        }

        public List<History> ReadIn()
        {
            var filePath = this.GetFilePath();
            var history = new List<History>();

            using (var file = File.OpenText(filePath))
            {
                var serializer = new JsonSerializer();
                history = (List<History>)serializer.Deserialize(file, typeof(List<History>));
            }

            if (history == null)
            {
                this.InitHistoryFile();
                return new List<History>();
            }

            return history;
        }

        private string GetFilePath()
        {
            var path = Utilities.AssemblyDirectory.Replace(_callingNamespace, "Library");
            return Path.Combine(path, "History", "history.json");
        }

        private void InitHistoryFile()
        {
            var filePath = this.GetFilePath();

            using (var file = File.CreateText(filePath))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, new List<History>());
            }
        }

        public void Add(History historyToAdd)
        {
            var existingHistory = this.ReadIn();

            existingHistory.Add(historyToAdd);

            var filePath = this.GetFilePath();

            using (var file = File.CreateText(filePath))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, existingHistory);
            }
        }
    }
}