using Generics;
using LeetCode;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class LeetCode_Tests
    {
        [Fact]
        public void ReverseLinkedList()
        {
            var n5 = new ListNode(val: 5);
            var n4 = new ListNode(val: 4);
            n4.next = n5;
            var n3 = new ListNode(val: 3);
            n3.next = n4;
            var n2 = new ListNode(val: 2);
            n2.next = n3;
            var n1 = new ListNode(val: 1);
            n1.next = n2;

            var revListHead = LeetCodePractice.ReverseList(n1);

            var curr = revListHead;
            var expected = 5;
            while (curr != null)
            {
                Assert.Equal(expected, curr.val);
                curr = curr.next;
                expected -= 1;
            }
        }

        [Fact]
        public void Test_RemoveDupes()
        {
            int[] input = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int expected = 5;
            int[] expected_nums = new int[] { 0, 1, 2, 3, 4, 0, 0, 0, 0, 0 };

            var result = LeetCodePractice.RemoveDuplicates(input);

            Assert.Equal(expected, result);

            input = new int[] { 1, 1, 2 };
            result = LeetCodePractice.RemoveDuplicates(input);

            input = new int[] { 1, 2 };
            result = LeetCodePractice.RemoveDuplicates(input);
        }

        private void Execute_traversal(TreeNode<int> root, List<int> inOrder_expected, List<int> preOrder_expected, List<int> postOrder_expected)
        {
            var inOrder_result = LeetCodePractice.BinaryTree_Travesal(root, "in order");
            var preOrder_result = LeetCodePractice.BinaryTree_Travesal(root, "pre order");
            var postOrder_result = LeetCodePractice.BinaryTree_Travesal(root, "post order");

            Assert.Equal(inOrder_expected, inOrder_result);
            Assert.Equal(preOrder_expected, preOrder_result);
            Assert.Equal(postOrder_expected, postOrder_result);
        }

        [Fact]
        public void Test_BinaryTree_Traversal()
        {
            TreeNode<int> three = new TreeNode<int>(3);
            TreeNode<int> two = new TreeNode<int>(2, leftChild: three);
            TreeNode<int> root = new TreeNode<int>(1, rightChild: two);
            
            var inOrder_expected = new List<int>() { 1, 3, 2 };
            var preOrder_expected = new List<int>() { 1, 2, 3 };
            var postOrder_expected = new List<int>() { 3, 2, 1 };

            this.Execute_traversal(root, inOrder_expected, preOrder_expected, postOrder_expected);
        }

        [Fact]
        public void Test_BinaryTree_LevelOrder()
        {
            TreeNode<int> fifteen = new TreeNode<int>(15);
            TreeNode<int> seven = new TreeNode<int>(7);
            TreeNode<int> nine = new TreeNode<int>(9);
            TreeNode<int> twenty = new TreeNode<int>(20, leftChild: fifteen, rightChild: seven);
            TreeNode<int> root = new TreeNode<int>(3, rightChild: twenty, leftChild: nine);

            var expected = new List<List<int>>()
            {
                new List<int>() { 3 },
                new List<int>() { 9, 20 },
                new List<int>() { 15, 7 },
            };

            var result = LeetCodePractice.BinaryTree_LevelTraversal(root);
            Assert.Equal(expected, result);
        }
    }
}
