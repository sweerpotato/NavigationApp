using System;

namespace EZNavLib.Interfaces
{
    /// <summary>
    /// Interface for an object that can finish the navigation done by a <see cref="Navigator"/> instance
    /// </summary>
    public interface ICanFinishNavigation
    {
        /// <summary>
        /// Event raised when the navigation is considered finished
        /// </summary>
        event EventHandler FinishNavigation;
    }
}
