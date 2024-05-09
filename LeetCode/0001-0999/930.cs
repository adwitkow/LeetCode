using System.Text.Json;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/binary-subarrays-with-sum/
    public class _930
    {
        public int NumSubarraysWithSum(int[] nums, int goal)
        {
            int totalCount = 0;
            int currentSum = 0;
            var frequencies = new Dictionary<int, int>();

            foreach (int num in nums)
            {
                currentSum += num;
                if (currentSum == goal)
                {
                    totalCount++;
                }

                if (frequencies.ContainsKey(currentSum - goal))
                {
                    totalCount += frequencies[currentSum - goal];
                }

                frequencies.TryGetValue(currentSum, out int occurrences);
                frequencies[currentSum] = occurrences + 1;
            }

            return totalCount;
        }

        public int NumSubarraysWithSum_Intuition(int[] nums, int goal)
        {
            var results = new HashSet<(int Start, int End)>();

            for (int i = 0; i < nums.Length; i++)
            {
                var sum = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    sum += nums[j];

                    if (sum == goal)
                    {
                        results.Add((i, j));
                    }
                    else if (sum > goal)
                    {
                        break;
                    }
                }
            }

            return results.Count;
        }

        [Test]
        [TestCase("[1,0,1,0,1]", "2", 4)]
        [TestCase("[0,0,0,0,0]", "0", 15)]

        public void Test(string rawNums, string rawGoal, int expected)
        {
            var nums = JsonSerializer.Deserialize<int[]>(rawNums)!;
            var goal = JsonSerializer.Deserialize<int>(rawGoal)!;

            var result = NumSubarraysWithSum(nums, goal);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
