using System.Text;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/custom-sort-string/
    public class _0791
    {
        public string CustomSortString(string order, string s)
        {
            var charCounts = new Dictionary<char, int>();
            var results = new char[s.Length];
            var currentIndex = 0;

            foreach (var ch in s)
            {
                if (!charCounts.ContainsKey(ch))
                {
                    charCounts.Add(ch, 0);
                }

                charCounts[ch]++;
            }

            for (int i = 0; i < order.Length; i++)
            {
                var orderChar = order[i];

                if (charCounts.TryGetValue(orderChar, out int count))
                {
                    for (int j = 0; j < count; j++)
                    {
                        results[currentIndex] = orderChar;
                        currentIndex++;
                        charCounts[orderChar]--;
                    }
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                var remainingChar = s[i];

                for (int j = 0; j < charCounts[remainingChar]; j++)
                {
                    results[currentIndex] = remainingChar;
                    currentIndex++;
                    charCounts[remainingChar]--;
                }
            }

            return new string(results);
        }

        public string CustomSortString_BruteSorter(string order, string s)
        {
            var operations = 1;

            var chars = s.ToCharArray();
            while (operations > 0)
            {
                operations = 0;

                for (int i = 1; i < s.Length; i++)
                {
                    var left = chars[i - 1];
                    var right = chars[i];

                    var leftIndex = order.IndexOf(left);

                    if (leftIndex == -1)
                    {
                        leftIndex = int.MaxValue;
                    }

                    var rightIndex = order.IndexOf(right);

                    if (rightIndex == -1)
                    {
                        rightIndex = int.MaxValue;
                    }

                    if (leftIndex > rightIndex)
                    {
                        chars[i - 1] = right;
                        chars[i] = left;

                        operations++;
                    }
                }
            }

            return new string(chars);
        }

        public string CustomSortString_BruteSorter_MappedOrder(string order, string s)
        {
            var orderMap = new Dictionary<char, int>();
            for (int i = 0; i < order.Length; i++)
            {
                orderMap.Add(order[i], i + 1);
            }

            var operations = 1;

            var chars = s.ToCharArray();
            while (operations > 0)
            {
                operations = 0;

                for (int i = 1; i < s.Length; i++)
                {
                    var left = chars[i - 1];
                    var right = chars[i];

                    orderMap.TryGetValue(left, out var leftIndex);

                    if (leftIndex == 0)
                    {
                        leftIndex = int.MaxValue;
                    }

                    orderMap.TryGetValue(right, out var rightIndex);

                    if (rightIndex == 0)
                    {
                        rightIndex = int.MaxValue;
                    }

                    if (leftIndex > rightIndex)
                    {
                        chars[i - 1] = right;
                        chars[i] = left;

                        operations++;
                    }
                }
            }

            return new string(chars);
        }

        [Test]
        [TestCase("cba", "abcd", "cbad")]
        [TestCase("bcafg", "abcd", "bcad")]
        public void Test(string order, string input, string expected)
        {
            var result = CustomSortString(order, input);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
