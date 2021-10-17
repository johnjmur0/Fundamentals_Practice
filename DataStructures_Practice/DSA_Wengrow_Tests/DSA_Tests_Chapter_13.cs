using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DSA_Wengrow;

namespace DSA_Wengrow_Tests
{
    public class DSA_Tests_Chapter_13
    {
        [Fact]
        public void Test_Largest_3_Product()
        {
            int[] input = new int[] { 2, 3, 4, 5 };
            int expected = 3 * 4 * 5;

            var result = Chapter_13_Recursion2.Largest_3_Product(input);

            Assert.Equal(expected, result);
        }
    }
}
