using System.Text.Json;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/product-of-array-except-self/
    public class _0238
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            var length = nums.Length;
            var suffixes = new int[length];
            var results = new int[length];

            var product = 1;
            for (int i = length - 1; i >= 0; i--)
            {
                product *= nums[i];
                suffixes[i] = product;
            }

            product = 1;
            for (int i = 0; i < length - 1; i++)
            {
                results[i] = product * suffixes[i + 1];
                product *= nums[i];
            }

            results[length - 1] = product;

            return results;
        }

        [Test]
        [TestCase("[1,2,3,4]", "[24,12,8,6]")]
        [TestCase("[-1,1,0,-3,3]", "[0,0,9,0,0]")]

        public void Test(string rawNums, string rawExpected)
        {
            var nums = JsonSerializer.Deserialize<int[]>(rawNums)!;
            var expected = JsonSerializer.Deserialize<int[]>(rawExpected)!;

            var result = ProductExceptSelf(nums);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
