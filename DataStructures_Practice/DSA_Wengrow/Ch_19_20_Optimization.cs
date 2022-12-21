using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA_Wengrow
{
    public static class Ch_19_Memory_Opt
    {

        // Take O(1) space
        public static int[] Reverse_Array(int[] arr)
        {
            var head = 0;
            var tail = arr.Length - 1;

            while (tail > head)
            {
                var tail_var = arr[tail];
                arr[tail] = arr[head];
                arr[head] = tail_var;

                head++;
                tail--;
            }
            return arr;
        }
    }
}