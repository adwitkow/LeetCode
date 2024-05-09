using System.Text.Json;
using LeetCode.Scaffoldings;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/merge-in-between-linked-lists/
    public class _1669
    {
        public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
        {
            var root = list1;

            var splitNode = list1;
            for (int i = 1; i < a; i++)
            {
                splitNode = splitNode.next;
            }

            var remainder = splitNode;

            for (int i = a; i <= b + 1; i++)
            {
                remainder = remainder.next;
            }

            splitNode.next = list2;

            var lastList2Node = list2;
            while (lastList2Node.next is not null)
            {
                lastList2Node = lastList2Node.next;
            }

            lastList2Node.next = remainder;

            return root;
        }

        [Test]
        [TestCase("[10,1,13,6,9,5]", 3, 4, "[1000000,1000001,1000002]", "[10,1,13,1000000,1000001,1000002,5]")]
        [TestCase("[0,1,2,3,4,5,6]", 2, 5, "[1000000,1000001,1000002,1000003,1000004]", "[0,1,1000000,1000001,1000002,1000003,1000004,6]")]
        public void Test(string rawList1, int a, int b, string rawList2, string rawExpected)
        {
            var list1 = ListNode.FromString(rawList1);
            var list2 = ListNode.FromString(rawList2);
            var expected = ListNode.FromString(rawExpected);

            var result = MergeInBetween(list1, a, b, list2);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
