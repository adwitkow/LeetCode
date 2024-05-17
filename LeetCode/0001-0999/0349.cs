using System.Text.Json;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/intersection-of-two-arrays
    public class _0349
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            // LINQ's Intersect would probably be better.
            // But this is a good compromise between speed and memory usage.
            var set = new HashSet<int>();
            foreach (var n in nums1)
            {
                if (nums2.Contains(n))
                {
                    set.Add(n);
                }
            }

            return set.ToArray();
        }

        [Test]
        [TestCase("[1,2,2,1]", "[2,2]", "[2]")]
        [TestCase("[4,9,5]", "[9,4,9,8,4]", "[4,9]")]
        public void Test(string input1, string input2, string expected)
        {
            var numbers1 = JsonSerializer.Deserialize<int[]>(input1)!;
            var numbers2 = JsonSerializer.Deserialize<int[]>(input2)!;
            var result = Intersection(numbers1, numbers2);

            var resultSerialized = JsonSerializer.Serialize(result);

            Assert.That(resultSerialized, Is.EqualTo(expected));
        }
    }
}
