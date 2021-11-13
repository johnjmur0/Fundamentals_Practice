using Generics;
using LeetCode;
using Xunit;

namespace LeetCode_Tests
{
    public class LC_LinkedList_Tests
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

            var revListHead = LC_LinkedList.ReverseList(n1);

            var curr = revListHead;
            var expected = 5;
            while (curr != null)
            {
                Assert.Equal(expected, curr.val);
                curr = curr.next;
                expected -= 1;
            }
        }
    }
}
