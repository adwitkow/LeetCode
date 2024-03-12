using System.Text;
using System.Text.Json;

namespace LeetCode.Scaffoldings
{
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
#pragma warning disable SA1401 // Fields should be private

    /// <summary>
    /// Typical ListNode class provided by LeetCode.
    /// </summary>
    public class ListNode
    {
        // Don't worry, these public fields bother me as well.
        public int val;
        public ListNode? next;

        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }

        public static string ToString(ListNode? listNode)
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

        public static ListNode FromString(string input)
        {
            var digits = JsonSerializer.Deserialize<int[]>(input)!;

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

        public override string ToString()
        {
            return ToString(this);
        }
    }
}
