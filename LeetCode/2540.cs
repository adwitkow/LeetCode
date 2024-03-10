using System.Text.Json;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/minimum-common-value/
    public class _2540
    {
        public int GetCommon(int[] nums1, int[] nums2)
        {
            // Valid, but suboptimal:
            //var filtered = nums1.Intersect(nums2);

            //if (filtered.Any())
            //{
            //    return filtered.Min();
            //}

            //return -1;

            var index1 = 0;
            var index2 = 0;

            while (index1 < nums1.Length && index2 < nums2.Length)
            {
                var num1 = nums1[index1];
                var num2 = nums2[index2];

                if (num1 == num2)
                {
                    return num1;
                }

                if (num1 < num2)
                {
                    index1++;
                }
                else
                {
                    index2++;
                }
            }

            return -1;
        }

        [Test]
        [TestCase("[1,2,3]", "[2,4]", 2)]
        [TestCase("[1,2,3,6]", "[2,3,4,5]", 2)]
        public void Test(string input1, string input2, int expected)
        {
            var numbers1 = JsonSerializer.Deserialize<int[]>(input1)!;
            var numbers2 = JsonSerializer.Deserialize<int[]>(input2)!;
            var result = GetCommon(numbers1, numbers2);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TimeLimitTest()
        {
            var numbers1 = new int[100_000];
            var numbers2 = new int[100_000];

            for (int i = 0; i < 100_000; i++)
            {
                numbers1[i] = i + 1;
            }

            for (int i = 0; i < 100_000; i++)
            {
                numbers2[i] = i + 100_001;
            }

            var result = GetCommon(numbers1, numbers2);

            Assert.That(result, Is.EqualTo(-1));
        }
    }
}
