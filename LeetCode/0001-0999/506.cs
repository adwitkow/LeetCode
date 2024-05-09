using System.Text.Json;
using LeetCode.Scaffoldings;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/relative-ranks/
    public class _506
    {
        private static readonly string[] _medals =
        [
            "Gold Medal",
            "Silver Medal",
            "Bronze Medal",
        ];

        public string[] FindRelativeRanks(int[] score)
        {
            return FindRelativeRanks_Span_BinarySearch(score);
        }

        public string[] FindRelativeRanks_Span_BinarySearch(int[] score)
        {
            var comparer = new DescendingComparer<int>();

            var descendingScores = score.ToArray().AsSpan();
            descendingScores.Sort(comparer);

            string[] results = new string[score.Length];
            for (int i = 0; i < score.Length; i++)
            {
                var index = descendingScores.BinarySearch(score[i], comparer);

                results[i] = ConvertPlacement(index);
            }

            return results;
        }

        public string[] FindRelativeRanks_Array_IndexOf(int[] score)
        {
            var descendingScores = score.ToArray();

            Array.Sort(descendingScores);
            Array.Reverse(descendingScores);

            string[] results = new string[score.Length];
            for (int i = 0; i < score.Length; i++)
            {
                int index = Array.IndexOf(descendingScores, score[i]);

                results[i] = ConvertPlacement(index);
            }

            return results;
        }

        public string[] FindRelativeRanks_Linq(int[] score)
        {
            // oof
            var placements = score
                .Select((value, oldIndex) => (value, oldIndex))
                .OrderByDescending(tuple => tuple.value)
                .Select((tuple, newIndex) => (tuple.value, tuple.oldIndex, newIndex))
                .Select(tuple => (placement:ConvertPlacement(tuple.newIndex), tuple.oldIndex))
                .OrderBy(tuple => tuple.oldIndex)
                .Select(tuple => tuple.placement)
                .ToArray();

            return placements;
        }

        private static string ConvertPlacement(int placement)
        {
            if (placement > 2)
            {
                return (placement + 1).ToString();
            }

            return _medals[placement];
        }

        private class DescendingComparer<T> : IComparer<T>
            where T : IComparable<T>
        {
            public int Compare(T x, T y)
            {
                return -x.CompareTo(y);
            }
        }

        [Test]
        [TestCase("[5,4,3,2,1]", "[\"Gold Medal\",\"Silver Medal\",\"Bronze Medal\",\"4\",\"5\"]")]
        [TestCase("[10,3,8,9,4]", "[\"Gold Medal\",\"5\",\"Bronze Medal\",\"Silver Medal\",\"4\"]")]
        public void Test(string rawScore, string expected)
        {
            var score = JsonSerializer.Deserialize<int[]>(rawScore)!;

            var result = FindRelativeRanks(score);

            var rawResult = JsonSerializer.Serialize(result);

            Assert.That(rawResult, Is.EqualTo(expected));
        }
    }
}
