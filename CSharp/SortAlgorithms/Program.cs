using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            // Buble sort
            int[] arr1 = new int[] { 3,2,1,0,33,2,44,23,10,23,8 };
            Console.WriteLine("Buble sort");
            Console.WriteLine(ArrayToString(arr1));
            Console.WriteLine(ArrayToString(BubleSort(arr1)));
            Console.WriteLine();

            // Selection sort
            int[] arr2 = new int[] { 3, 2, 1, 0, 33, 2, 44, 23, 10, 23, 8 };
            Console.WriteLine("Selection sort");
            Console.WriteLine(ArrayToString(arr2));
            Console.WriteLine(ArrayToString(SelectionSort(arr2)));
            Console.WriteLine();

            // Insertion sort
            int[] arr3 = new int[] { 3, 2, 1, 0, 33, 2, 44, 23, 10, 23, 8, 555, 20, 1, -2, -30, 2 };
            Console.WriteLine("Insertion sort");
            Console.WriteLine(ArrayToString(arr3));
            Console.WriteLine(ArrayToString(InsertionSort(arr3)));
            Console.WriteLine();

            // Quick sort
            int[] arr4 = new int[] { 3, -100, 2, 1, 0, 33, 2, 44, 23, 10, 23, 8, 555, 20, 1, -2, -30, 2 };
            Console.WriteLine("Qucik sort");
            Console.WriteLine(ArrayToString(arr4));
            Console.WriteLine(ArrayToString(InsertionSort(arr4)));
            Console.WriteLine();

            // Merge sort


            const int SIZE = 20000;
            int[] bigArr1 = new int[SIZE];
            int[] bigArr2 = new int[SIZE];
            int[] bigArr3 = new int[SIZE];
            int[] bigArr4 = new int[SIZE];
            Random rand = new Random();
            for (int i = 0; i < SIZE; i++)
            {
                int random = rand.Next(0, 1000);
                bigArr1[i] = random;
                bigArr2[i] = random;
                bigArr3[i] = random;
                bigArr4[i] = random;
            }
            Stopwatch sw = new Stopwatch();

            sw.Reset();
            sw.Start();
            BubleSort(bigArr1);
            sw.Stop();
            Console.WriteLine("Bubble: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine();

            sw.Reset();
            sw.Start();
            SelectionSort(bigArr2);
            sw.Stop();
            Console.WriteLine("Selection: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine();

            sw.Reset();
            sw.Start();
            InsertionSort(bigArr3);
            sw.Stop();
            Console.WriteLine("Insertion: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine();

            sw.Reset();
            sw.Start();
            QuickSort(bigArr4);
            sw.Stop();
            Console.WriteLine("Quick: {0} ({1} calls)", sw.ElapsedMilliseconds, QuickSortRecursiveCalls);
            Console.WriteLine();

            Console.ReadKey();
        }

        static string ArrayToString<T>(T[] collection)
        {
            return String.Join(", ", collection);
        }

        static T[] BubleSort<T>(T[] collection) where T : IComparable
        {
            for (int i = 0; i < collection.Count(); i++)
            {
                for (int j = 0; j < collection.Count() - i - 1; j++)
                {
                    if(collection[j].CompareTo(collection[j + 1]) == 1)
                    {
                        T temp = collection[j];
                        collection[j] = collection[j + 1];
                        collection[j + 1] = temp;
                    }
                }
            }

            return collection;
        }

        /// <summary>
        /// Sorts array by moving min value to the begining (if asc order)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        static T[] SelectionSort<T>(T[] collection) where T : IComparable
        {
            for (int i = 0; i < collection.Length; i++)
            {
                int minIndex = FindMinIndex(collection, i, collection.Length);
                T temp = collection[i];
                collection[i] = collection[minIndex];
                collection[minIndex] = temp;
            }
            return collection;
        }

        static int FindMinIndex<T>(T[] collection, int indexFrom, int indexTo) where T : IComparable
        {
            int minIndex = -1;
            if(collection.Length >= 1 && indexFrom < collection.Length && indexTo <= collection.Length)
            {
                T min = collection[indexFrom];
                minIndex = indexFrom;
                for (int i = indexFrom + 1; i < indexTo; i++)
                {
                    if (min.CompareTo(collection[i]) == 1)
                    {
                        min = collection[i];
                        minIndex = i;
                    }
                }
            }
            return minIndex;
        }

        /// <summary>
        /// Finds for current element the corect place in the left sorted part of a collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        static T[] InsertionSort<T>(T[] collection) where T : IComparable
        {
            for (int i = 0; i < collection.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if(collection[i].CompareTo(collection[j]) == -1)
                    {
                        T temp = collection[i];
                        collection[i] = collection[j];
                        collection[j] = temp;
                    }
                }
            }
            return collection;
        }

        /// <summary>
        /// Quick sort (Hoar sort)
        /// O(n log n)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="fromIndex"></param>
        /// <param name="toIndex"></param>
        /// <returns></returns>
        static int QuickSortRecursiveCalls = 0;
        static T[] QuickSort<T>(T[] collection, int fromIndex = -1, int toIndex = -1) where T : IComparable
        {
            // Just stat
            // Not an algorithm part
            if(fromIndex == 1 && toIndex == -1)
            {
                QuickSortRecursiveCalls = 0;
            }
            QuickSortRecursiveCalls += 1;

            // Handle first call
            fromIndex = fromIndex == -1 ? 0 : fromIndex;
            toIndex = toIndex == -1 ? collection.Length - 1 : toIndex;

            if(fromIndex < toIndex)
            {
                // Get pivot
                int pivotIndex = fromIndex + (int)Math.Floor((toIndex - fromIndex) / 2.0);
                T pivot = collection[pivotIndex];

                // Do partitioning (magic)
                // Place elements less that pivot in the left, greater than pivot in the rigth
                int i = fromIndex;
                int j = toIndex;
                while(i <= j)
                {
                    while(collection[i].CompareTo(pivot) == -1) // collection[i] < pivot
                    {
                        i += 1;
                    }
                    while (collection[j].CompareTo(pivot) == 1) // collection[i] > pivot
                    {
                        j -= 1;
                    }
                    if(i <= j)
                    {
                        // Swap
                        T temp = collection[i];
                        collection[i] = collection[j];
                        collection[j] = temp;

                        i += 1;
                        j -= 1;
                    }
                }
                pivotIndex = i;

                // Reursively perform sorting for left and right part
                QuickSort(collection, fromIndex, pivotIndex - 1);
                QuickSort(collection, pivotIndex, toIndex);
            }

            return collection;
        }

        /// <summary>
        /// 
        ///  O(n log n)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="fromIndex"></param>
        /// <param name="toIndex"></param>
        /// <returns></returns>
        static T[] MergeSort<T>(T[] collection, int fromIndex = -1, int toIndex = -1) where T : IComparable
        {
            return collection;
        }
    }
}
