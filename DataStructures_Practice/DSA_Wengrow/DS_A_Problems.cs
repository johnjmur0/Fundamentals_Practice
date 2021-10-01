using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA_Wengrow
{   
    public static class DSAPractice
    {
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

        public static bool SameCharacters(List<string> entries)
        {
            var uniqueChars = true;

            var charDict = new Dictionary<char, bool>();

            foreach (var entry in entries)
            {
                var charArray = entry.ToCharArray();

                foreach (var charVal in charArray)
                {
                    var addAttempt = charDict.TryAdd(charVal, true);

                    if (!addAttempt)
                    {
                        return false;
                    }
                }
            }

            return uniqueChars;
        }

        public static string TwoStrings(string s1, string s2)
        {
            var longerString = (s1.Count() > s2.Count()) ? s1 : s2;
            var shorterString = (s1.Count() > s2.Count()) ? s2 : s1;

            var charDict = new Dictionary<char, bool>();

            foreach (var char1 in longerString.ToCharArray())
            {
                charDict.TryAdd(char1, true);
            }

            foreach (var char2 in shorterString.ToCharArray())
            {
                var getResult = charDict.TryGetValue(char2, out bool exists);

                if (getResult)
                {
                    return ("YES");
                }
            }

            return ("NO");
        }

        public static int MakeAnagram(string a, string b)
        {
            var charDict = new Dictionary<char, int>();

            foreach (var charVal in a.ToCharArray())
            {
                var exists = charDict.TryGetValue(charVal, out int count);

                if (exists)
                {
                    count++;
                    charDict[charVal] = count;
                }
                else
                {
                    charDict.Add(charVal, 1);
                }
            }

            var deletions = 0;

            foreach (var char2 in b.ToCharArray())
            {
                var matching = charDict.TryGetValue(char2, out int count);

                if (matching & count > 0)
                {
                    count--;
                    charDict[char2] = count;
                }
                else
                {
                    deletions++;
                }
            }

            var extraChars = charDict.Where(x => x.Value > 0).Select(y => y.Value).Sum();

            deletions += extraChars;

            return deletions;
        }
    }
}