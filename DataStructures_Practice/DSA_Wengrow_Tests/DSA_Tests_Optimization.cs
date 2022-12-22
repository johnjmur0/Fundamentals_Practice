using Xunit;
using DSA_Wengrow;
using System.Linq;
using System.Collections.Generic;

namespace DSA_Wengrow_Tests
{
    public class DSA_Tests_Memory_Opt
    {
        [Fact]
        public void Test_Reverse_Array()
        {
            var input = new int[] { 5, 3, 7, 13, 65 };

            var expected = input.Reverse().ToArray();

            var result = Ch_19_Memory_Opt.Reverse_Array(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_Reverse_Array_Empty()
        {
            var input = new int[] { };

            var expected = input.Reverse();

            var result = Ch_19_Memory_Opt.Reverse_Array(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_Reverse_Array_Same()
        {
            var input = new int[] { 1, 1, 1, 1, 1 };

            var expected = input.Reverse();

            var result = Ch_19_Memory_Opt.Reverse_Array(input);

            Assert.Equal(expected, result);
        }
    }

    public class DSA_Test_Speed_Opt
    {
        [Fact]
        public void Test_Match_Players()
        {
            var jill_dict = new Dictionary<string, string>
            {
                { "first_name", "Jill"},
                { "last_name", "Huang"}
            };

            var janko_dict = new Dictionary<string, string>
            {
                { "first_name", "Janko"},
                { "last_name", "Barton"}
            };
            var wanda_dict = new Dictionary<string, string>
            {
                { "first_name", "Wanda"},
                { "last_name", "Vakulskas"}
            };

            var tina_dict = new Dictionary<string, string>
            {
                { "first_name", "Tina"},
                { "last_name", "Watkins"}
            };

            var arr_1 = new Dictionary<string, string>[] { jill_dict, wanda_dict, janko_dict };
            var arr_2 = new Dictionary<string, string>[] { tina_dict, jill_dict, wanda_dict };

            var expected_ret = new List<string>() { "Wanda Wakulskas", "Jill Huang" };

            var result = Ch_20_Time_Opt.Two_Sport_Players(arr_1, arr_2);
        }

        [Fact]
        public void Test_Find_Missing_Step()
        {
            var input = new int[] { 2, 3, 0, 6, 1, 5 };
            var expected = 4;

            var result = Ch_20_Time_Opt.Find_Missing_Int(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_Find_Missing_Step_2()
        {
            var input = new int[] { 8, 2, 3, 9, 4, 7, 5, 0, 6 };
            var expected = 1;

            var result = Ch_20_Time_Opt.Find_Missing_Int(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_Find_Max_Sell()
        {
            var input = new int[] { 10, 7, 5, 8, 11, 2, 6 };

            var expected = 6;

            var result = Ch_20_Time_Opt.Find_Max_Sell(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_Get_Highest_Product()
        {
            var input = new int[] { 5, -10, -6, 9, 4 };

            var expected = 60;

            var result = Ch_20_Time_Opt.Get_Highest_Product(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_Sort_Temps()
        {
            var input = new double[] { 98.6, 98.0, 97.1, 99.0, 98.9, 97.8, 98.5, 98.2, 98.0, 97.1 };

            var expected = input.OrderBy(x => x).ToArray();

            var result = Ch_20_Time_Opt.Sort_Temps(input);

            Assert.Equal(expected, result);
        }


        [Fact]
        public void Test_Find_Longest_Sequence()
        {
            var input = new int[] { 10, 5, 12, 3, 55, 30, 4, 11, 2 };

            var expected = 4;

            var result = Ch_20_Time_Opt.Find_Longest_Sequence(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_Find_Longest_Sequence_2()
        {
            var input = new int[] { 19, 13, 15, 12, 18, 14, 17, 11 };

            var expected = 5;

            var result = Ch_20_Time_Opt.Find_Longest_Sequence(input);

            Assert.Equal(expected, result);
        }
    }
}