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
            int expected_sum = 0;
            int actual_sum = 0;

            for (int i = 1; i <= arr.Length; i++)
            {
                expected_sum += i;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                actual_sum += arr[i];
            }

            return expected_sum - actual_sum;
        }

        public static int Find_Max_Sell(int[] arr)
        {
            var largest_profit = int.MinValue;

            var min_buy = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                var day_profit = arr[i] - min_buy;

                if (day_profit > largest_profit)
                {
                    largest_profit = day_profit;
                }

                if (arr[i] < min_buy)
                {
                    min_buy = arr[i];
                }
            }

            return largest_profit;
        }

        public static int Get_Highest_Product(int[] arr)
        {
            var lowest = int.MaxValue;
            var second_lowest = int.MaxValue;

            var highest = int.MinValue;
            var second_highest = int.MinValue;

            for (int i = 0; i < arr.Length; i++)
            {

                if (arr[i] < lowest)
                {
                    lowest = arr[i];
                }

                else if (arr[i] > lowest & arr[i] < second_lowest)
                {
                    second_lowest = arr[i];
                }

                else if (arr[i] > highest)
                {
                    highest = arr[i];
                }

                else if (arr[i] < highest & arr[i] > second_highest)
                {
                    second_highest = arr[i];
                }
            }

            var lowest_product = lowest * second_lowest;
            var highest_product = highest * second_highest;

            return Math.Max(lowest_product, highest_product);
        }

        public static double[] Sort_Temps(double[] arr)
        {
            var temp_dict = new Dictionary<double, int>();

            foreach (var temp in arr)
            {
                if (temp_dict.TryGetValue(temp, out int count))
                {
                    temp_dict[temp] += 1;
                }
                else
                {
                    temp_dict[temp] = 1;
                }
            }

            var temp_min = 97.0;
            var temp_max = 99.0;

            var sorted_temps = new List<double>();

            while (temp_min <= temp_max)
            {
                if (temp_dict.TryGetValue(temp_min, out int count))
                {
                    for (int i = 0; i < count; i++)
                    {
                        sorted_temps.Add(temp_min);
                    }
                }
                temp_min = Math.Round(temp_min += .1, 1);

            }

            return sorted_temps.ToArray();
        }

        public static int Find_Longest_Sequence(int[] arr)
        {
            int max_seq_len = 0;
            var arr_dict = new Dictionary<int, bool>();

            foreach (int val in arr)
            {
                if (!arr_dict.TryGetValue(val, out bool exists))
                {
                    arr_dict[val] = true;
                }
            }

            foreach (int val in arr)
            {
                if (!arr_dict.TryGetValue(val - 1, out bool exists_min))
                {
                    var curr_seq_len = 1;

                    var curr_num = val;

                    while (arr_dict.TryGetValue(curr_num + 1, out bool exists_next))
                    {
                        curr_seq_len += 1;
                        curr_num += 1;

                        if (curr_seq_len > max_seq_len)
                        {
                            max_seq_len = curr_seq_len;
                        }
                    }
                }
            }

            return max_seq_len;
        }
    }
}