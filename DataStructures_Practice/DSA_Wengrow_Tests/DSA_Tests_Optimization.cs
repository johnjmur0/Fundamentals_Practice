using Xunit;
using DSA_Wengrow;
using System.Linq;

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
}