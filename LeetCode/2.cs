using System.Text;
using System.Text.Json;
using NUnit.Framework;

namespace LeetCode
{
    public class _2
    {
        // https://leetcode.com/problems/add-two-numbers/
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int carry = 0;

            var result = new ListNode();
            var currentNode = result;
            while (currentNode is not null)
            {
                var value1 = GetValue(ref l1);
                var value2 = GetValue(ref l2);
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

        private int GetValue(ref ListNode node)
        {
            int result = 0;
            if (node is not null)
            {
                result = node.val;
                node = node.next;
            }

            return result;
        }

        [Test]
        [TestCase("[2,4,3]", "[5,6,4]", "[7,0,8]")]
        [TestCase("[0]", "[0]", "[0]")]
        [TestCase("[9,9,9,9,9,9,9]", "[9,9,9,9]", "[8,9,9,9,0,0,0,1]")]
        public void Test(string l1Serialized, string l2Serialized, string expectedSerialized)
        {
            var l1 = StringToListNode(l1Serialized);
            var l2 = StringToListNode(l2Serialized);

            var result = AddTwoNumbers(l1, l2);
            var resultSerialized = ListNodeToString(result);

            Assert.That(resultSerialized, Is.EqualTo(expectedSerialized));
        }

        public static string ListNodeToString(ListNode listNode)
        {
            var current = listNode;

            var builder = new StringBuilder();
            builder.Append('[');
            while (current is not null)
            {
                builder.Append(current.val);
                if (current.next is not null)
                {
                    builder.Append(',');
                }

                current = current.next;
            }
            builder.Append(']');

            return builder.ToString();
        }

        public static ListNode StringToListNode(string input)
        {
            var digits = JsonSerializer.Deserialize<int[]>(input);

            var result = new ListNode();
            var currentNode = result;
            for (int i = 0; i < digits.Length; i++)
            {
                var digit = digits[i];

                currentNode.val = digit;
                
                if (i != digits.Length - 1)
                {
                    var nextNode = new ListNode();
                    currentNode.next = nextNode;
                    currentNode = nextNode;
                }
            }

            return result;
        }
    }

    // Class provided by LeetCode (except for ToString)
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public override string ToString()
        {
            return _2.ListNodeToString(this);
        }
    }
}
