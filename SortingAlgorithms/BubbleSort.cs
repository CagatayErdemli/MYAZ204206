using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class BubbleSort
    {
        public static void Sort<T>(T[] arr)
            where T : IComparable<T>
        {
            int len = arr.Length;
            for (int i = 0; i < len - 1; i++)
                for (int j = 0; j < len - i - 1; j++)
                    if (arr[j].CompareTo(arr[j + 1]) >= 1) Sorting.Swap(arr, j, j + 1);
        }
    }
}

