using Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSA_Wengrow
{
    public static class Ch_15_BST
    {
        public static TreeNode<int> ConstructBalancedTree(int[] values, int min, int max)
        {
            if (min == max)
                return null;

            int median = min + (max - min) / 2;

            return new TreeNode<int>(values[median])
            {
                leftChild = ConstructBalancedTree(values, min, median),
                rightChild = ConstructBalancedTree(values, median + 1, max)
            };
        }
    }
}
