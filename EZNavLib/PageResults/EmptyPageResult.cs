using EZNavLib.Interfaces;

namespace EZNavLib
{
    /// <summary>
    /// A <see cref="INavigatablePageResult"/> describing an empty result without a source page
    /// </summary>
    public class EmptyPageResult : INavigatablePageResult
    {
        /// <summary>
        /// The source page - always null
        /// </summary>
        public INavigatablePage SourcePage
        {
            get
            {
                return null;
            }
        }
    }
}
