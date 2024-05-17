using System.Text.Json;
using LeetCode.Scaffoldings;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/evaluate-boolean-binary-tree/
    public class _2331
    {
        public bool EvaluateTree(TreeNode root)
        {
            return EvaluateNode(root);
        }

        private static bool EvaluateNode(TreeNode node)
        {
            var isLeaf = node.left is null && node.right is null;

            if (isLeaf)
            {
                return Convert.ToBoolean(node.val);
            }

            var resultLeft = EvaluateNode(node.left!);
            var resultRight = EvaluateNode(node.right!);

            var conditional = (Conditional)node.val;
            if (conditional is Conditional.Or)
            {
                return resultLeft || resultRight;
            }

            return resultLeft && resultRight;
        }

        private enum Conditional
        {
            Or = 2,
            And = 3,
        }

        [Test]
        [TestCase("[2,1,3,null,null,0,1]", true)]
        [TestCase("[0]", false)]
        public void Test(string rawRoot, bool expected)
        {
            var root = TreeNode.FromString(rawRoot);

            var result = EvaluateTree(root);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
