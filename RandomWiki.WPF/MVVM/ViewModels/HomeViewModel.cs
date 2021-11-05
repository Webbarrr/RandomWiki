using RandomWiki.Library;
using RandomWiki.Library.History;
using RandomWiki.WPF.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using Random = RandomWiki.Library.Responses.RandomArticles.Random;

namespace RandomWiki.WPF.MVVM.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private ICommand _getEntriesCommand;
        private ICommand _readEntryCommand;

        private List<Random> _randomResponse;
        private bool _hasInit;
        private string _buttonContent;
        private Random _selectedResponse;

        public List<Random> RandomResponse { get => _randomResponse; set => base.SetProperty(ref _randomResponse, value); }

        public bool HasInit
        {
            get => _hasInit;
            set
            {
                base.SetProperty(ref _hasInit, value);

                if (!value)
                    return;

                this.ButtonContent = "Get more!";
            }
        }

        public string ButtonContent { get => _buttonContent; set => base.SetProperty(ref _buttonContent, value); }

        public Random SelectedResponse { get => _selectedResponse; set => base.SetProperty(ref _selectedResponse, value); }

        public HomeViewModel()
        {
            base.CurrentViewModel = this;
            base.QuotesViewModel = new QuotesViewModel();

            this.HasInit = false;
            this.ButtonContent = "Begin";
        }

        public ICommand GetEntriesCommand
        {
            get
            {
                if (_getEntriesCommand == null)
                {
                    _getEntriesCommand = new RelayCommand(
                        p => true,
                        p => this.ExecuteGetEntriesCommand());
                }

                return _getEntriesCommand;
            }
        }

        private void ExecuteGetEntriesCommand()
        {
            try
            {
                var response = WikiWebRequest.GetRandomArticles();
                this.RandomResponse = response.Root.Query.Random;
                this.HasInit = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public ICommand ReadEntryCommand
        {
            get
            {
                if (_readEntryCommand == null)
                {
                    _readEntryCommand = new RelayCommand(
                        p => true,
                        p => this.ExecuteReadEntryCommand());
                }

                return _readEntryCommand;
            }
        }

        private void ExecuteReadEntryCommand()
        {
            try
            {
                var article = WikiWebRequest.GetArticleUrl(this.SelectedResponse);
                Process.Start(article.Root.Query.Pages.PageDetail.Fullurl);

                // add to history
                var historyWrapper = new HistoryWrapper("WPF");
                historyWrapper.Add(new History { DateVisited = DateTime.Now, PageDetail = article.Root.Query.Pages.PageDetail });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}