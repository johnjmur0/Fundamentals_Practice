using System;
using Xunit;
using DSA_Wengrow;
using System.Linq;
using System.Diagnostics;

namespace DSA_Wengrow_Tests
{
    public class DSA_Tests_Chapter_Recursion2
    {
        [Fact]
        public void Test_Largest_3_Product()
        {
            int[] input = new int[] { 2, 3, 4, 5 };
            long expected = 3 * 4 * 5;

            var result = Chapter_13_Recursion2.Largest_3_Product(input);
            Assert.Equal(expected, result);

            input = Enumerable.Range(1, 100000).ToArray();
            expected = 100000L * 99999L * 99998L;

            result = Chapter_13_Recursion2.Largest_3_Product(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_Find_Missing()
        {
            int[] input = new int[] { 9, 3, 2, 5, 6, 7, 1, 0, 4 };
            int expected = 8;

            int result = Chapter_13_Recursion2.Find_Missing(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_Find_Greatest()
        {
            Random ran = new Random();
            int[] input = Enumerable.Range(0, 50000).ToArray();
            int[] randomArr = input.OrderBy(x => ran.Next()).ToArray();

            int expected = 49999;
            Stopwatch sw = Stopwatch.StartNew();
            int result = Chapter_13_Recursion2.Find_Greatest_N2(randomArr);
            sw.Stop();
            var n2_time = sw.Elapsed;
            Assert.Equal(expected, result);

            sw = Stopwatch.StartNew();
            result = Chapter_13_Recursion2.Find_Greatest_N(randomArr);
            sw.Stop();
            var n_time = sw.Elapsed;
            Assert.Equal(expected, result);

            sw = Stopwatch.StartNew();
            result = Chapter_13_Recursion2.Find_Greatest_NlogN(randomArr);
            sw.Stop();
            var nlogN_time = sw.Elapsed;
            Assert.Equal(expected, result);

            //N2 time: 16 seconds
            //NlogN time: .014 seconds
            //N time: .0014 seconds
            //N is ~10x faster than NlogN
        }
    }
}
