using System.Text.Json;
using LeetCode.Scaffoldings;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/special-array-with-x-elements-greater-than-or-equal-x/
    public class _1608
    {
        public int SpecialArray(int[] nums)
        {
            return SpecialArray_Span_BinarySearch(nums);
        }

        public int SpecialArray_Array_BinarySearch(int[] nums)
        {
            Array.Sort(nums);

            for (int i = 1; i <= nums.Length; i++)
            {
                var index = BinarySearch(nums, i);
                var remaining = nums.Length - index;

                if (remaining == i)
                {
                    return i;
                }
            }

            return -1;
        }

        public int SpecialArray_Span_BinarySearch(int[] nums)
        {
            var span = nums.AsSpan();
            span.Sort();

            for (int i = 1; i <= span.Length; i++)
            {
                var index = BinarySearch(span, i);
                var remaining = span.Length - index;

                if (remaining == i)
                {
                    return i;
                }
            }

            return -1;
        }

        public int SpecialArray_CountingSort(int[] nums)
        {
            int N = nums.Length;
            int[] freq = new int[N + 1];

            for (int i = 0; i < N; i++)
            {
                freq[Math.Min(N, nums[i])]++;
            }

            int numGreaterThanOrEqual = 0;
            for (int i = N; i >= 1; i--)
            {
                numGreaterThanOrEqual += freq[i];
                if (i == numGreaterThanOrEqual)
                {
                    return i;
                }
            }

            return -1;
        }

        private static int BinarySearch(Span<int> nums, int value)
        {
            var start = 0;
            var end = nums.Length - 1;

            var index = nums.Length;

            while (start <= end)
            {
                var mid = (start + end) / 2;

                if (nums[mid] >= value)
                {
                    index = mid;
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return index;
        }

        [Test]
        [TestCase("[3,5]", 2)]
        [TestCase("[0,0]", -1)]
        [TestCase("[0,4,3,0,4]", 3)]
        public void Test(string rawNums, int expected)
        {
            var nums = JsonSerializer.Deserialize<int[]>(rawNums)!;

            var result = SpecialArray(nums);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
