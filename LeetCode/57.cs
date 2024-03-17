using System.Linq;
using System.Text.Json;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/insert-interval/
    public class _57
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            // I haven't seen a single occurrence of Span usage on LeetCode submissions
            int lastIndex = 0;
            while (lastIndex < intervals.Length && intervals[lastIndex][1] < newInterval[0])
            {
                lastIndex++;
            }

            Span<int[]> front;
            if (lastIndex > 0)
            {
                front = intervals.AsSpan(0, lastIndex);
            }
            else
            {
                front = [];
            }

            while (lastIndex < intervals.Length && intervals[lastIndex][0] <= newInterval[1])
            {
                newInterval[0] = Math.Min(newInterval[0], intervals[lastIndex][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[lastIndex][1]);
                lastIndex++;
            }

            var back = intervals.AsSpan(lastIndex);

            return [..front, newInterval, ..back];
        }

        public int[][] Insert_Popular(int[][] intervals, int[] newInterval)
        {
            List<int[]> result = new List<int[]>();

            // Iterate through intervals and add non-overlapping intervals before newInterval
            int i = 0;
            while (i < intervals.Length && intervals[i][1] < newInterval[0])
            {
                result.Add(intervals[i]);
                i++;
            }

            // Merge overlapping intervals
            while (i < intervals.Length && intervals[i][0] <= newInterval[1])
            {
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
                i++;
            }

            // Add merged newInterval
            result.Add(newInterval);

            // Add non-overlapping intervals after newInterval
            while (i < intervals.Length)
            {
                result.Add(intervals[i]);
                i++;
            }

            return result.ToArray();
        }

        public int[][] Insert_Editorial(int[][] intervals, int[] newInterval)
        {
            // If the intervals vector is empty, return a vector containing the newInterval
            if (intervals.Length == 0)
            {
                return [newInterval];
            }

            int n = intervals.Length;
            int target = newInterval[0];
            int left = 0, right = n - 1;

            // Binary search to find the position to insert newInterval
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (intervals[mid][0] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            // Insert newInterval at the found position
            var result = new List<int[]>();
            for (int i = 0; i < left; i++)
            {
                result.Add(intervals[i]);
            }

            result.Add(newInterval);

            for (int i = left; i < n; i++)
            {
                result.Add(intervals[i]);
            }

            // Merge overlapping intervals
            var merged = new List<int[]>();
            foreach (int[] interval in result)
            {
                // If res is empty or there is no overlap, add the interval to the result
                if (merged.Count == 0 || merged[merged.Count - 1][1] < interval[0])
                {
                    merged.Add(interval);
                    // If there is an overlap, merge the intervals by updating the end of the last interval in res
                }
                else
                {
                    merged[merged.Count - 1][1] = Math.Max(merged[merged.Count - 1][1], interval[1]);
                }
            }

            return merged.ToArray();
        }

        [Test]
        [TestCase("[[1,3],[6,9]]", "[2,5]", "[[1,5],[6,9]]")]
        [TestCase("[[1,2],[3,5],[6,7],[8,10],[12,16]]", "[4,8]", "[[1,2],[3,10],[12,16]]")]
        [TestCase("[[1,5]]", "[2,3]", "[[1,5]]")]
        [TestCase("[[1,5]]", "[6,8]", "[[1,5],[6,8]]")]
        [TestCase("[[1,5]]", "[2,7]", "[[1,7]]")]
        [TestCase("[[1,5]]", "[0,0]", "[[0,0],[1,5]]")]
        [TestCase("[[1,5]]", "[6,8]", "[[1,5],[6,8]]")]
        [TestCase("[[1,5],[6,8]]", "[5,6]", "[[1,8]]")]
        public void Test(string rawIntervals, string rawNewInterval, string rawExpected)
        {
            var intervals = JsonSerializer.Deserialize<int[][]>(rawIntervals)!;
            var newInterval = JsonSerializer.Deserialize<int[]>(rawNewInterval)!;

            var result = Insert(intervals, newInterval);

            var resultSerialized = JsonSerializer.Serialize(result);
            Assert.That(resultSerialized, Is.EqualTo(rawExpected));
        }
    }
}
