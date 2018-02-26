using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    public static class Sort
    {
        public static void QuickSort(int[] array, int first, int last)
        {
            if (first < last)
            {
                int pivot = Partition(array, first, last);
                QuickSort(array, first, pivot);
                QuickSort(array, pivot + 1, last);
            }
        }

        private static int Partition(int[] array, int first, int last)
        {
            int pivot = array[first];
            int i = first - 1, j = last + 1;
            while (true)
            {
                do
                {
                    j = j - 1;
                } while (array[j] > pivot);

                do
                {
                    i = i + 1;
                } while (array[i] < pivot);

                if (i < j)
                {
                    Swap(array, i, j);
                }
                else
                {
                    return j;
                }
            }
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
