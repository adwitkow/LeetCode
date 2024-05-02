using System.Text.Json;
using LeetCode.Scaffoldings;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/largest-positive-integer-that-exists-with-its-negative/
    public class _2441
    {
        private static readonly HashSet<int> _seen = new HashSet<int>();

        public int FindMaxK(int[] nums)
        {
            _seen.Clear();

            var highestDuplicate = -1;

            foreach (var num in nums)
            {
                var abs = Math.Abs(num);

                if (_seen.Contains(-num) && abs > highestDuplicate)
                {
                    highestDuplicate = abs;
                }

                _seen.Add(num);
            }

            return highestDuplicate;
        }

        [Test]
        [TestCase("[-1,2,-3,3]", 3)]
        [TestCase("[-1,10,6,7,-7,1]", 7)]
        [TestCase("[-10,8,6,7,-2,-3]", -1)]
        [TestCase("[-9,-43,24,-23,-16,-30,-38,-30]", -1)]
        public void Test(string rawNums, int expected)
        {
            var nums = JsonSerializer.Deserialize<int[]>(rawNums)!;

            var result = FindMaxK(nums);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
