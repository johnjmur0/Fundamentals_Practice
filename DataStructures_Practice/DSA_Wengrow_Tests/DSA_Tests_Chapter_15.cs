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
        /*      1
         *        5           
         *    2      9
         *     4   6   10 
         *    3   8
         */         
        [Fact]
        public void Test_Insert()
        {
            int[] input = new int[] { 5, 9, 2, 4, 10, 6, 3, 8};
            TreeNode<int> testRoot = new TreeNode<int>(1);
            testRoot.Populate(input);

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
            TreeNode<int> balanced = Chapter_15_BST.ConstructBalancedTree(input, 1, 1000);

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
            int[] input = new int[] { 5, 9, 2, 4, 10, 6, 3, 8 };
            TreeNode<int> testRoot = new TreeNode<int>(1);
            testRoot.Populate(input);

            var result = testRoot.FindGreatest();
            var expected = 10;
            Assert.Equal(expected, result);

            input = Enumerable.Range(1, 1000).ToArray();
            TreeNode<int> balanced = Chapter_15_BST.ConstructBalancedTree(input, 1, 1000);

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
            string[] input = new string[] { "B", "A", "D", "C", "E", "G", "I", "H"  };
            TreeNode<string> testRoot = new TreeNode<string>("F");
            testRoot.Populate(input);

            var binaryTree = new BinaryTree<string>();

            List<string> valList = new List<string>();
            binaryTree.PreOrder_Traverse(testRoot, valList);
            var result = String.Join("", valList);
            string preOrder = "FBADCEGIH";
            Assert.Equal(preOrder, result);
            valList.Clear();

            binaryTree.PostOrder_Traverse(testRoot, valList);
            result = String.Join("", valList);
            string postOrder = "ACEDBHIGF";
            Assert.Equal(postOrder, result);
            valList.Clear();

            binaryTree.InOrder_Traverse(testRoot, valList);
            result = String.Join("", valList);
            string inOrder = "ABCDEFGHI";
            Assert.Equal(inOrder, result);
        }
    }
}
