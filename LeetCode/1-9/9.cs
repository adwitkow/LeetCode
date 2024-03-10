using NUnit.Framework;

namespace LeetCode._1_9
{
    // https://leetcode.com/problems/palindrome-number/
    internal class _9
    {
        public bool IsPalindrome(int x)
        {
            var original = x;
            var reversed = 0;

            while (original > 0)
            {
                var digit = original % 10;
                reversed = reversed * 10 + digit;
                original = original / 10;
            }

            if (reversed == x)
            {
                return true;
            }
            
            return false;
        }

        public bool IsPalindrome_CharArray_SingleArray(int x)
        {
            var chars = x.ToString().ToCharArray();
            var lastIndex = chars.Length - 1;

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] != chars[lastIndex - i])
                {
                    return false;
                }
            }

            return true;
        }


        public bool IsPalindrome_CharArray_Linq(int x)
        {
            var chars = x.ToString().ToCharArray();
            return chars.SequenceEqual(chars.Reverse());
        }


        [Test]
        [TestCase(121, true)]
        [TestCase(-121, false)]
        [TestCase(10, false)]
        public void Test(int input, bool expected)
        {
            var result = IsPalindrome(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(121, true)]
        [TestCase(-121, false)]
        [TestCase(10, false)]
        public void Test_CharArray_SingleArray(int input, bool expected)
        {
            var result = IsPalindrome_CharArray_SingleArray(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(121, true)]
        [TestCase(-121, false)]
        [TestCase(10, false)]
        public void Test_CharArray_Linq(int input, bool expected)
        {
            var result = IsPalindrome_CharArray_Linq(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
