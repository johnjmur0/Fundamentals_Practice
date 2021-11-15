using System;
using System.Collections.Generic;
using System.Text;

namespace DSA_Wengrow
{
    public static class Ch_13_Recursion_2
    {
        //Do with sorting to avoid O(N^3) loop of 3
        public static long Largest_3_Product(int[] arr)
        {
            long largest_prod = 0;

            Array.Sort(arr);

            largest_prod = 
                Convert.ToInt64(arr[arr.Length - 1]) *
                Convert.ToInt64(arr[arr.Length - 2]) *
                Convert.ToInt64(arr[arr.Length - 3]);

            return largest_prod;
        }

        //Find missing number in array in O(NlogN)
        public static int Find_Missing(int[] arr)
        {
            Array.Sort(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != i) { return i; }
            }
            throw new Exception("no missing index found");
        }

        //interesting having to figure out how to do this even slower than 1 loop...
        public static int Find_Greatest_N2(int[] arr)
        {
            bool greatest;
            for (int i = 0; i < arr.Length; i++)
            {
                greatest = true;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] > arr[i])
                    {
                        greatest = false;
                    }
                }

                if (greatest) { return arr[i]; }
            }
            throw new Exception("no greatest value found??");
        }

        public static int Find_Greatest_N(int[] arr)
        {
            var greatest = double.NegativeInfinity;

            for (int i = 0; i < arr.Length; i++)
            {
                greatest = Math.Max(greatest, i);
            }
            return (int)greatest;
        }

        public static int Find_Greatest_NlogN(int[] arr)
        {
            Array.Sort(arr);

            return arr[arr.Length - 1];
        }
    }
}
