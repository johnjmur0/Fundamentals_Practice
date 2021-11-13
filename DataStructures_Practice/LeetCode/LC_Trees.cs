using Generics;
using System;
using System.Collections.Generic;

namespace LeetCode
{
    public static class LC_Trees
    {
        public static List<int> BinaryTree_Travesal(TreeNode<int> node, string method)
        {
            List<string> available_methods = new List<string>() { "in order", "pre order", "post order" };

            if (!available_methods.Contains(method.ToLower()))
            {
                throw new NotImplementedException($"Given {method} not available. List includes {String.Join(", ", available_methods)}");
            }

            var ret_list = new List<int>();
            switch (method.ToLower())
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

        public static IList<IList<int>> BinaryTree_LevelTraversal(TreeNode<int> node)
        {
            var ret = new List<IList<int>>();

            if (node == null) { return ret; }

            ret.Add(new List<int>() { node.val });

            BinaryTree_LevelTraversal_Helper(node.leftChild, ret);
            BinaryTree_LevelTraversal_Helper(node.rightChild, ret);

            return ret;
        }

        private static void BinaryTree_LevelTraversal_Helper(TreeNode<int> node, List<IList<int>> ret, int depth = 0)
        {
            if (node == null) { return; }

            if (ret.Count == ++depth) { ret.Add(new List<int>()); }

            ret[depth].Add(node.val);

            BinaryTree_LevelTraversal_Helper(node.leftChild, ret, depth);
            BinaryTree_LevelTraversal_Helper(node.rightChild, ret, depth);
        }

        public static bool BinaryTree_IsSymmetric(TreeNode<int> root)
        {
            if (root == null) { return true; }

            var levelList = new List<List<int>>();
            levelList.Add(new List<int>() { root.val });

            BinaryTree_IsSymmetric_Helper(root.leftChild, levelList);
            BinaryTree_IsSymmetric_Helper(root.rightChild, levelList);

            foreach (var level in levelList)
            {
                for (int i = 0; i < level.Count / 2; i++)
                {
                    if (level[i] != level[level.Count - i - 1])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void BinaryTree_IsSymmetric_Helper(TreeNode<int> node, List<List<int>> levelList, int depth = 0)
        {
            if (levelList.Count == ++depth) { levelList.Add(new List<int>()); }

            if (node != null)
            {
                levelList[depth].Add(node.val);
            }
            else
            {
                //question specifies min value = -100
                levelList[depth].Add(-101);
            }

            if (node == null)
            {
                return;
            }

            BinaryTree_IsSymmetric_Helper(node.leftChild, levelList, depth);
            BinaryTree_IsSymmetric_Helper(node.rightChild, levelList, depth);
        }

        public static TreeNode<int> MakeTree_FromArray(int?[] inputs)
        {
            if (inputs.Length == 0)
            {
                throw new ArgumentOutOfRangeException("input arr is empty. What are you doing?");
            }

            return MakeTree_FromArray_Helper(inputs, 0);
        }

        private static TreeNode<int> MakeTree_FromArray_Helper(int?[] inputs, int pos)
        {
            if (pos >= inputs.Length || inputs[pos] == null) { return null; }

            return new TreeNode<int>(
                val: (int)inputs[pos],
                leftChild: MakeTree_FromArray_Helper(inputs, pos * 2 + 1),
                rightChild: MakeTree_FromArray_Helper(inputs, pos * 2 + 2));
        }

        public static bool HasPathSum(TreeNode<int> root, int target)
        {
            if (root == null) { return false; }

            if (root.leftChild == null & root.rightChild == null)
            {
                return root.val == target;
            }

            List<int> branch_sum_list = new List<int>();

            HasPathSum_Helper(root.leftChild, target, branch_sum_list, root.val);
            HasPathSum_Helper(root.rightChild, target, branch_sum_list, root.val);

            return branch_sum_list.Exists(x => x == target);
        }

        private static void HasPathSum_Helper(TreeNode<int> node, int target, List<int> branch_sum_list, int branch_sum)
        {
            if (node == null) { return; }

            branch_sum += node.val;

            //its a leaf
            if (node.leftChild == null & node.rightChild == null)
            {
                branch_sum_list.Add(branch_sum);
            }

            HasPathSum_Helper(node.leftChild, target, branch_sum_list, branch_sum);
            HasPathSum_Helper(node.rightChild, target, branch_sum_list, branch_sum);
        }
    }
}
