using System.Text.Json;
using LeetCode.Scaffoldings;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/first-missing-positive/
    public class _0041
    {
        public int FirstMissingPositive(int[] nums)
        {
            int length = nums.Length;

            for (int i = 0; i < length;)
            {
                if (nums[i] > 0 && nums[i] <= length
                    && nums[nums[i] - 1] != nums[i])
                {
                    var temp = nums[nums[i] - 1];
                    nums[nums[i] - 1] = nums[i];
                    nums[i] = temp;
                }
                else
                {
                    i++;
                }
            }

            for (int i = 0; i < length; i++)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }

            return length + 1;
        }

        [Test]
        [TestCase("[1,2,0]", 3)]
        [TestCase("[3,4,-1,1]", 2)]
        [TestCase("[7,8,9,11,12]", 1)]
        [TestCase("[1]", 2)]
        public void Test(string rawNums, int expected)
        {
            var nums = JsonSerializer.Deserialize<int[]>(rawNums)!;

            var result = FirstMissingPositive(nums);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
