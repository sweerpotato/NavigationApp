using System;
using EZNavLib.Interfaces;

namespace EZNavLib
{
    public class PageNavigatedEventArgs : EventArgs
    {
        #region Properties and Fields

        /// <summary>
        /// The type of pages to display, in sequence
        /// </summary>
        public Type[] PageTypes
        {
            get;
            private set;
        } = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="pageTypes">The type of pages to display, in sequence</param>
        public PageNavigatedEventArgs(params Type[] pageTypes)
        {
            Type navigatablePageType = typeof(INavigatablePage);

            foreach (Type pageType in pageTypes)
            {
                if (!navigatablePageType.IsAssignableFrom(pageType))
                {
                    throw new ArgumentException($"{pageType} does not implement INavigatablePage");
                }
            }
            
            PageTypes = pageTypes;
        }

        #endregion
    }
}
