using System;

namespace EZNavLib.Interfaces
{
    /// <summary>
    /// TODO: This will probably be useful for dependency injection. Make it make sense
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPageService<T> where T : INavigatablePage, new()
    {

    }
}
