using EZNavLib;
using EZNavLib.Interfaces;

namespace NavigationApp
{
    public class SelectIntegerPageResult : DefaultPageResult
    {
        /// <summary>
        /// The integer selected in the page yielding this result
        /// </summary>
        public int SelectedInteger
        {
            get;
            private set;
        }

        public SelectIntegerPageResult(INavigatablePage previousPage, int selectedInteger)
            : base(previousPage)
        {
            SelectedInteger = selectedInteger;
        }
    }
}
