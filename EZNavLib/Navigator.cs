using System;
using System.Collections.Generic;
using EZNavLib.Interfaces;

namespace EZNavLib
{
    /// <summary>
    /// Class providing event handling for navigation between objects implementing the <see cref="INavigatablePage"/> interface
    /// </summary>
    public class Navigator : ViewModelBase
    {
        #region Properties and Fields

        /// <summary>
        /// Navigation history - used to preserve pages previously visited
        /// </summary>
        private readonly Stack<INavigatablePage> _NavigationHistory = new();

        /// <summary>
        /// The first page in the navigation sequence
        /// </summary>
        private readonly INavigatablePage _FirstPage = null;

        /// <summary>
        /// Encapsulated information about the current page sequence
        /// </summary>
        private PageSequenceInformation _CurrentPageSequenceInformation = null;

        /// <summary>
        /// Backing field for the <see cref="CurrentPage"/> property
        /// </summary>
        private INavigatablePage _CurrentPage = null;

        /// <summary>
        /// The current page in the navigation sequence
        /// </summary>
        /// <remarks>DataContext should bind to this property</remarks>
        public INavigatablePage CurrentPage
        {
            get
            {
                return _CurrentPage;
            }
            private set
            {
                SetField(ref _CurrentPage, value);
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="firstPage">The first page to display</param>
        public Navigator(INavigatablePage firstPage)
        {
            _FirstPage = firstPage ?? throw new ArgumentNullException(nameof(firstPage));

            AddEventHandlers(_FirstPage);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the current page to the page provided in the constructor
        /// </summary>
        /// <returns>The first page in the navigation sequence</returns>
        public INavigatablePage OpenFirstPage()
        {
            CurrentPage = _FirstPage;

            return CurrentPage;
        }

        /// <summary>
        /// Removes event handlers for the navigation events of <paramref name="navigatablePage"/>
        /// </summary>
        private void RemoveEventHandlers(INavigatablePage navigatablePage)
        {
            navigatablePage.CancelNavigation -= OnCancelNavigation;

            if (navigatablePage is ICanNavigateNext canNavigateNext)
            {
                canNavigateNext.NavigateNext -= OnNavigateNext;
            }

            if (navigatablePage is ICanNavigatePrevious canNavigatePrevious)
            {
                canNavigatePrevious.NavigatePrevious -= OnNavigatePrevious;
            }
        }

        /// <summary>
        /// Adds event handlers for the navigation events of <paramref name="navigatablePage"/>
        /// </summary>
        private void AddEventHandlers(INavigatablePage navigatablePage)
        {
            navigatablePage.CancelNavigation += OnCancelNavigation;

            if (navigatablePage is ICanNavigateNext canNavigateNext)
            {
                canNavigateNext.NavigateNext += OnNavigateNext;
            }

            if (navigatablePage is ICanNavigatePrevious canNavigatePrevious)
            {
                canNavigatePrevious.NavigatePrevious += OnNavigatePrevious;
            }
        }

        /// <summary>
        /// Retrieves the next <see cref="INavigatablePage"/> in the sequence, or the first page if the sequence is at its end
        /// </summary>
        /// <returns>The next <see cref="INavigatablePage"/> in the sequence</returns>
        private INavigatablePage GetNextPage()
        {
            Type nextPageType = _CurrentPageSequenceInformation.GetNextPageType();

            RemoveEventHandlers(CurrentPage);

            if (nextPageType == null)
            {
                //Navigate back to the first page
                _NavigationHistory.Clear();
                _CurrentPageSequenceInformation = null;

                AddEventHandlers(_FirstPage);

                return _FirstPage;
            }

            //TODO: Error handling would make sense here
            INavigatablePageResult previousPageResult = CurrentPage.GetPageResult();
            INavigatablePage nextPage = (INavigatablePage)Activator.CreateInstance(nextPageType);

            nextPage.Initialize(previousPageResult);

            AddEventHandlers(nextPage);

            _NavigationHistory.Push(CurrentPage);

            return nextPage;
        }

        /// <summary>
        /// Retrieves the previous <see cref="INavigatablePage"/> in the sequence
        /// </summary>
        /// <returns>The previous <see cref="INavigatablePage"/> in the sequence</returns>
        private INavigatablePage GetPreviousPage()
        {
            RemoveEventHandlers(CurrentPage);

            if (_NavigationHistory.Count == 0)
            {
                AddEventHandlers(_FirstPage);
                return _FirstPage;
            }

            if (_CurrentPageSequenceInformation != null)
            {
                _ = _CurrentPageSequenceInformation.GetPreviousPageType();
            }

            INavigatablePage previousPage = _NavigationHistory.Pop();

            AddEventHandlers(previousPage);

            return previousPage;
        }

        private INavigatablePage CancelNavigation()
        {
            _NavigationHistory.Clear();

            RemoveEventHandlers(CurrentPage);
            AddEventHandlers(_FirstPage);

            return _FirstPage;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Event handler for the <see cref="ICanNavigateNext.NavigateNext"/> event
        /// </summary>
        /// <param name="sender">The current <see cref="INavigatablePage"/></param>
        /// <param name="e"><see cref="EventArgs"/> describing the sequence of, or the next page.</param>
        private void OnNavigateNext(object sender, PageNavigatedEventArgs e)
        {
            //TODO: Some sort of error handling here for when we run out of pages
            if (_CurrentPageSequenceInformation == null ||
                !_CurrentPageSequenceInformation.IsSequence)
            {
                _CurrentPageSequenceInformation = new PageSequenceInformation(e.PageTypes);
            }

            CurrentPage = GetNextPage();
        }

        /// <summary>
        /// Event handler for the <see cref="ICanNavigatePrevious.NavigatePrevious"/> event
        /// </summary>
        private void OnNavigatePrevious(object sender, EventArgs e)
        {
            CurrentPage = GetPreviousPage();
        }

        /// <summary>
        /// Event handler for the <see cref="INavigatablePage.CancelNavigation"/> event
        /// </summary>
        private void OnCancelNavigation(object sender, EventArgs e)
        {
            CurrentPage = CancelNavigation();
        }

        #endregion
    }
}
