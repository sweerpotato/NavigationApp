using System;
using EZNavLib.Interfaces;

namespace EZNavLib
{
    public class NavigationFinishedEventArgs : EventArgs
    {
        #region Properties and Fields

        /// <summary>
        /// Page result of the final page when the navigation finished
        /// </summary>
        public INavigatablePageResult PageResult
        {
            get;
            private set;
        } = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="pageResult">The page result of the final page</param>
        public NavigationFinishedEventArgs(INavigatablePageResult pageResult)
        {
            PageResult = pageResult ?? throw new ArgumentNullException(nameof(pageResult));
        }

        #endregion
    }
}
