using LeetCode;
using Xunit;

namespace LeetCode_Tests
{
    public class LC_Arrays_Tests
    {
        [Fact]
        public void Test_RemoveDupes()
        {
            int[] input = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int expected = 5;
            int[] expected_nums = new int[] { 0, 1, 2, 3, 4, 0, 0, 0, 0, 0 };

            var result = LC_Arrays.RemoveDuplicates(input);

            Assert.Equal(expected, result);

            input = new int[] { 1, 1, 2 };
            result = LC_Arrays.RemoveDuplicates(input);

            input = new int[] { 1, 2 };
            result = LC_Arrays.RemoveDuplicates(input);
        }
    }
}
