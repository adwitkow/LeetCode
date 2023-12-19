using System.Text.Json;
using NUnit.Framework;

namespace LeetCode._1_9
{
    internal class _4
    {
        // https://leetcode.com/problems/median-of-two-sorted-arrays/
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            // naive approach
            var length = nums1.Length + nums2.Length;
            var merged = nums1
                .Concat(nums2)
                .OrderBy(num => num)
                .ToArray();

            double result;
            var halfIndex = (length - 1) / 2;
            if (length % 2 == 0)
            {
                result = (merged[halfIndex] + merged[halfIndex + 1]) / 2d;
            }
            else
            {
                result = merged[halfIndex];
            }

            return result;
        }

        [Test]
        [TestCase("[1,3]", "[2]", 2)]
        [TestCase("[1,2]", "[3,4]", 2.5d)]
        [TestCase("[1,1,2]", "[3,4]", 2)]
        public void Test(string nums1Serialized, string nums2Serialized, double expected)
        {
            var nums1 = JsonSerializer.Deserialize<int[]>(nums1Serialized);
            var nums2 = JsonSerializer.Deserialize<int[]>(nums2Serialized);
            var result = FindMedianSortedArrays(nums1, nums2);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
