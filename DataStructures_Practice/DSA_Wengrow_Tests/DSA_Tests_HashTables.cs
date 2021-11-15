using DSA_Wengrow;
using Xunit;
//I'll let LINQ fly for tests

namespace DSA_Wengrow_Tests
{
    public class DSA_Tests_HashTables
    {
        [Fact]
        public void ArrayIntersection_Test()
        {
            var arr1 = new int[] { 1, 2, 3, 4, 5 };
            var arr2 = new int[] { 0, 2, 4, 6, 8 };

            var expected = new int[] { 2, 4 };

            var result = Ch_8_HashTables.ArrayIntersection(arr1, arr2);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void FirstDupe_Test()
        {
            var input = new string[] { "a", "b", "c", "d", "c", "e", "f" };
            var expected = "c";
            var result = Ch_8_HashTables.FirstDuplicate(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void MissingLetter_Test()
        {
            var input = "the quick brown box jumps over a lazy dog";
            var expected = "f";
            var result = Ch_8_HashTables.FindMissingLetter(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void FirstNonDupe_Test()
        {
            var input = "minimum";
            var expected = 'n';
            var result = Ch_8_HashTables.FirstNonDupe(input);

            Assert.Equal(expected, result);

        }
    }
}
