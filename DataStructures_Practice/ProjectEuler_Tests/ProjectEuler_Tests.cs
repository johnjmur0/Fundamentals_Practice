using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;
using System;
using System.Collections.Generic;
using Xunit;

namespace ProjectEuler_Tests
{
    public class ProjectEuler_Tests
    {
        [Fact]
        public void Test_multiples_3_5_lessThan_x()
        {
            int lessThan = 10;
            //3 + 5 + 6 + 9 = 23
            int expected = 23;

            int result = ProjectEuler_Problems.Multiples_3_5_lessThan_x(lessThan);

            Xunit.Assert.Equal(expected, result);

            lessThan = 1000;
            expected = 233168;

            result = ProjectEuler_Problems.Multiples_3_5_lessThan_x(lessThan);

            Xunit.Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_FibSequence_EvenSum()
        {
            int cap = 90;
            int expected = 2 + 8 + 34;

            int result = ProjectEuler_Problems.FibSequence_EvenSum(cap);

            Xunit.Assert.Equal(expected, result);

            cap = 4000000;
            expected = 4613732;

            result = ProjectEuler_Problems.FibSequence_EvenSum(cap);

            Xunit.Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_GetPrimes()
        {
            var expected = new List<long>()
            {
                2,   3,   5,   7,   11,  13,
                17,  19,  23,  29,  31,  37,
                41,  43,  47,  53,  59,  61,
                67,  71,  73,  79,  83,  89,
                97 , 101, 103, 107, 109, 113,
                127, 131, 137, 139, 149, 151,
                157, 163, 167, 173, 179, 181,
                191, 193, 197, 199, 211, 223,
                227, 229, 233, 239, 241, 251,
                257, 263, 269, 271, 277, 281,
                283, 293, 307, 311, 313, 317,
                331, 337, 347, 349, 353, 359,
                367, 373, 379, 383, 389, 397,
                401, 409, 419, 421, 431, 433,
                439, 443, 449, 457, 461, 463,
                467, 479, 487, 491, 499, 503,
                509, 521, 523, 541, 547, 557,
                563, 569, 571, 577, 587, 593,
                599, 601, 607, 613, 617, 619,
                631, 641, 643, 647, 653, 659,
                661, 673, 677, 683, 691, 701,
                709, 719, 727, 733, 739, 743,
                751, 757, 761, 769, 773, 787,
                797, 809, 811, 821, 823, 827,
                829, 839, 853, 857, 859, 863,
                877, 881, 883, 887, 907, 911,
                919, 929, 937, 941, 947, 953,
                967, 971, 977, 983, 991, 997,
            };

            var cap = 1000;
            var result = ProjectEuler_Problems.GetPrimes(cap);

            CollectionAssert.AreEqual(expected, result);
        }

        [Fact (Skip = "too slow, need better implementation")]
        public void Test_Largest_Prime_Factor()
        {
            long num = 13195;
            var expected = 29;
            var result = ProjectEuler_Problems.Largest_Prime_Factor(num);

            Xunit.Assert.Equal(expected, result);

            num = 600851475143;
            expected = 0;
            result = ProjectEuler_Problems.Largest_Prime_Factor(num);

            Xunit.Assert.Equal(expected, result);

        }

    }
}
