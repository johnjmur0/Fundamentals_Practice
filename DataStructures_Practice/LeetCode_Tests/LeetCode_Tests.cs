using Generics;
using LeetCode;
using Xunit;

namespace UnitTests
{
    public class LeetCode_Tests
    {
        [Fact]
        public void ReverseLinkedList()
        {
            var n5 = new ListNode(val: 5);
            var n4 = new ListNode(val: 4, next: n5);
            var n3 = new ListNode(val: 3, next: n4);
            var n2 = new ListNode(val: 2, next: n3);
            var n1 = new ListNode(val: 1, next: n2);

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
    }
}
