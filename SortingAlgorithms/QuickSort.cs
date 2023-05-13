using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class QuickSort
    {
        public static void Sort<T>(T[] array, IComparer<T> comparer = null)
            where T : IComparable
        {
            Sort(array, 0, array.Length - 1, comparer);
        }
        private static void Sort<T>(T[] array, int lower, int upper, IComparer<T> comparer)
            where T : IComparable
        {
            if (lower < upper)
            {
                int pi = Partition(array, lower, upper, comparer);
                Sort(array, lower, pi,comparer);
                Sort(array, pi + 1, upper, comparer);
            }
        }
        private static int Partition<T>(T[] array, int lower, int upper, IComparer<T> comparer)
            where T : IComparable
        {
            if (comparer is null) comparer = Comparer<T>.Default;
            int i = lower;
            int j = upper;

            T pivot = array[lower];
            do
            {
                while (comparer.Compare(array[i],pivot)<0) { i++; }
                while (comparer.Compare(array[j],pivot)>0) { j--; }
                if (i >= j) break;
                Sorting.Swap<T>(array, i, j);
            } while (i <= j);

            return j;
        }
    }
}
