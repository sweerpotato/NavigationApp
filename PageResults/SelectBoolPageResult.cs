using EZNavLib;
using EZNavLib.Interfaces;

namespace NavigationApp
{
    public class SelectBoolPageResult : DefaultPageResult
    {
        /// <summary>
        /// Boolean value indicating if the checkbox was checked or not
        /// </summary>
        public bool WasChecked
        {
            get;
            private set;
        }

        public SelectBoolPageResult(INavigatablePage sourcePage, bool wasChecked)
            : base(sourcePage)
        {
            WasChecked = wasChecked;
        }
    }
}
