using System;
using System.Collections.Generic;

namespace EZNavLib
{
    /// <summary>
    /// Information describing a sequence of page types
    /// </summary>
    internal class PageSequenceInformation
    {
        #region Properties and Fields

        /// <summary>
        /// List of the types of a specific page sequence, in order
        /// </summary>
        public List<Type> PageSequenceTypes
        {
            get;
            private set;
        }

        /// <summary>
        /// Current page index
        /// </summary>
        private int _CurrentPageIndex = 0;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="pageSequenceTypes">The page types, in sequence</param>
        public PageSequenceInformation(Type[] pageSequenceTypes)
        {
            if (pageSequenceTypes == null)
            {
                throw new ArgumentNullException(nameof(pageSequenceTypes));
            }
            else if (pageSequenceTypes.Length == 0)
            {
                throw new ArgumentException($"pageSequenceTypes must contain at least one element");
            }

            PageSequenceTypes = new List<Type>(pageSequenceTypes);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Retrieves the next page <see cref="Type"/>. Returns null if the sequence is at its end
        /// </summary>
        /// <returns>The <see cref="Type"/> of the next page, or null if the sequence is at its end</returns>
        public Type GetNextPageType()
        {
            if (_CurrentPageIndex == PageSequenceTypes.Count)
            {
                return null;
            }

            Type returnType = PageSequenceTypes[_CurrentPageIndex];

            if (_CurrentPageIndex != PageSequenceTypes.Count)
            {
                ++_CurrentPageIndex;
            }

            return returnType;
        }

        /// <summary>
        /// Retrieves the previous page <see cref="Type"/>. Returns null if the sequence is at its beginning
        /// </summary>
        /// <returns>The <see cref="Type"/> of the previous page, or null if the sequence is at its beginning</returns>
        /// <remarks>This method is more or less symbolic - its real purpose is to decrement the index</remarks>
        public Type GetPreviousPageType()
        {
            if (_CurrentPageIndex == 0)
            {
                return null;
            }

            if (_CurrentPageIndex > 0)
            {
                --_CurrentPageIndex;
            }

            Type returnType = PageSequenceTypes[_CurrentPageIndex];

            return returnType;
        }

        #endregion
    }
}
