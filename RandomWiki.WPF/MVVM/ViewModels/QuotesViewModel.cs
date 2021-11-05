using RandomWiki.Library.Misc;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RandomWiki.WPF.MVVM.ViewModels
{
    public class QuotesViewModel : ViewModelBase
    {
        private List<String> _quotes;

        private string _activeQuote;

        public string ActiveQuote { get => _activeQuote; set => base.SetProperty(ref _activeQuote, value); }

        public QuotesViewModel()
        {
            _quotes = QuoteWrapper.GetQuotes("WPF");

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */

                var random = new Random();

                while (true)
                {
                    var n = random.Next(_quotes.Count);
                    this.ActiveQuote = _quotes[n];
                    Thread.Sleep(10000);
                }
            }).Start();
        }
    }
}