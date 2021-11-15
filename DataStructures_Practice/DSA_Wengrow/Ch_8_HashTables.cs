using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA_Wengrow
{   
    public static class Ch_8_HashTables
    {
        //ch 8 1/4
        public static int[] ArrayIntersection(int[] arr1, int[] arr2)
        {
            //create hash of larger arr
            var largerArr = (arr1.Length > arr2.Length) ? arr1 : arr2;
            var smallerArr = (arr1.Length > arr2.Length) ? arr2 : arr1;

            var largerDict = new Dictionary<int, bool>();
            foreach (var val in largerArr)
            {
                largerDict.Add(val, true);
            }

            var retVal = new List<int>();

            foreach (var smallVal in smallerArr)
            {
                largerDict.TryGetValue(smallVal, out bool exists);

                if (exists)
                {
                    retVal.Add(smallVal);
                }
            }

            return retVal.ToArray();
        }

        //ch 8 2/4
        public static string FirstDuplicate(string[] arr)
        {
            var charDict = new Dictionary<string, bool>();

            foreach (var val in arr)    
            {
                var addSuccess = charDict.TryAdd(val, true);

                if (!addSuccess)
                {
                    return val;
                }
            }
            return null;
        }

        //ch 8 3/4
        public static string FindMissingLetter(string val)
        {
            char[] alphabet = Enumerable.Range('a', 26).Select(x => (char)x).ToArray();

            var charArr = val.ToCharArray();

            var charDict = new Dictionary<string, bool>();

            foreach (var charVal in charArr)
            {
                if (charVal == ' ')
                {
                    continue;
                }

                //don't care if it doesn't add, only need distinct
                charDict.TryAdd(charVal.ToString(), true);
            }

            foreach (var letter in alphabet)
            {
                charDict.TryGetValue(letter.ToString(), out bool exists);

                if (!exists)
                {
                    return letter.ToString();
                }
            }
            return null;
        }

        //ch 8 4/4
        public static char FirstNonDupe(string s)
        {
            var charDict = new Dictionary<char, bool>();
            var nonDupe = new Dictionary<char, int>();
            var charArr = s.ToCharArray();

            for (int i = 0; i < charArr.Length; i++)
            {
                var addResult = charDict.TryAdd(charArr[i], true);

                if (addResult)
                {
                    nonDupe.Add(charArr[i], i);
                }
                else
                {
                    nonDupe.Remove(charArr[i]);
                }
            }

            var retVal = nonDupe.OrderBy(x => x.Value).First().Key;
            return retVal;
        }
    }
}