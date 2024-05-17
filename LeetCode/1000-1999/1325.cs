using System.Text.Json;
using LeetCode.Scaffoldings;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/delete-leaves-with-a-given-value/
    public class _1325
    {
        public TreeNode? RemoveLeafNodes(TreeNode? root, int target)
        {
            if (root is null)
            {
                return null;
            }

            root.left = RemoveLeafNodes(root.left, target);
            root.right = RemoveLeafNodes(root.right, target);

            var isLeaf = root.left is null && root.right is null;

            if (isLeaf && root.val == target)
            {
                return null;
            }

            return root;
        }

        [Test]
        [TestCase("[1,2,3,2,null,2,4]", 2, "[1,null,3,null,4]")]
        [TestCase("[1,3,3,3,2]", 3, "[1,3,null,null,2]")]
        [TestCase("[1,2,null,2,null,2]", 2, "[1]")]
        public void Test(string rawRoot, int target, string expected)
        {
            var root = TreeNode.FromString(rawRoot);

            var result = RemoveLeafNodes(root, target);
            var resultAsString = TreeNode.ToString(result);

            Assert.That(resultAsString, Is.EqualTo(expected));
        }
    }
}
