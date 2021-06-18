using System;
using EZNavLib;
using EZNavLib.Interfaces;

namespace NavigationApp.ViewModels
{
    public class SelectBoolViewModel : ViewModelBase, INavigatablePage, ICanNavigateNext, ICanNavigatePrevious
    {
        private bool _IsChecked = false;

        public bool IsChecked
        {
            get
            {
                return _IsChecked;
            }
            set
            {
                SetField(ref _IsChecked, value);
            }
        }

        public RelayCommand<SelectBoolViewModel> PreviousCommand
        {
            get;
            private set;
        }

        public RelayCommand<SelectBoolViewModel> NextCommand
        {
            get;
            private set;
        }

        public SelectBoolViewModel()
        {
            PreviousCommand = new RelayCommand<SelectBoolViewModel>(ExecutePreviousCommand, () => true);
            NextCommand = new RelayCommand<SelectBoolViewModel>(ExecuteNextCommand, () => true);
        }

        public void ExecutePreviousCommand()
        {
            NavigatePrevious(this, EventArgs.Empty);
        }

        public void ExecuteNextCommand()
        {
            NavigateNext(this, new PageNavigatedEventArgs());
        }

        public INavigatablePageResult GetPageResult()
        {
            return new SelectBoolPageResult(this, IsChecked);
        }

        public void Initialize(INavigatablePageResult previousPageResult = null)
        {
            
        }

        public event EventHandler<PageNavigatedEventArgs> NavigateNext = delegate { };

        public event EventHandler NavigatePrevious = delegate { };

        public event EventHandler CancelNavigation = delegate { };
    }
}
