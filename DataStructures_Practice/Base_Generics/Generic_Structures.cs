using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Generics
{
    public class TreeNode<T> where T : IComparable
    {
        public T val;
        public TreeNode<T> leftChild;
        public TreeNode<T> rightChild;
        public TreeNode(T val, TreeNode<T> leftChild = null, TreeNode<T> rightChild = null)
        {
            this.val = val;
            this.leftChild = leftChild;
            this.rightChild = rightChild;
        }

        //Should these be part of BinaryTree class?
        public void Insert(T val)
        {
            if (val.CompareTo(this.val) < 0)
            {
                if (this.leftChild == null)
                {
                    this.leftChild = new TreeNode<T>(val);
                }
                else
                {
                    this.leftChild.Insert(val);
                }
            }
            else if (val.CompareTo(this.val) > 0)
            {
                if (this.rightChild == null)
                {
                    this.rightChild = new TreeNode<T>(val);
                }
                else
                {
                    this.rightChild.Insert(val);
                }
            }
        }
        public T FindGreatest()
        {
            T max = this.val;
            TreeNode<T> curr = this;
            while (curr.rightChild != null)
            {
                curr = curr.rightChild;
                max = curr.val;
            }
            return max;
        }

        public void Populate(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                this.Insert(arr[i]);
            }
        }
    }
    public class BinaryTree<T> where T: IComparable
    {
        public TreeNode<T> Root { get; set; }

        public void PreOrder_Traverse(TreeNode<T> node, List<T> valList)
        {
            if (node != null)
            {
                valList.Add(node.val);
                PreOrder_Traverse(node.leftChild, valList);
                PreOrder_Traverse(node.rightChild, valList);
            }
        }

        public void PostOrder_Traverse(TreeNode<T> node, List<T> valList)
        {
            if (node != null)
            {
                PostOrder_Traverse(node.leftChild, valList);
                PostOrder_Traverse(node.rightChild, valList);
                valList.Add(node.val);
            }
        }

        public void InOrder_Traverse(TreeNode<T> node, List<T> valList)
        {
            if (node != null)
            {
                InOrder_Traverse(node.leftChild, valList);
                valList.Add(node.val);
                InOrder_Traverse(node.rightChild, valList);
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0)
        {
            this.val = val;
        }
    }

    public class DoubleNode
    {
        public int val;
        public DoubleNode next;
        public DoubleNode prev;
        public DoubleNode(int val = 0)
        {
            this.val = val;
        }
    }

    public class DoublyLinkedList
    {
        public DoubleNode first;
        public DoubleNode last;

        public DoublyLinkedList(DoubleNode first = null, DoubleNode last = null)
        {
            this.first = first;
            this.last = last;
        }

        public string Print_Reverse()
        {
            var values = "";
            var curr = this.last;

            while (curr != null)
            {
                values = string.Concat(values, curr.val);
                curr = curr.prev;
            }
            return values;
        }
    }

    public class LinkedList
    {
        public ListNode firstNode;
        public LinkedList(ListNode firstNode)
        {
            this.firstNode = firstNode;
        }

        public string PrintNodes()
        {
            var values = "";
            var curr = this.firstNode;

            while (curr != null)
            {
                values = string.Concat(values, curr.val.ToString());
                curr = curr.next;
            }
            return values;
        }

        public ListNode GetLast()
        {
            var curr = this.firstNode;

            while (curr.next != null)
            {
                curr = curr.next;
            }

            return curr;
        }

        public LinkedList ReverseLinkedList()
        {
            ListNode prev = null;
            ListNode curr = this.firstNode;
            ListNode next = this.firstNode;

            while (curr != null)
            {
                next = next.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            return new LinkedList(prev);
        }

        public ListNode DeleteFromMiddle(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;

            return this.firstNode;
        }
    }
}
