using System;
using EZNavLib;
using EZNavLib.Interfaces;

namespace NavigationApp.ViewModels
{
    public class SelectIntegerViewModel : ViewModelBase, INavigatablePage, ICanNavigateNext, ICanNavigatePrevious
    {
        private string _IntegerTextBoxText = "0";

        public string IntegerTextBoxText
        {
            get
            {
                return _IntegerTextBoxText;
            }
            set
            {
                SetField(ref _IntegerTextBoxText, value);
            }
        }

        public RelayCommand<SelectIntegerViewModel> PreviousCommand
        {
            get;
            private set;
        }

        public RelayCommand<SelectIntegerViewModel> NextCommand
        {
            get;
            private set;
        }

        public SelectIntegerViewModel()
        {
            PreviousCommand = new RelayCommand<SelectIntegerViewModel>(ExecutePreviousCommand, () => true);
            NextCommand = new RelayCommand<SelectIntegerViewModel>(ExecuteNextCommand, () => true);
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
            return new SelectIntegerPageResult(this, Int32.Parse(IntegerTextBoxText));
        }

        public void Initialize(INavigatablePageResult previousPageResult = null)
        {
            //TODO: Do something here
        }

        public event EventHandler<PageNavigatedEventArgs> NavigateNext = delegate { };

        public event EventHandler NavigatePrevious = delegate { };

        public event EventHandler CancelNavigation = delegate { };
    }
}
