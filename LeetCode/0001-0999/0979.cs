using System.Text.Json;
using LeetCode.Scaffoldings;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/distribute-coins-in-binary-tree/
    public class _0979
    {
        public int DistributeCoins(TreeNode root)
        {
            var moves = TraverseAndDistribute(root);

            return moves;
        }

        private int TraverseAndDistribute(TreeNode? node)
        {
            if (node is null)
            {
                return 0;
            }

            var moves = 0;
            moves += TraverseAndDistribute(node.left);
            moves += TraverseAndDistribute(node.right);

            moves += DistributeSurplusAndDeficit(node, node.left);
            moves += DistributeSurplusAndDeficit(node, node.right);

            return moves;
        }

        private int DistributeSurplusAndDeficit(TreeNode node, TreeNode? child)
        {
            if (child is null)
            {
                return 0;
            }

            int moves = 0;

            if (child.val > 1)
            {
                var surplus = child.val - 1;
                child.val -= surplus;
                node.val += surplus;
                moves = surplus;
            }
            else if (child.val < 1)
            {
                var deficit = 1 - child.val;
                child.val += deficit;
                node.val -= deficit;
                moves = deficit;
            }

            return moves;
        }

        [Test]
        [TestCase("[3,0,0]", 2)]
        [TestCase("[0,3,0]", 3)]
        [TestCase("[0,0,3]", 3)]
        [TestCase("[1,0,0,null,3]", 4)]
        [TestCase("[4,0,null,null,0,null,0]", 6)]
        public void Test(string rawRoot, int expected)
        {
            var root = TreeNode.FromString(rawRoot);

            var result = DistributeCoins(root);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
