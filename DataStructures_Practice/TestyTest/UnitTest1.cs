using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNamespace;

namespace TestyTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testArr = new int[] { 3, 5, 1 };
            var testResult = CanMakeArithmeticProgression(testArr);

            Console.WriteLine(testResult);
        }
    }
}
