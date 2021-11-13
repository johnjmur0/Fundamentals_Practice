using Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class LC_LinkedList
    {
        //TODO Untested
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
    }
}
