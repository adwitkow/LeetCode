using System.Text.Json;
using LeetCode.Scaffoldings;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/roman-to-integer/
    public class _0013
    {
        private static readonly Dictionary<char, short> _symbols = new Dictionary<char, short>()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };

        public int RomanToInt(string s)
        {
            var previousValue = short.MaxValue;
            var result = 0;
            foreach (var ch in s)
            {
                var value = _symbols[ch];
                if (value > previousValue)
                {
                    result -= previousValue * 2;
                }

                result += value;

                previousValue = value;
            }

            return result;
        }

        [Test]
        [TestCase("III", 3)]
        [TestCase("LVIII", 58)]
        [TestCase("MCMXCIV", 1994)]
        [TestCase("MMMCMXCIX", 3999)]
        public void Test(string s, int expected)
        {
            var result = RomanToInt(s);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
