using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/longest-palindromic-substring/
    public class _0005
    {
        // Not even suboptimal. Negatively optimal. Just horrible.
        // But it's quite readable, I guess.
        public string LongestPalindrome(string s)
        {
            var current = string.Empty;
            var longest = current;
            for (int i = 0; i < s.Length; i++)
            {
                current = string.Empty;
                for (int j = i; j < s.Length; j++)
                {
                    current += s[j];

                    if (IsPalindrome(current) && current.Length > longest.Length)
                    {
                        longest = current;
                    }
                }
            }

            return longest;
        }

        public bool IsPalindrome(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != input[input.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        [Test]
        [TestCase("babad", "bab")]
        [TestCase("cbbd", "bb")]
        public void Test_LongestPalindrome(string input, string expected)
        {
            var result = LongestPalindrome(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("bab", true)]
        [TestCase("bb", true)]
        [TestCase("lorem", false)]
        [TestCase("abc", false)]
        [TestCase("", true)]
        [TestCase("a", true)]
        public void Test_IsPalindrome(string input, bool expected)
        {
            var result = IsPalindrome(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
