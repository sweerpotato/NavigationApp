using System;

namespace EZNavLib.Interfaces
{
    /// <summary>
    /// Interface for an object that can navigate to a previous <see cref="INavigatablePage"/> by an instance of <see cref="Navigator"/>
    /// </summary>
    public interface ICanNavigatePrevious
    {
        /// <summary>
        /// Event raised when navigation to the previous page is desired
        /// </summary>
        event EventHandler NavigatePrevious;
    }
}
