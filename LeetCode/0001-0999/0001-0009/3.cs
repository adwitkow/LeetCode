using NUnit.Framework;

namespace LeetCode._1_9
{
    // https://leetcode.com/problems/longest-substring-without-repeating-characters/
    public class _3
    {
        public int LengthOfLongestSubstring(string s)
        {
            var longest = string.Empty;
            var candidate = string.Empty;

            foreach (var ch in s)
            {
                var index = candidate.IndexOf(ch);
                if (index == -1)
                {
                    candidate += ch;
                }
                else
                {
                    candidate = candidate.Substring(index + 1) + ch;
                }

                if (candidate.Length > longest.Length)
                {
                    longest = candidate;
                }
            }

            return longest.Length;
        }

        [Test]
        [TestCase("abcabcbb", 3)]
        [TestCase("bbbbb", 1)]
        [TestCase("pwwkew", 3)]
        [TestCase("aab", 2)]
        [TestCase("dvdf", 3)]
        public void Test(string input, int expected)
        {
            var result = LengthOfLongestSubstring(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
