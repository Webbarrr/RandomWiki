using RandomWiki.Library.History;
using System.Collections.Generic;

namespace RandomWiki.WPF.MVVM.ViewModels
{
    public class HistoryViewModel : ViewModelBase
    {
        private List<History> _history;

        public List<History> History { get => _history; set => base.SetProperty(ref _history, value); }

        public HistoryViewModel()
        {
            var historyReader = new HistoryWrapper("WPF");
            this.History = historyReader.ReadIn();
        }
    }
}