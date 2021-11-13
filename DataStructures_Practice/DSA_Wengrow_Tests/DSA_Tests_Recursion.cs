using Xunit;
//I'll let LINQ fly for tests
using System.Linq;
using DSA_Wengrow;

namespace DSA_Wengrow_Tests
{
    public class DSA_Tests_Recursion
    {
        [Fact]
        public void TotalCharCount_Test()
        {
            var input = new string[] { "ab", "c", "def", "ghij" };

            var expected = input.Select(x => x.Length).Sum();

            var result = Ch_11_Recursion.TotalCharCount(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReturnEvens_Test()
        {
            var input = Enumerable.Range(0, 10000).ToArray();

            var expected = input.Where(x => x % 2 == 0).ToArray();

            //Book solution throws stack overflow at around 3500 items in arr
            //var result = Chapter11_Recursion.ReturnEvens_InPlace(input);

            //But by putting into new int[]? and removing nulls, its way faster
            var result = Ch_11_Recursion.ReturnEven(input, new int?[input.Length]);

            var nonNullResult = result.Where(x => x != null).Select(x => (int)x).ToArray();

            Assert.Equal(nonNullResult, expected);
        }

        [Fact]
        public void TriangleNumber_Test()
        {
            var nth = 7;
            var expected = 28;

            while (nth < 50)
            {
                var result = Ch_11_Recursion.TriangleNumber(nth);

                Assert.Equal(expected, result);

                nth++;
                expected += nth;
            }
        }

        [Fact]
        public void FirstXIndexTest()
        {
            var xString = "hex";
            var expectedIndex = 2;

            var xIndex = Ch_11_Recursion.FirstXIndex(xString);
            Assert.Equal(expectedIndex, xIndex);

            var allX = "xxxxxxxxx";
            xIndex = Ch_11_Recursion.FirstXIndex(allX);
            Assert.Equal(0, xIndex);

            var noX = "abcdefg";
            xIndex = Ch_11_Recursion.FirstXIndex(noX);
            Assert.Null(xIndex);
        }

        [Fact]
        public void UniquePathsTest()
        {
            var rowCount = 3;
            var colCount = 4;

            var shortestPathCount = Ch_11_Recursion.UniquePaths(rowCount, colCount);
            Assert.Equal(10, shortestPathCount);
        }
    }
}
