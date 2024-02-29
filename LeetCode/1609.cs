using System.Text.Json;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/even-odd-tree/
    internal class _1609
    {
        public bool IsEvenOddTree(TreeNode root)
        {
            var level = 0;
            var currentNodes = new TreeNode[]
            {
                root
            };

            List<TreeNode> nextNodes;
            while (currentNodes.Any(node => node is not null))
            {
                nextNodes = new List<TreeNode>();
                // level even: nodes odd,  increasing
                // level odd:  nodes even, decreasing
                var levelEven = level % 2 == 0;

                var firstNode = currentNodes[0];
                if (firstNode.left is not null)
                {
                    nextNodes.Add(firstNode.left);
                }

                if (firstNode.right is not null)
                {
                    nextNodes.Add(firstNode.right);
                }

                var previousValue = firstNode.val;

                if (currentNodes.Length == 1)
                {
                    var nodeEven = previousValue % 2 == 0;
                    var isEvenOdd = (levelEven && !nodeEven)
                            || (!levelEven && nodeEven);

                    if (!isEvenOdd)
                    {
                        return false;
                    }
                }
                else
                {
                    for (int i = 1; i < currentNodes.Length; i++)
                    {
                        var node = currentNodes[i];
                        var currentValue = node.val;
                        var nodeEven = currentValue % 2 == 0;

                        var isEvenOdd = (levelEven && !nodeEven && currentValue > previousValue)
                            || (!levelEven && nodeEven && currentValue < previousValue);
                        
                        if (!isEvenOdd)
                        {
                            return false;
                        }

                        previousValue = node.val;

                        if (node.left is not null)
                        {
                            nextNodes.Add(node.left);
                        }

                        if (node.right is not null)
                        {
                            nextNodes.Add(node.right);
                        }
                    }
                }

                Array.Resize(ref currentNodes, nextNodes.Count);
                nextNodes.CopyTo(currentNodes);
                level++;
            }

            return true;
        }

        [Test]
        [TestCase("[1,10,4,3,null,7,9,12,8,6,null,null,2]", true)]
        [TestCase("[5,4,2,3,3,7]", false)]
        [TestCase("[5,9,1,3,5,7]", false)]
        public void Test(string input, bool expected)
        {
            var values = JsonSerializer.Deserialize<int?[]>(input)!;
            var tree = BuildBinaryTree(values);

            var result = IsEvenOddTree(tree);

            Assert.That(result, Is.EqualTo(expected));
        }

        private TreeNode BuildBinaryTree(int?[] values)
        {
            if (values.Length == 0)
            {
                throw new ArgumentException("Provided array must not be empty", nameof(values));
            }

            var root = new TreeNode(values[0]!.Value);
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int i = 1;
            while (i < values.Length)
            {
                var parentNode = queue.Dequeue();

                if (i < values.Length)
                {
                    var left = values[i];
                    if (left.HasValue)
                    {
                        var node = new TreeNode(left.Value);
                        parentNode.left = node;
                        queue.Enqueue(node);
                    }

                    i++;
                }

                if (i < values.Length)
                {
                    var right = values[i];
                    if (right.HasValue)
                    {
                        var node = new TreeNode(right.Value);
                        parentNode.right = node;
                        queue.Enqueue(node);
                    }

                    i++;
                }
            }

            return root;
        }

        // Class provided by LeetCode (except for ToString)
        public class TreeNode
        {
            public int val;
            public TreeNode? left;
            public TreeNode? right;
            public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }

            public override string ToString()
            {
                return $"{val} [left: {left}, right: {right}]";
            }
        }
    }
}
