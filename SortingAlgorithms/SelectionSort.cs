using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace SortingAlgorithms
{
    public class SelectionSort
    {
        public static void Sort<T>(T[] arr)
            where T : IComparable
        {
            for (int i = 0; i < arr.Length-1; i++)
            {
                int minIndex = i;
                T minValue = arr[i];
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(minValue)<0)
                    {
                        minIndex = j;
                        minValue = arr[minIndex];
                    }
                }
                Sorting.Swap<T>(arr,i,minIndex);
            }
        }

        public static void Sort<T>(T[] arr, SortDirection sortDirection = SortDirection.Ascending)
            where T : IComparable
        {
            var comparer = new CustomComparer<T>(sortDirection, Comparer<T>.Default);
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (comparer.Compare(arr[j], arr[i]) >= 0) continue;
                    Sorting.Swap(arr, i, j);
                }
            }
        }
    }
}
