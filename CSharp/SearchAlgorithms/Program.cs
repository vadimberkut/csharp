﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            // Linear search
            int[] arr1 = new int[] { 2, 3, 5, 6 };
            Point[] arr2 = new Point[] { new Point { X = 1, Y = 10 }, new Point { X = 12, Y = 210 }, new Point { X = 14, Y = 130 }, new Point { X = 61, Y = 10 } };
            int res1 = LinearSearch(arr1, x => x == 2);
            Point res2 = LinearSearch(arr2, x => x.X == 14);

            // Binary search
            int[] arr3 = new int[7] { 0, 2, 3, 5, 6, 66, 100 };
            arr3 = arr3.OrderBy(x => x).ToArray();
            int res3 = BinarySearchIndex(arr3, 3);
            int res4 = BinarySearchIndex(arr3, 5);

            // Jump search
            int[] arr4 = new int[7] { 0, 2, 3, 5, 6, 66, 100 };
            arr4 = arr4.OrderBy(x => x).ToArray();
            int res5 = JumpSearchIndex(arr3, 3);
            int res6 = JumpSearchIndex(arr3, 5);

            // Measure execution time on big data
            int hugeArrSize = 10000000;
            string[] hugeArr = new string[hugeArrSize];
            int[] hugeArrInt = new int[hugeArrSize];
            for (int i = 0; i < hugeArrSize; i++)
            {
                hugeArr[i] = i.ToString();
                hugeArrInt[i] = i;
            }
            Stopwatch sw = new Stopwatch();

            sw.Reset();
            sw.Start();
            int resH1 = LinearSearchIndex(hugeArr, (hugeArrSize - 1).ToString());
            sw.Stop();
            long t1 = sw.ElapsedMilliseconds;
            Console.WriteLine("Linear Search: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine();

            sw.Reset();
            sw.Start();
            int resH2 = BinarySearchIndex(hugeArr, (hugeArrSize - 1).ToString());
            sw.Stop();
            long t2 = sw.ElapsedMilliseconds;
            Console.WriteLine("Binary Search: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine();

            sw.Reset();
            sw.Start();
            int resH3 = JumpSearchIndex(hugeArr, (hugeArrSize - 1).ToString());
            sw.Stop();
            long t3 = sw.ElapsedMilliseconds;
            Console.WriteLine("Jump Search: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine();

            sw.Reset();
            sw.Start();
            int resH4 = InterpolationSearchIndex(hugeArrInt, random.Next(0, (hugeArrSize - 1)));
            sw.Stop();
            long t4 = sw.ElapsedMilliseconds;
            Console.WriteLine("Interpolation Search: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine();

            Console.ReadKey();
        }

        static T LinearSearch<T>(T[] collection, Func<T, bool> predicate)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                if (predicate(collection[i])) return collection[i];
            }
            return default(T);
        }

        static int LinearSearchIndex<T>(T[] collection, T value) where T : IComparable
        {
            for (int i = 0; i < collection.Length; i++)
            {
                if (value.CompareTo(collection[i]) == 0) return i;
            }
            return -1;
        }


        /// <summary>
        /// Searches index of elemnet in ordered array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        static int BinarySearchIndex<T>(T[] collection, T value) where T : IComparable
        {
            int left = 0;
            int right = collection.Length - 1;
            while (left <= right)
            {
                int middle = left + (int)Math.Ceiling((right - left) / 2.0);
                int compare = value.CompareTo(collection[middle]);
                if (compare == -1) right = middle;
                else if (compare == 1) left = middle;
                else return middle;
            }
            return -1;
        }

        /// <summary>
        /// Searches index of elemnet in ordered array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="value"></param>
        /// <param name="blockSize"></param>
        /// <returns></returns>
        static int JumpSearchIndex<T>(T[] collection, T value, int blockSize = -1) where T : IComparable
        {
            // Select optimal block size if not specified
            if (blockSize == -1) blockSize = (int)(Math.Ceiling(Math.Sqrt(collection.Length))); // sqert(n) is the optimal block size value

            for (int i = 0; i < collection.Length; i += blockSize)
            {
                int right = Math.Min(i + blockSize, collection.Length - 1);
                int compare = value.CompareTo(collection[right]);
                if(compare == -1)
                {
                    // start linear search at this segment of array
                    for (int j = i; j < right; j++)
                    {
                        if (value.CompareTo(collection[j]) == 0) return j;
                    }
                }
                if (compare == 0) return right;
            }
            return -1;
        }

        /// <summary>
        /// Searches index of element in ordered array
        /// Using own index to search calculated based on search value
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        static int InterpolationSearchIndex(int[] collection, int value, int lo = -1, int hi = -1)
        {
            // TODO: How use this alg with other data types that don't have 'minus' operation overloaded
            // The idea of formula is to return higher value for pos
            // when element to be searched is closer to arr[hi]. And
            // smaller value when closer to arr[lo]
            if(lo > hi)
            {
                return -1;
            }
            lo = lo == -1 ? 0 : lo;
            hi = hi == -1 ? collection.Length - 1 : hi;
            int x = value;
            int pos = lo + (((hi - lo) / (collection[hi] - collection[lo])) * (x - collection[lo]));
            if(value == collection[pos])
            {
                return pos;
            }
            else if(value < collection[pos])
            {
                // Less than - search in left part
                return InterpolationSearchIndex(collection, value, lo, pos);
            }
            else
            {
                // More than - search in right
                return InterpolationSearchIndex(collection, value, pos, hi);

            }
        }
    }
}
