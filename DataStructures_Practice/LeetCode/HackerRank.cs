using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    //TODO Dig up problems for these and test
    class HackerRank
    {
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
            var longerString = (s1.Length > s2.Length) ? s1 : s2;
            var shorterString = (s1.Length > s2.Length) ? s2 : s1;

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

        //This defintiely doesn't seem right, try to fix
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
