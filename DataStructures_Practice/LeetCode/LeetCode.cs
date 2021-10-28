using Generics;
using System;
using System.Collections.Generic;

namespace LeetCode
{
    public static class LeetCodePractice
    {
        public static bool CanMakeArithmeticProgression(int[] arr)
        {
            Array.Sort(arr);

            int diff = arr[1] - arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i+1] - arr[i] != diff)
                {
                    return false;
                }
            }
            return true;
        }

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

        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {

            var a = l1;
            var b = l2;
            ListNode temp = null;

            while (a != null)
            {
                if (a.val >= b.val)
                {
                    temp = b.next;
                    b.next = a;
                    b = temp;
                }
                if (b.val >= a.val)
                {
                    temp = a.next;
                    a.next = b;
                    a = temp;
                }
            }

            return l1;
        }

        public static ListNode ReverseList(ListNode head)
        {
            if (head.next == null)
            {
                return head;
            }

            var newHead = ReverseList(head.next);
            var curr = newHead;

            while (curr.next != null)
            {
                curr = curr.next;
            }

            head.next = null;
            curr.next = head;
            return newHead;
        }

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

        public static List<List<int>> BinaryTree_LevelTraversal(TreeNode<int> node)
        {
            var ret = new List<List<int>>();

            var curr = node;
            ret.Add(new List<int>() { node.val });
            while (curr != null)
            {

            }
            return ret;
        }

        public static List<int> BinaryTree_Travesal(TreeNode<int> node, string method)
        {
            List<string> available_methods = new List<string>() { "in order", "pre order", "post order" };

            if (!available_methods.Contains(method.ToLower()))
            {
                throw new NotImplementedException($"Given {method} not available. List includes {String.Join(", ", available_methods)}");
            }

            var ret_list = new List<int>();
            switch(method.ToLower())
            {
                case "in order":
                    BinaryTree_InOrder(node, ret_list);
                    break;
                case "pre order":
                    BinaryTree_PreOrder(node, ret_list);
                    break;
                case "post order":
                    BinaryTree_PostOrder(node, ret_list);
                    break;
            }
            return ret_list;
        }

        private static void BinaryTree_PreOrder(TreeNode<int> node, List<int> nodes)
        {
            if (node == null) { return; }

            nodes.Add(node.val);
            BinaryTree_PreOrder(node.leftChild, nodes);
            BinaryTree_PreOrder(node.rightChild, nodes);
        }

        private static void BinaryTree_PostOrder(TreeNode<int> node, List<int> nodes)
        {
            if (node == null) { return; }

            BinaryTree_PostOrder(node.leftChild, nodes);
            BinaryTree_PostOrder(node.rightChild, nodes);
            nodes.Add(node.val);
        }

        private static void BinaryTree_InOrder(TreeNode<int> node, List<int> nodes)
        {
            if (node == null) { return; }

            BinaryTree_InOrder(node.leftChild, nodes);
            nodes.Add(node.val);
            BinaryTree_InOrder(node.rightChild, nodes);
        }
    }
}
