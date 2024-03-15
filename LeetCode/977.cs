using System.Text.Json;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/squares-of-a-sorted-array/
    public class _977
    {
        public int[] SortedSquares(int[] nums)
        {
            var result = new int[nums.Length];

            var lastIndex = nums.Length - 1;

            int start = 0;
            int end = lastIndex;

            for (int pointer = lastIndex; pointer >= 0; pointer--)
            {
                var left = nums[start] * nums[start];
                var right = nums[end] * nums[end];
                if (left > right)
                {
                    result[pointer] = left;
                    start++;
                }
                else
                {
                    result[pointer] = right;
                    end--;
                }
            }

            return result;
        }

        public int[] SortedSquares_Linq(int[] nums)
        {
            return nums.Select(num => num * num).Order().ToArray();
        }

        [Test]
        [TestCase("[1]", "[1]")]
        [TestCase("[0,2]", "[0,4]")]
        [TestCase("[-5,-3,-2,-1]", "[1,4,9,25]")]
        [TestCase("[-4,-1,0,3,10]", "[0,1,9,16,100]")]
        [TestCase("[-7,-3,2,3,11]", "[4,9,9,49,121]")]
        public void Test(string input, string expected)
        {
            var numbers = JsonSerializer.Deserialize<int[]>(input)!;
            var rawResult = SortedSquares(numbers);
            var result = JsonSerializer.Serialize(rawResult);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
