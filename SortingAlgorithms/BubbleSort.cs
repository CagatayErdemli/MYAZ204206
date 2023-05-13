using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class BubbleSort
    {
        public static void Sort<T>(T[] arr, IComparer<T> comparer = null)
            where T : IComparable
        {
            if (comparer is null) comparer = Comparer<T>.Default;
            int len = arr.Length;
            for (int i = 0; i < len - 1; i++)
                for (int j = 0; j < len - i - 1; j++)
                    if (comparer.Compare(arr[j], arr[j + 1]) >= 1) Sorting.Swap<T>(arr, j , j+1);

        }
    }
}

