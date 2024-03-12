using LeetCode.Scaffoldings;
using NUnit.Framework;

namespace LeetCode._1_9
{
    // https://leetcode.com/problems/add-two-numbers/
    public class _2
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int carry = 0;

            var result = new ListNode();
            var currentNode = result;
            while (currentNode is not null)
            {
                var value1 = GetValue(ref l1!);
                var value2 = GetValue(ref l2!);
                var sum = value1 + value2 + carry;

                if (sum > 9)
                {
                    carry = 1;
                    sum -= 10;
                }
                else
                {
                    carry = 0;
                }

                currentNode.val = sum;

                if (l1 is not null || l2 is not null || carry > 0)
                {
                    currentNode.next = new ListNode();
                    currentNode = currentNode.next;
                }
                else
                {
                    currentNode = null;
                }
            }

            return result;
        }

        private int GetValue(ref ListNode? node)
        {
            int result = 0;
            if (node is not null)
            {
                result = node.val;
                node = node.next;
            }

            return result;
        }

#pragma warning disable SA1202 // Elements should be ordered by access
        [Test]
        [TestCase("[2,4,3]", "[5,6,4]", "[7,0,8]")]
        [TestCase("[0]", "[0]", "[0]")]
        [TestCase("[9,9,9,9,9,9,9]", "[9,9,9,9]", "[8,9,9,9,0,0,0,1]")]
        public void Test(string l1Serialized, string l2Serialized, string expectedSerialized)
        {
            var l1 = ListNode.FromString(l1Serialized);
            var l2 = ListNode.FromString(l2Serialized);

            var result = AddTwoNumbers(l1, l2);
            var resultSerialized = ListNode.ToString(result);

            Assert.That(resultSerialized, Is.EqualTo(expectedSerialized));
        }
    }
}
