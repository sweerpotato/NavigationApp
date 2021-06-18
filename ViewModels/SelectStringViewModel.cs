using System;
using EZNavLib;
using EZNavLib.Interfaces;

namespace NavigationApp.ViewModels
{
    public class SelectStringViewModel : ViewModelBase, INavigatablePage
    {
        public INavigatablePageResult GetPageResult()
        {
            throw new NotImplementedException();
        }

        public void Initialize(INavigatablePageResult previousPageResult = null)
        {
            throw new NotImplementedException();
        }

        public event EventHandler<PageNavigatedEventArgs> NavigateNext = delegate { };

        public event EventHandler NavigatePrevious = delegate { };

        public event EventHandler CancelNavigation = delegate { };
    }
}
