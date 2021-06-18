using EZNavLib.Interfaces;

namespace EZNavLib
{
    /// <summary>
    /// Default implementation of a page result containing a source page with a constructor
    /// </summary>
    public abstract class DefaultPageResult : INavigatablePageResult
    {
        /// <summary>
        /// The source <see cref="INavigatablePage"/> that created this result
        /// </summary>
        public INavigatablePage SourcePage
        {
            get;
            protected set;
        }

        #region Constructors

        /// <summary>
        /// Hidden constructor
        /// </summary>
        private DefaultPageResult()
        {
            
        }

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="sourcePage">The page creating this page result</param>
        public DefaultPageResult(INavigatablePage sourcePage)
        {
            SourcePage = sourcePage;
        }

        #endregion
    }
}
