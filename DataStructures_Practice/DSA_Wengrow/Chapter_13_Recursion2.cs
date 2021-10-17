using System;
using System.Collections.Generic;
using System.Text;

namespace DSA_Wengrow
{
    public static class Chapter_13_Recursion2
    {
        //Do with sorting to avoid O(N^3) loop of 3
        public static int Largest_3_Product(int[] arr)
        {
            int largest_prod = 0;

            Array.Sort(arr);

            largest_prod = arr[arr.Length - 1] * arr[arr.Length - 2] * arr[arr.Length - 3];

            return largest_prod;
        }
    }
}
