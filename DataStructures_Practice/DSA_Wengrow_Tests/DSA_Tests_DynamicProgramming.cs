using Xunit;
//I'll let LINQ fly for tests
using System.Linq;
using System.Diagnostics;
using DSA_Wengrow;
using System;

namespace DSA_Wengrow_Tests
{
    public class DSA_Tests_Chapter_DynamicProgramming
    {
        [Fact]
        public void Test_Extra_Call_Length()
        {
            int[] input = Enumerable.Range(1, 100).ToArray();
            var expected = 100;

            /* This is actually so slow (> 5 mins) with the 3 extra calls
             * 
            var sw = Stopwatch.StartNew();
            var result = Chapter_12_DynamicProgramming.Add_Until_100_ExtraCall(input);
            sw.Stop();

            Console.WriteLine($"Extra Call={sw.Elapsed}");
            Assert.Equal(expected, result);
            */

            //But this is almost instant with just 1 call
            var sw = Stopwatch.StartNew();
            var result = Chapter_12_DynamicProgramming.Add_Until_100(input);
            sw.Stop();

            Console.WriteLine($"No Extra Call={sw.Elapsed}");
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_Golomb_Sequence()
        {
            var input = 64;
            var expected = 16;
            var sw = Stopwatch.StartNew();
            var result = Chapter_12_DynamicProgramming.Golomb_Sequence(input);
            sw.Stop();

            var non_memoTime = sw.Elapsed;
            Console.WriteLine($"No Memoize={non_memoTime}");
            Assert.Equal(expected, result);

            sw = Stopwatch.StartNew();
            result = Chapter_12_DynamicProgramming.Golomb_Sequence_Memoize(input, new int[input + 1]);
            sw.Stop();

            var memoTime = sw.Elapsed;
            Console.WriteLine($"Memoize={memoTime}");
            Assert.Equal(expected, result);

            //Think its VS19 issue, but can't get test output to show up to see time diff
            //But memoize goes from 10 seconds to 4 seconds
        }

        [Fact]
        public void Test_Unique_Paths()
        {
            var rows = 17;
            var columns = 17;
            var expected = 601080390;
            var sw = Stopwatch.StartNew();
            var result = Chapter_12_DynamicProgramming.Unique_Paths(rows, columns);
            sw.Stop();

            var non_memoTime = sw.Elapsed;
            Console.WriteLine($"No Memoize={non_memoTime}");
            Assert.Equal(expected, result);

            sw = Stopwatch.StartNew();
            result = Chapter_12_DynamicProgramming.Unique_Paths_Memo(
                rows, 
                columns, 
                new int[rows + 1, columns + 1]);
            sw.Stop();

            var memoTime = sw.Elapsed;
            Console.WriteLine($"Memoize={memoTime}");
            Assert.Equal(expected, result);

            //Think its VS19 issue, but can't get test output to show up to see time diff
            //But memoize goes from 8 seconds to .0006 (a 13,000x increase!!!)
        }
    }
}
