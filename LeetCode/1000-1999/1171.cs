using LeetCode.Scaffoldings;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/remove-zero-sum-consecutive-nodes-from-linked-list/
    public class _1171
    {
        public ListNode? RemoveZeroSumSublists(ListNode head)
        {
            var front = new ListNode(0, head);
            var left = front;

            while (left is not null)
            {
                var sum = 0;
                var right = left.next;

                while (right is not null)
                {
                    sum += right.val;

                    if (sum == 0)
                    {
                        left.next = right.next;
                    }

                    right = right.next;
                }

                left = left.next;
            }

            return front.next;
        }

        [Test]
        [TestCase("[1,2,-3,3,1]", "[3,1]")]
        [TestCase("[1,2,3,-3,4]", "[1,2,4]")]
        [TestCase("[1,2,3,-3,-2]", "[1]")]
        [TestCase("[1,-1]", "[]")]
        [TestCase("[5,-3,-4,1,6,-2,-5]", "[5,-2,-5]")]
        public void Test(string inputSerialized, string expectedSerialized)
        {
            var head = ListNode.FromString(inputSerialized);

            var result = RemoveZeroSumSublists(head);
            var resultSerialized = ListNode.ToString(result);

            Assert.That(resultSerialized, Is.EqualTo(expectedSerialized));
        }
    }
}
