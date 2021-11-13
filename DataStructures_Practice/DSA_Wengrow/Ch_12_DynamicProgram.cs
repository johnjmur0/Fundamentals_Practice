using System;
using System.Collections.Generic;
using System.Text;

namespace DSA_Wengrow
{
    public static class Chapter_12_DynamicProgramming
    {
        public static int Add_Until_100_ExtraCall(int[] arr)
        {
            if (arr.Length == 0) { return 0; }

            if (arr[0] + Add_Until_100_ExtraCall(arr[1..arr.Length]) > 100)
            {
                return Add_Until_100_ExtraCall(arr[1..arr.Length]);
            }
            else
            {
                return (arr[0] + Add_Until_100_ExtraCall(arr[1..arr.Length]));
            }
        }

        public static int Add_Until_100(int[] arr)
        {
            if (arr.Length == 0) { return 0; }

            int subArrVal = Add_Until_100(arr[1..arr.Length]);

            if ((arr[0] + subArrVal) > 100)
            {
                return subArrVal;
            }
            else
            {
                return (arr[0] + subArrVal);
            }
        }

        public static int Golomb_Sequence(int n)
        {
           if (n == 1) { return 1;  }

            return 1 + Golomb_Sequence(n - Golomb_Sequence(Golomb_Sequence(n - 1)));
        }

        public static int Golomb_Sequence_Memoize(int n, int[] arr)
        {
            if (n == 1) { return 1; }

            if (arr[n - 1] == 0)
            {
                arr[n] = 1 + Golomb_Sequence_Memoize(
                    n - Golomb_Sequence_Memoize(Golomb_Sequence_Memoize(n - 1, arr), arr), arr);
            }

            return arr[n];
        }

        public static int Unique_Paths(int rows, int columns)
        {
            if (rows == 1 || columns == 1)
            {
                return 1;
            }

            return Unique_Paths(rows - 1, columns) + Unique_Paths(rows, columns - 1);
        }

        public static int Unique_Paths_Memo(int rows, int columns, int[,] paths)
        {
            if (rows == 1 || columns == 1)
            {
                return 1;
            }

            if (paths[rows, columns] == 0)
            {
                paths[rows, columns] = Unique_Paths_Memo(rows - 1, columns, paths) + 
                    Unique_Paths_Memo(rows, columns - 1, paths);
            }

            return paths[rows, columns];
        }
    }
}
