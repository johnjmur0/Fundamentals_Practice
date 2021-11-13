using Generics;
using System;
using System.Collections.Generic;
using LeetCode;
using Xunit;

namespace LeetCode_Tests
{
    public class LC_Trees_Tests
    {
        private void Execute_traversal(TreeNode<int> root, List<int> inOrder_expected, List<int> preOrder_expected, List<int> postOrder_expected)
        {
            var inOrder_result = LC_Trees.BinaryTree_Travesal(root, "in order");
            var preOrder_result = LC_Trees.BinaryTree_Travesal(root, "pre order");
            var postOrder_result = LC_Trees.BinaryTree_Travesal(root, "post order");

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

            var result = LC_Trees.BinaryTree_LevelTraversal(root);
            Assert.Equal(expected, result);

            TreeNode<int> five = new TreeNode<int>(5);
            TreeNode<int> four = new TreeNode<int>(4);
            TreeNode<int> three = new TreeNode<int>(3, rightChild: five);
            TreeNode<int> two = new TreeNode<int>(2, leftChild: four);
            root = new TreeNode<int>(1, leftChild: two, rightChild: three);

            expected = new List<List<int>>()
            {
                new List<int>() { 1 },
                new List<int>() { 2, 3 },
                new List<int>() { 4, 5 },
            };

            result = LC_Trees.BinaryTree_LevelTraversal(root);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_BinaryTree_Symmetrical_Good()
        {
            TreeNode<int> four_1 = new TreeNode<int>(4);
            TreeNode<int> four_2 = new TreeNode<int>(4);

            TreeNode<int> three_1 = new TreeNode<int>(3);
            TreeNode<int> three_2 = new TreeNode<int>(3);

            TreeNode<int> two_1 = new TreeNode<int>(2, leftChild: three_1, rightChild: four_1);
            TreeNode<int> two_2 = new TreeNode<int>(2, leftChild: four_2, rightChild: three_2);

            TreeNode<int> one = new TreeNode<int>(1, leftChild: two_1, rightChild: two_2);

            var expected = true;

            var result = LC_Trees.BinaryTree_IsSymmetric(one);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_BinaryTree_Symmetrical_Bad()
        {
            TreeNode<int> three_1 = new TreeNode<int>(3);
            TreeNode<int> three_2 = new TreeNode<int>(3);

            TreeNode<int> two_1 = new TreeNode<int>(2, rightChild: three_1);
            TreeNode<int> two_2 = new TreeNode<int>(2, rightChild: three_2);

            TreeNode<int> one = new TreeNode<int>(1, leftChild: two_1, rightChild: two_2);

            bool expected = false;

            bool result = LC_Trees.BinaryTree_IsSymmetric(one);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_BinaryTree_Symmetrical_Bad_2()
        {
            //TODO would love way to make binary tree based on leet code array, but not super easy
            TreeNode<int> nine_1 = new TreeNode<int>(9);
            TreeNode<int> nine_2 = new TreeNode<int>(9);
            TreeNode<int> eight_1 = new TreeNode<int>(8);
            TreeNode<int> eight_2 = new TreeNode<int>(8);

            TreeNode<int> five_1 = new TreeNode<int>(5, leftChild: eight_1, rightChild: nine_1);
            TreeNode<int> five_2 = new TreeNode<int>(5);
            TreeNode<int> four_1 = new TreeNode<int>(4);
            TreeNode<int> four_2 = new TreeNode<int>(4, leftChild: nine_2, rightChild: eight_2);

            TreeNode<int> three_1 = new TreeNode<int>(3, leftChild: four_1, rightChild: five_1);
            TreeNode<int> three_2 = new TreeNode<int>(3, leftChild: five_2, rightChild: four_2);

            TreeNode<int> two = new TreeNode<int>(2, leftChild: three_1, rightChild: three_2);

            bool expected = false;

            bool result = LC_Trees.BinaryTree_IsSymmetric(two);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_BinaryTree_FromArray()
        {
            var test_arr = new int?[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, null, null, 1 };

            //mock out most of this tree
            TreeNode<int> expected = new TreeNode<int>(val: 5);

            TreeNode<int> result = LC_Trees.MakeTree_FromArray(test_arr);

            result.val = expected.val;
            result.leftChild.leftChild.leftChild.val = 7;
            result.leftChild.rightChild = null;

            result.rightChild.rightChild.rightChild.val = 1;
            result.rightChild.leftChild.val = 13;
            result.rightChild.leftChild.rightChild = null;
        }

        [Fact]
        public void Test_BinaryTree_HasPathSum_True()
        {
            var tree_arr = new int?[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, null, null, 1 };

            TreeNode<int> test_root = LC_Trees.MakeTree_FromArray(tree_arr);

            int test_target = 22;
            bool expected = true;

            bool result = LC_Trees.HasPathSum(test_root, test_target);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_BinaryTree_HasPathSum_Single()
        {
            var tree_arr = new int?[] { 1 };

            TreeNode<int> test_root = LC_Trees.MakeTree_FromArray(tree_arr);

            int test_target = 1;
            bool expected = true;

            bool result = LC_Trees.HasPathSum(test_root, test_target);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_BinaryTree_HasPathSum_False()
        {
            var tree_arr = new int?[] { 1, 2, 3 };

            TreeNode<int> test_root = LC_Trees.MakeTree_FromArray(tree_arr);

            int test_target = 5;
            bool expected = false;

            bool result = LC_Trees.HasPathSum(test_root, test_target);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_BinaryTree_HasPathSum_False_2()
        {
            var tree_arr = new int?[] { 1, 2 };

            TreeNode<int> test_root = LC_Trees.MakeTree_FromArray(tree_arr);

            int test_target = 0;
            bool expected = false;

            bool result = LC_Trees.HasPathSum(test_root, test_target);

            Assert.Equal(expected, result);
        }
    }
}
