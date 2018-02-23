using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinSearch
{
    class Program
    {
        public static int BinarySearch(int[] array, int value)
        {
            if (array == null || array.Length == 0)
            {
                return -1;
            }
            int first = 0, last = array.Length;
            while (first < last - 1)
            {
                int middle = first + (last - first) / 2;
                if (value < array[middle])
                {
                    last = middle - 1;
                }
                else
                {
                    first = middle;
                }
            }
            if (array[first] == value)
            {
                return first;
            }
            return -1;
        }
        
        static void Main(string[] args)
        {
            TestSimpleNumbers();
            TestNegativeNumbers();
            TestNonExistentElement();
            TestRepeatingNumbers();
            TestEmptyArray();
            TestBigArray();

            Console.ReadKey();
        }

        private static void TestSimpleNumbers()

        {
            //Тестирование поиска одного элемента в массиве из 5 элементов

            int[] simpleNumbers = new[] { 1, 3, 5, 7, 9 };
            if (BinarySearch(simpleNumbers, 5) != 2)
            {
                Console.WriteLine("! Поиск не нашёл число 5 среди чисел {1, 3, 5, 7, 9}");
            }
            else
            {
                Console.WriteLine("Поиск в массиве из 5 элементов работает корректно");
            }
        }

        private static void TestNegativeNumbers()

        {
            //Тестирование поиска в отрицательных числах

            int[] negativeNumbers = new[] { -5, -4, -3, -2 };
            if (BinarySearch(negativeNumbers, -3) != 2)
            {
                Console.WriteLine("! Поиск не нашёл число -3 среди чисел {-5, -4, -3, -2}");
            }
            else
            {
                Console.WriteLine("Поиск среди отрицательных чисел работает корректно");
            }
        }

        private static void TestNonExistentElement()
        {

            //Тестирование поиска отсутствующего элемента

            int[] negativeNumbers = new[] { -5, -4, -3, -2 };

            if (BinarySearch(negativeNumbers, -1) >= 0)
            {
                Console.WriteLine("! Поиск нашёл число -1 среди чисел {-5, -4, -3, -2}");
            }
            else
            {
                Console.WriteLine("Поиск отсутствующего элемента работает корректно");
            }
        }

        private static void TestRepeatingNumbers()

        {
            //Тестирование поиска  элемента, повторяющегося несколько раз

            int[] repeatingNumbers = new[] { 1, 3, 5, 5, 9 };
            int rep = BinarySearch(repeatingNumbers, 5);
            if (rep != 2 && rep != 3)
            {
                Console.WriteLine("! Поиск не нашёл число 5 среди чисел {1, 3, 5, 5, 9}");
            }
            else
            {
                Console.WriteLine("Поиск элемента, повторяющегося несколько раз работает корректно");
            }
        }

        private static void TestEmptyArray()
        {

            //Тестирование поиска в пустом массиве

            int[] emptyArray = new int[0];

            if (BinarySearch(emptyArray, 9) != -1)
            {
                Console.WriteLine("! Поиск нашёл число 9 в пустом массиве крутяк, да?");
            }
            else
            {
                Console.WriteLine("Поиск в пустом массиве работает корректно");
            }
        }

        private static void TestBigArray()
        {

            //Тестирование поиска в массиве из 100001 элементов

            int[] bigArray = Enumerable.Range(1, 100001).ToArray();

            if (BinarySearch(bigArray, 55555) != 55554)
            {
                Console.WriteLine("! Поиск не нашёл число 55555 в массиве чисел с 1 до 100001");
            }
            else
            {
                Console.WriteLine("Поиск в большом массиве работает корректно");
            }
        }
    }
}
