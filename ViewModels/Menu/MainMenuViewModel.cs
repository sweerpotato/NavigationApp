using System;
using EZNavLib;
using EZNavLib.Interfaces;

namespace NavigationApp.ViewModels
{
    public class MainMenuViewModel : ViewModelBase, INavigatablePage, ICanNavigateNext
    {
        #region Properties and Fields

        public RelayCommand<MainMenuViewModel> SelectBoolAndIntegerCommand
        {
            get;
            private set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        public MainMenuViewModel()
        {
            SelectBoolAndIntegerCommand = new RelayCommand<MainMenuViewModel>(ExecuteSelectBoolAndIntegerCommand, () => true);
        }

        #endregion

        #region Methods

        public void ExecuteSelectBoolAndIntegerCommand()
        {
            NavigateNext(this, new PageNavigatedEventArgs(typeof(SelectBoolViewModel), typeof(SelectIntegerViewModel)));
        }

        #endregion

        #region Interface implementation

        public void Initialize(INavigatablePageResult previousPageResult = null)
        {
            
        }

        public INavigatablePageResult GetPageResult()
        {
            return new EmptyPageResult();
        }

        public event EventHandler<PageNavigatedEventArgs> NavigateNext = delegate { };

        public event EventHandler CancelNavigation = delegate { };

        #endregion
    }
}
