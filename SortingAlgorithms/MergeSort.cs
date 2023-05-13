using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class MergeSort
    {
        public static void Sort<T>(T[] arr, IComparer<T> comparer = null)
            where T : IComparable
        {
            Sort(arr,0,arr.Length-1,comparer);
        }

        private static void Sort<T>(T[] arr, int left, int right, IComparer<T> comparer)
            where T : IComparable
        {
            if (left < right)
            {
                int middle = (left+right)/2;

                Sort(arr, left, middle, comparer);
                Sort(arr, middle + 1, right,comparer);
                Merge(arr, left, middle, right, comparer);
            }
        }

        private static void Merge<T>(T[] Array, int left, int middle, int right, IComparer<T> comparer = null)
            where T : IComparable
        {
            if (comparer is null) comparer = Comparer<T>.Default;
            T[] leftArray = new T[middle - left + 1];
            T[] rightArray = new T[right - middle];

            System.Array.Copy(Array, left, leftArray, 0, middle - left + 1);
            System.Array.Copy(Array, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    Array[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    Array[k] = leftArray[i];
                    i++;
                }
                else if (comparer.Compare(leftArray[i], rightArray[j]) < 0)
                {
                    Array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    Array[k] = rightArray[j];
                    j++;
                }
            }
        }
    }
}
