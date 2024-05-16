using System.Text.Json;
using LeetCode.Scaffoldings;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/maximize-happiness-of-selected-children/
    public class _3075
    {
        public long MaximumHappinessSum(int[] happiness, int k)
        {
            var span = happiness.AsSpan();
            span.Sort();
            span.Reverse();

            var result = 0L;
            for (int i = 0; i < k; i++)
            {
                var currentHappiness = Math.Max(span[i] - i, 0);
                result += currentHappiness;
            }

            return result;
        }

        [Test]
        [TestCase("[1,2,3]", 2, 4)]
        [TestCase("[1,1,1,1]", 2, 1)]
        [TestCase("[2,3,4,5]", 1, 5)]
        public void Test(string rawHappiness, int k, long expected)
        {
            var happiness = JsonSerializer.Deserialize<int[]>(rawHappiness)!;

            var result = MaximumHappinessSum(happiness, k);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
