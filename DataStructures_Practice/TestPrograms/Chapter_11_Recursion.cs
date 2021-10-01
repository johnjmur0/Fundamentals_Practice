namespace DSA_Wengrow
{
    public static class Chapter_11_Recursion
    {
        public static int TotalCharCount(string[] s)
        {
            if (s.Length == 0)
            {
                return 0;
            }

            return s[0].Length + TotalCharCount(s[1..s.Length]);
        }

        public static int?[] ReturnEven(int[] nums, int?[] evens, int pointer = 0)
        {
            if (pointer == nums.Length)
            {
                return evens;
            }

            var val = nums[pointer];

            if (val % 2 == 0)
            {
                evens[pointer] = val;
            }

            pointer++;
            return ReturnEven(nums, evens, pointer);
        }

        //Book solution that was bad. 
        //1) hit SO exception, 2) required new int[] or Linq, violating my package constraint
        //public static int[] ReturnEvens_InPlace(int[] nums)
        //{
        //    if (nums.Length == 0)
        //    {
        //        return new int[0];
        //    }

        //    if (nums[0] % 2 == 0)
        //    {
        //        return ReturnEvens_InPlace(nums[1..(nums.Length)])
        //            .Concat(new int[] { nums[0] }).ToArray();
        //    }
        //    else
        //    {
        //        return ReturnEvens_InPlace(nums[1..(nums.Length)]);
        //    }
        //}

        public static int TriangleNumber(int n)
        {
            if (n == 1) { return 1; }

            return n + TriangleNumber(n - 1);
        }

        public static int? FirstXIndex(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }

            if (s.ToCharArray()[0] == 'x')
            {
                return 0;
            }

            return FirstXIndex(s[1..(s.Length)]) + 1;
        }

        public static int UniquePaths(int row, int col)
        {
            if (row == 1 || col == 1)
            {
                return 1;
            }

            return (UniquePaths(row - 1, col)) + (UniquePaths(row, col - 1));
        }
    }
}
