using System.Text;
using System.Text.Json;
using LeetCode.Scaffoldings;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/integer-to-roman/
    public class _12
    {
        // I woould very much prefer to calculate the subtractive forms
        // on the fly but no matter what I did just mapping every single
        // combination like below just worked better
        private static readonly (string Symbol, int Value)[] _romans =
        [
            ("M", 1000),
            ("CM", 900),
            ("D", 500),
            ("CD", 400),
            ("C", 100),
            ("XC", 90),
            ("L", 50),
            ("XL", 40),
            ("X", 10),
            ("IX", 9),
            ("V", 5),
            ("IV", 4),
            ("I", 1),
        ];

        public string IntToRoman(int num)
        {
            var builder = new StringBuilder();

            foreach (var roman in _romans)
            {
                var count = num / roman.Value;

                for (int i = 0; i < count; i++)
                {
                    builder.Append(roman.Symbol);
                }

                num -= roman.Value * count;
            }

            return builder.ToString();
        }

        [Test]
        [TestCase(3749, "MMMDCCXLIX")]
        [TestCase(58, "LVIII")]
        [TestCase(1994, "MCMXCIV")]
        [TestCase(3999, "MMMCMXCIX")]
        public void Test(int num, string expected)
        {
            var result = IntToRoman(num);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
