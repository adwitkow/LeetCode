using System.Text.Json;
using NUnit.Framework;

namespace LeetCode._1_9
{
    internal class _1
    {
        // https://leetcode.com/problems/two-sum/
        public int[] TwoSum(int[] nums, int target)
        {
            var keys = Enumerable.Range(0, nums.Length).ToArray();
            Array.Sort(nums, keys);

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 1; j < nums.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    var sum = nums[i] + nums[j];

                    if (sum > target)
                    {
                        break;
                    }

                    if (sum == target)
                    {
                        return new int[] { keys[i], keys[j] };
                    }
                }
            }

            return new int[] { };
        }

        [Test]
        [TestCase("[2,7,11,15]", 9, "[0,1]")]
        [TestCase("[3,2,4]", 6, "[1,2]")]
        [TestCase("[3,3]", 6, "[0,1]")]
        [TestCase("[0,4,3,0]", 0, "[0,3]")]
        public void Test(string input, int target, string expectedSerialized)
        {
            var numbers = JsonSerializer.Deserialize<int[]>(input);
            var result = TwoSum(numbers, target);

            var expected = JsonSerializer.Deserialize<int[]>(expectedSerialized);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
