using System.Text.Json;

namespace LeetCode.Scaffoldings
{
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
#pragma warning disable SA1401 // Fields should be private

    /// <summary>
    /// Typical ListNode class provided by LeetCode.
    /// </summary>
    public class TreeNode
    {
        // Don't worry, these public fields bother me as well.
        public int val;
        public TreeNode? left;
        public TreeNode? right;

        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public static string ToString(TreeNode? treeNode)
        {
            throw new NotImplementedException(); // TODO
        }

        public static TreeNode FromString(string input)
        {
            var numbers = JsonSerializer.Deserialize<int?[]>(input)!;
            if (numbers.Length == 0)
            {
                return new TreeNode(0);
            }

            var firstValue = numbers[0].GetValueOrDefault();
            var root = new TreeNode(firstValue);

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            var index = 1;
            while (index < numbers.Length)
            {
                var currentNode = queue.Dequeue();

                var number = numbers[index];
                if (index < numbers.Length && number is not null)
                {
                    var child = new TreeNode(number.Value);
                    currentNode.left = child;
                    queue.Enqueue(child);
                }

                index++;

                number = numbers[index];
                if (index < numbers.Length && number is not null)
                {
                    var child = new TreeNode(number.Value);
                    currentNode.right = child;
                    queue.Enqueue(child);
                }

                index++;
            }

            return root;
        }
    }
}
