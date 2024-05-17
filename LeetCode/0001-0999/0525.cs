using System.Text.Json;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/contiguous-array/
    public class _0525
    {
        public int FindMaxLength(int[] nums)
        {
            var indices = new Dictionary<int, int>()
            {
                { 0, -1 },
            };

            int currentSum = 0;
            var result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                if (num == 0)
                {
                    currentSum--;
                }
                else
                {
                    currentSum++;
                }

                if (!indices.TryGetValue(currentSum, out int index))
                {
                    indices[currentSum] = i;
                }
                else
                {
                    result = Math.Max(result, i - index);
                }
            }

            return result;
        }

        [Test]
        [TestCase("[0,1]", 2)]
        [TestCase("[0,1,0]", 2)]
        [TestCase("[0,1,0,1]", 4)]
        [TestCase("[0,0]", 0)]
        public void Test(string rawNums, int expected)
        {
            var nums = JsonSerializer.Deserialize<int[]>(rawNums)!;

            var result = FindMaxLength(nums);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
