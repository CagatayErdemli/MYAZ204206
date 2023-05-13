using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace SortingAlgorithms
{
    public class InsertionSort
    {
        public static T[] Sort<T>(T[] arr, SortDirection sortDirection = SortDirection.Ascending,IComparer < T > compare = null)
            where T : IComparable
        {
            if (compare is null) compare = Comparer<T>.Default;
            var comparer = new CustomComparer<T>(sortDirection, compare);
            for (int i = 0; i < arr.Length-1; i++)
            {
                for (int j = i+1; j > 0; j--)
                {
                    if (comparer.Compare(arr[j], arr[j - 1]) < 0) Sorting.Swap<T>(arr, j - 1, j);
                    else break;
                }
            }
            return arr;
        }
    }
}
