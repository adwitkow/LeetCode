using System.Text.Json;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/find-all-duplicates-in-an-array/
    public class _442
    {
        public IList<int> FindDuplicates(int[] nums)
        {
            return FindDuplicates_Inverts(nums);
        }

        public IList<int> FindDuplicates_Inverts(int[] nums)
        {
            var results = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var target = Math.Abs(nums[i]) - 1;

                if (nums[target] < 0)
                {
                    results.Add(Math.Abs(target + 1));
                }

                nums[target] = -nums[target];
            }

            return results;
        }

        public IList<int> FindDuplicates_Sort(int[] nums)
        {
            Array.Sort(nums);
            var results = new List<int>();

            for (int i = nums.Length - 1; i >= 1; i--)
            {
                var current = nums[i];
                var next = nums[i - 1];

                if (current == next)
                {
                    results.Add(current);
                }
            }

            return results;
        }

        public IList<int> FindDuplicates_HashSet(int[] nums)
        {
            var set = new HashSet<int>();
            var results = new List<int>();

            foreach (var i in nums)
            {
                if (set.Contains(i))
                {
                    results.Add(i);
                }
                else
                {
                    set.Add(i);
                }
            }

            return results;
        }

        public IList<int> FindDuplicates_Linq(int[] nums)
        {
            return nums.GroupBy(x => x)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key)
                .ToList();
        }

        [Test]
        [TestCase("[4,3,2,7,8,2,3,1]", "[2,3]")]
        [TestCase("[1,1,2]", "[1]")]
        [TestCase("[1]", "[]")]
        public void Test(string rawNums, string rawExpected)
        {
            var nums = JsonSerializer.Deserialize<int[]>(rawNums)!;
            var expected = JsonSerializer.Deserialize<int[]>(rawExpected)!;

            var result = FindDuplicates(nums);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
