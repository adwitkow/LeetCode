using System.Runtime.InteropServices;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/reverse-prefix-of-word/
    public class _2000
    {
        public string ReversePrefix(string word, char ch)
        {
            return ReversePrefix_Memory(word, ch);
        }

        public string ReversePrefix_Array(string word, char ch)
        {
            var array = word.ToCharArray();
            var index = word.IndexOf(ch);

            if (index >= 0)
            {
                Array.Reverse(array, 0, index + 1);
            }

            return new string(array);
        }

        public string ReversePrefix_Memory(string word, char ch)
        {
            var memory = MemoryMarshal.AsMemory(word.AsMemory());
            var span = memory.Span;
            var index = span.IndexOf(ch);

            if (index == -1)
            {
                return word;
            }

            var firstPart = span.Slice(0, index + 1);
            firstPart.Reverse();

            return word;
        }

        [Test]
        [TestCase("abcdefd", 'd', "dcbaefd")]
        [TestCase("xyxzxe", 'z', "zxyxxe")]
        [TestCase("abcd", 'z', "abcd")]
        public void Test(string word, char ch, string expected)
        {
            var result = ReversePrefix(word, ch);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
