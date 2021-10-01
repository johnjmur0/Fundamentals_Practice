using System;
using System.Collections.Generic;
using System.Linq;

namespace TestNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool CanMakeArithmeticProgression(int[] arr)
        {
            var diffList = new List<int>();

            if (arr.Length < 3) { return true; }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    diffList.Add(Math.Abs(arr[i] - arr[j]));
                }
            }

            var dupes = diffList.GroupBy(x => x)
                .Where(x => x.Count() > 1)
                .SelectMany(y => y)
                .Distinct();

            foreach (var diff in dupes) { Console.WriteLine(diff); }

            return (dupes.ToList().Exists(x => x == (arr.Length - 1)));
        }
    }
}
