namespace EZNavLib.Interfaces
{
    /// <summary>
    /// Interface for page results for "communication" between <see cref="INavigatablePage"/>s
    /// </summary>
    public interface INavigatablePageResult
    {
        /// <summary>
        /// The source page the <see cref="INavigatablePageResult"/> originates from
        /// </summary>
        INavigatablePage SourcePage
        {
            get;
        }
    }
}
