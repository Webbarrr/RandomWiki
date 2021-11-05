using RandomWiki.WPF.Core;
using System.Windows.Input;

namespace RandomWiki.WPF.MVVM.ViewModels
{
    public abstract class ViewModelBase : PropertyChangedBase
    {
        private ICommand _homeViewCommand;
        private ICommand _historyViewCommand;
        private ICommand _aboutViewCommand;

        private ViewModelBase _currentViewModel;
        private QuotesViewModel _quotesViewModel;

        public ViewModelBase CurrentViewModel { get => _currentViewModel; set => base.SetProperty(ref _currentViewModel, value); }
        public QuotesViewModel QuotesViewModel { get => _quotesViewModel; set => base.SetProperty(ref _quotesViewModel, value); }

        private void ChangeViewModel(ViewModelBase viewModel)
        {
            this.CurrentViewModel = viewModel;
        }

        public ICommand HomeViewCommand
        {
            get
            {
                if (_homeViewCommand == null)
                {
                    _homeViewCommand = new RelayCommand(
                        p => true,
                        p => this.ChangeViewModel(new HomeViewModel()));
                }

                return _homeViewCommand;
            }
        }

        public ICommand HistoryViewCommand
        {
            get
            {
                if (_historyViewCommand == null)
                {
                    _historyViewCommand = new RelayCommand(
                        p => true,
                        p => this.ChangeViewModel(new HistoryViewModel()));
                }

                return _historyViewCommand;
            }
        }

        public ICommand AboutViewCommand
        {
            get
            {
                if (_aboutViewCommand == null)
                {
                    _aboutViewCommand = new RelayCommand(
                        p => true,
                        p => this.ChangeViewModel(new AboutViewModel()));
                }

                return _aboutViewCommand;
            }
        }
    }
}