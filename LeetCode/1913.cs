using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/maximum-product-difference-between-two-pairs/
    public class _1913
    {
        public int MaxProductDifference(int[] nums)
        {
            Array.Sort(nums);

            // not the prettiest or most performant but I'm a huge fan of LINQ :)
            var lowerProduct = nums.Take(2).Aggregate(1, (acc, val) => acc * val);
            var higherProduct = nums.TakeLast(2).Aggregate(1, (acc, val) => acc * val);

            return higherProduct - lowerProduct;
        }

        [Test]
        [TestCase(new int[] { 5, 6, 2, 7, 4 }, 34)]
        [TestCase(new int[] { 4, 2, 5, 9, 7, 4, 8 }, 64)]
        public void Test(int[] numbers, int expected)
        {
            var result = MaxProductDifference(numbers);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
