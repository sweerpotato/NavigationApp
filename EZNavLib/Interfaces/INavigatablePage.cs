using System;

namespace EZNavLib.Interfaces
{
    /// <summary>
    /// Interface describing a page which can be navigated to and from by an instance of <see cref="Navigator"/>
    /// </summary>
    public interface INavigatablePage
    {
        /// <summary>
        /// Method invoked directly after construction
        /// </summary>
        void Initialize(INavigatablePageResult previousPageResult = null);

        /// <summary>
        /// Method retrieving a page result
        /// </summary>
        /// <returns>The page result from this page, if any</returns>
        INavigatablePageResult GetPageResult();

        /// <summary>
        /// Event raised when navigation to the first page is desired
        /// </summary>
        event EventHandler CancelNavigation;
    }
}
