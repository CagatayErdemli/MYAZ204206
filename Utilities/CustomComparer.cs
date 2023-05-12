using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class CustomComparer<T> : IComparer<T>
    {
        private readonly bool _isMax;
        private readonly IComparer<T> _comparer;

        public CustomComparer(SortDirection sortDirection, IComparer<T> comparer)
        {
            _isMax = sortDirection == SortDirection.Descending;
            _comparer = comparer;
        }
        public int Compare(T? x, T? y)
        {
            return !_isMax ? compare(x, y) : compare(y, x);
        }

        private int compare(T x, T y) => _comparer.Compare(x, y);
    }
}
