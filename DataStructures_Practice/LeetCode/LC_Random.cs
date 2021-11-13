using Generics;
using System;
using System.Collections.Generic;

namespace LeetCode
{
    public static class LC_Random
    {
        //TODO Untested
        public static int StrStr(string haystack, string needle)
        {
            if (String.IsNullOrEmpty(needle) || haystack.Equals(needle)) { return 0; }

            char first = needle[0];
            int j;
            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                if (haystack[i] == first)
                {
                    for (j = 0; j < needle.Length; j++)
                    {
                        if (haystack[i + j] != needle[j])
                            break;
                    }

                    if (j == needle.Length)
                        return i;
                }
            }
            return -1;
        }

        //TODO Untested
        public static int[] PlusOne(int[] digits)
        {
            var finalDigits = new int[digits.Length + 1];

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] + 1 != 10)
                {
                    digits[i] += 1;
                    return digits;
                }

                digits[i] = 0;
                
                //We've reached the end, .999 becomes 1.000, need extra digit
                if (i - 1 < 0)
                {
                    digits.CopyTo(finalDigits, 1);
                    finalDigits[0] = 1;
                    return finalDigits;
                }
            }

            return null;
        }

        //TODO Untested
        public static string AddBinary(string a, string b)
        {
            int carry = 0;
            string s = "";
            int index = 0;

            while (index < a.Length || index < b.Length || carry > 0)
            {
                int ax = index < a.Length && a[a.Length - index - 1] == '1' ? 1 : 0;
                int bx = index < b.Length && b[b.Length - index - 1] == '1' ? 1 : 0;
                
                int digit = ax + bx + carry;
                carry = digit > 1 ? 1 : 0;
                digit = digit % 2;
                s = digit + s;
                index++;
            }
            return s;
        }

        //TODO Untested
        public static int MySqrt(int x)
        {
            if (x == 0) { return 0; }
            if (x < 4) { return 1; }

            var testVal = x / 2;
            var optionList = new List<int>();
            optionList.Add(testVal);

            while ((testVal * testVal) >= x)
            {
                testVal = (int)testVal / 2;

                if (testVal == x) { return (testVal); }

                optionList.Add(testVal);
            }

            //this was too low
            var floor = testVal;
            //this was too high
            var ceiling = optionList[optionList.Count - 2];

            testVal = (int)(ceiling + floor) / 2;

            var floorBuffer = (testVal - 1) * (testVal - 1);
            var actual = testVal * testVal;
            var ceilingBuffer = (testVal + 1) * (testVal + 1);

            if (x > floorBuffer & x < actual) { return testVal - 1; }

            if (x > actual & x < ceilingBuffer) { return testVal;  }

            //Idk>
            return testVal + 1;
        }

        //TODO Untested
        public static int FirstUniqChar(string s)
        {
            var indexArr = new int[256];

            foreach (var c in s)
            {
                indexArr[c]++;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (indexArr[s[i]] == 1)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
