using System.Text.Json;
using LeetCode.Scaffoldings;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/palindrome-linked-list/
    public class _234
    {
        public bool IsPalindrome(ListNode head)
        {
            var list = new List<int>()
            {
                head.val,
            };

            ListNode? node = head;
            while ((node = node!.next) is not null)
            {
                list.Add(node.val);
            }

            return IsPalindrome(list);
        }

        private bool IsPalindrome(List<int> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] != input[input.Count - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        [Test]
        [TestCase("[1,2,2,1]", true)]
        [TestCase("[1,2]", false)]
        public void Test(string rawHead, bool expected)
        {
            var head = ListNode.FromString(rawHead);

            var result = IsPalindrome(head);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
