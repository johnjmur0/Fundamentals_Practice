using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA_Wengrow
{
    public static class Ch_19_Memory_Opt
    {
        // Take O(1) space
        public static int[] Reverse_Array(int[] arr)
        {
            var head = 0;
            var tail = arr.Length - 1;

            while (tail > head)
            {
                var tail_var = arr[tail];
                arr[tail] = arr[head];
                arr[head] = tail_var;

                head++;
                tail--;
            }
            return arr;
        }
    }

    // Do all in O(n), O(n + m) for two_sport_players
    public static class Ch_20_Time_Opt
    {

        public static List<string> Two_Sport_Players(Dictionary<string, string>[] sport_1, Dictionary<string, string>[] sport_2)
        {

            var matches = new List<string>();

            var map_dict = new Dictionary<string, int>();

            foreach (var player in sport_1)
            {
                var full_name = player["first_name"] + " " + player["last_name"];

                if (map_dict.TryGetValue(full_name, out int count))
                {
                    map_dict[full_name] = count + 1;
                }
                else
                {
                    map_dict[full_name] = 1;
                }
            }

            foreach (var player in sport_2)
            {
                var full_name = player["first_name"] + " " + player["last_name"];

                if (map_dict.TryGetValue(full_name, out int count))
                {
                    matches.Add(full_name);
                }
            }

            return matches;
        }

        public static int? Find_Missing_Int(int[] arr)
        {
            return null;
        }

        public static int Find_Max_Sell(int[] arr)
        {
            return 0;
        }

        public static int Get_Highest_Product(int[] arr)
        {
            return 0;
        }

        public static double[] Sort_Temps(double[] arr)
        {
            return arr;
        }

        public static int[] Find_Longest_Sequence(int[] arr)
        {
            return arr;
        }
    }
}