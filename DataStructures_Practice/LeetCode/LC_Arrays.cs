using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class LC_Arrays
    {
        //TODO Untested
        public static bool CanMakeArithmeticProgression(int[] arr)
        {
            Array.Sort(arr);

            int diff = arr[1] - arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i + 1] - arr[i] != diff)
                {
                    return false;
                }
            }
            return true;
        }

        //TODO Untested
        public static int SearchInsert(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] > target)
                {
                    high = mid - 1;
                }
                else if (nums[mid] < target)
                {
                    low = mid + 1;
                }
            }
            return low;
        }

        //TODO Untested
        public static int MaxSubArray(int[] nums)
        {
            int max = nums[0];
            int sum = max;

            for (int i = 1; i < nums.Length; i++)
            {
                sum = Math.Max(nums[i] + sum, nums[i]);
                max = Math.Max(sum, max);
            }

            return max;
        }

        //TODO Untested
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int num1Pointer = m - 1;
            int num2Pointer = n - 1;
            int endofNum1 = m + n - 1;

            while (num1Pointer >= 0 && num2Pointer >= 0)
            {
                //num1 has bigger val, move to end
                if (nums1[num1Pointer] > nums2[num2Pointer])
                {
                    nums1[endofNum1] = nums1[num1Pointer];
                    num1Pointer--;
                }
                //num2 has bigger value, move to end
                else
                {
                    nums1[endofNum1] = nums2[num2Pointer];
                    num2Pointer--;
                }
                endofNum1--;
            }

            while (num2Pointer >= 0)
            {
                nums1[endofNum1] = nums2[num2Pointer];
                endofNum1--;
                num2Pointer--;
            }
        }

        //TODO Untested
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            var curr = 1;
            var unique = 0;

            while (curr <= nums.Length - 1)
            {
                while (nums[curr] == nums[unique])
                {
                    if (curr == nums.Length - 1)
                    {
                        return unique + 1;
                    }
                    curr++;
                }
                nums[unique + 1] = nums[curr];
                unique++;
            }

            return unique + 1;
        }
    }
}
