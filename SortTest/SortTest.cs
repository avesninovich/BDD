using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorts;
using System.Linq;

namespace SortTest
{
    [TestClass]
    public class SortTest
    {
        [TestMethod]
        public void ThreeElements()
        {
            var array = new[] { 5, 9, 1 };
            Sort.QuickSort(array, 0, array.Length - 1);
            Assert.IsTrue(IsSorted(array));          
        }

        [TestMethod]
        public void HundredElements()
        {
            //var array = new int[100];
            var array = Enumerable.Repeat(99, 100).ToArray();
            Sort.QuickSort(array, 0, array.Length - 1);
            Assert.IsTrue(IsSorted(array));
        }

        [TestMethod]
        public void RandomElements()
        {
            var rnd = new Random();
            var array = new int[1000];
            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next();
            Sort.QuickSort(array, 0, array.Length - 1);
            Assert.IsTrue(IsSortedFast(array));
        }

        [TestMethod]
        public void EmptyArray()
        {
            var array = new int[0];
            Sort.QuickSort(array, 0, array.Length - 1);
            Assert.IsTrue(IsSorted(array));
        }

        [TestMethod]
        public void BigArray()
        {
            var rnd = new Random();
            var array = new int[1500000000];
            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next();
            Sort.QuickSort(array, 0, array.Length - 1);
            Assert.IsTrue(IsSorted(array));
        }

        private bool IsSortedFast(int[] array)
        {
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int x = random.Next(1, array.Length);
                if (array[x] < array[x - 1])
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsSorted(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
