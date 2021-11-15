using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Generics;

namespace DSA_Wengrow_Tests
{
    public class DSA_Tests_LinkedList
    {
        private LinkedList Get_LinkedList(int length)
        {
            var head = new ListNode(length);

            for (int i = length - 1; i >= 0; i--)
            {
                var node = new ListNode(i);
                node.next = head;
                head = node;
            }
            return new LinkedList(head);
        }

        private DoublyLinkedList Get_DoublyLinkedList(int length)
        {
            var head = new DoubleNode(length);
            var tail = head;

            for (int i = length - 1; i >= 0; i--)
            {
                var node = new DoubleNode(i);
                node.next = head;
                head.prev = node;
                head = node;
            }
            return new DoublyLinkedList(head, tail);
        }
        //Whats the better way to test print methods?
        [Fact]
        public void Test_LinkedList_Print()
        {
            var linkedList = this.Get_LinkedList(5);
            var expected = "012345";
            var result = linkedList.PrintNodes();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_GetLast()
        {
            var linkedList = this.Get_LinkedList(5);
            var expected = 5;
            var result = linkedList.GetLast();
            Assert.Equal(expected, result.val);
        }

        [Fact]
        public void Test_DoublyLinkedList_Print_Reverse()
        {
            var doubleList = this.Get_DoublyLinkedList(5);
            var expected = "543210";
            var result = doubleList.Print_Reverse();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_Reverse_List()
        {
            var linkedList = this.Get_LinkedList(5);
            var revList = linkedList.ReverseLinkedList();
            
            var result = revList.PrintNodes();
            
            var expected = "543210";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_Delete_Middle()
        {
            var linkedList = this.Get_LinkedList(5);
            var middleNode = linkedList.firstNode.next.next.next;
            
            linkedList.DeleteFromMiddle(middleNode);
            
            var result = linkedList.PrintNodes();
            var expected = "01245";
            Assert.Equal(expected, result);
        }
    }
}
