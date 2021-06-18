using System;

namespace EZNavLib.Interfaces
{
    /// <summary>
    /// Interface for an object that can navigate to the next <see cref="INavigatablePage"/> by an instance of <see cref="Navigator"/>
    /// </summary>
    public interface ICanNavigateNext
    {
        /// <summary>
        /// Event raised when navigation to the next page is desired
        /// </summary>
        event EventHandler<PageNavigatedEventArgs> NavigateNext;
    }
}
