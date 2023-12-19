using NUnit.Framework;

namespace LeetCode._1_9
{
    internal class _3
    {
        public int LengthOfLongestSubstring(string s)
        {
            var longest = "";
            var candidate = "";

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
