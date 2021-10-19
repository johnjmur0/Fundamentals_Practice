using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Generics;
using System.Linq;
using DSA_Wengrow;

namespace DSA_Wengrow_Tests
{
    public class DSA_Tests_Chapter_15
    {
        private TreeNode Create(int[] arr)
        {
            TreeNode root = new TreeNode(arr[0]);

            for (int i = 1; i < arr.Length; i++)
            {
                root.Insert(arr[i]);
            }

            return root;
        }

        /*      1
         *        5           
         *    2      9
         *     4   6   10 
         *    3   8
         */         
        [Fact]
        public void Test_Insert()
        {
            int[] input = new int[] { 1, 5, 9, 2, 4, 10, 6, 3, 8};
            TreeNode testRoot = this.Create(input);

            Assert.Null(testRoot.leftChild);
            Assert.Equal(10, testRoot.rightChild.rightChild.rightChild.val);
            Assert.Equal(2, testRoot.rightChild.leftChild.val);
            Assert.Equal(3, testRoot.rightChild.leftChild.rightChild.leftChild.val);
        }

        /*
        * for a well-balanced tree with 1000 values, how long will search take?
        * log(1000, base=2) = 10
        * Equal to number of levels of tree
        */
        [Fact]
        public void Test_Search_1000()
        {
            int[] input = Enumerable.Range(1, 1000).ToArray();
            TreeNode balanced = Chapter_15_BST.ConstructBalancedTree(input, 1, 1000);

            int levels = 1;
            var curr = balanced;
            while (curr.rightChild != null)
            {
                curr = curr.rightChild;
                levels++;
            }

            Assert.True(levels >= 9 & levels <= 11);
        }

        [Fact]
        public void Test_FindMax()
        {
            int[] input = new int[] { 1, 5, 9, 2, 4, 10, 6, 3, 8 };
            TreeNode testRoot = this.Create(input);

            var result = testRoot.FindGreatest();
            var expected = 10;
            Assert.Equal(expected, result);

            input = Enumerable.Range(1, 1000).ToArray();
            TreeNode balanced = Chapter_15_BST.ConstructBalancedTree(input, 1, 1000);

            result = balanced.FindGreatest();
            expected = 1000;
            Assert.Equal(expected, result);
        }

        /*
         * InOrder: Traverse left, visit root, traverse right
         * PreOrder: visit root, traverse left, traverse right
         * PostOrder: traverse left, traverse right, visit root
         */
        //TODO - should InOrder and PreOrder be the same, or just a coincidence?
        [Fact]
        public void Test_Traversals()
        {
            int[] input = new int[] { 1, 5, 9, 2, 4, 10, 6, 3, 8 };
            TreeNode testRoot = this.Create(input);
            var binaryTree = new BinaryTree();

            List<int> valList = new List<int>();
            binaryTree.PreOrder_Traverse(testRoot, valList);
            var result = String.Join("", valList);
            string preOrder = "1524396810";
            Assert.Equal(preOrder, result);
            valList.Clear();

            binaryTree.PostOrder_Traverse(testRoot, valList);
            result = String.Join("", valList);
            string postOrder = "5243968101";
            Assert.Equal(postOrder, result);
            valList.Clear();

            binaryTree.InOrder_Traverse(testRoot, valList);
            result = String.Join("", valList);
            string inOrder = "1524396810";
            Assert.Equal(inOrder, result);
        }
    }
}
