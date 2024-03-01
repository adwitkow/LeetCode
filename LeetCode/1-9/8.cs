using System.Reflection;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace LeetCode._1_9
{
    internal class _8
    {
        private static readonly Regex DigitRegex = new Regex(@"^( +)?(-|\+)?(\d+)");

        public int MyAtoi(string s)
        {
            // It's ugly and uses a LOT of memory
            // but it's faster than I expected (still quite slow).
            //
            // It doesn't even align with the premise of atoi,
            // but I don't exactly agree with the point of reinventing the wheel.
            //
            // At least it's quite easy to follow and debug.
            var match = DigitRegex.Match(s);
            if (match.Success)
            {
                var value = match.Groups[3].Value.TrimStart('0');

                if (value == string.Empty)
                {
                    return 0;
                }

                var sign = match.Groups[2].Value;
                var isNegative = sign == "-";
                if (value.Length > 10)
                {
                    if (isNegative)
                    {
                        return int.MinValue;
                    }
                    else
                    {
                        return int.MaxValue;
                    }
                }

                var result = Convert.ToInt64(value);

                if (isNegative)
                {
                    result *= -1;
                }

                if (result > int.MaxValue)
                {
                    return int.MaxValue;
                }

                if (result < int.MinValue)
                {
                    return int.MinValue;
                }

                return (int)result;
            }

            return 0;
        }

        [Test]
        [TestCase("42", 42)]
        [TestCase("   -42", -42)]
        [TestCase("4193 with words", 4193)]
        [TestCase("22000000000", int.MaxValue)]
        [TestCase("20000000000000000000", int.MaxValue)]
        [TestCase("  0000000000012345678", 12345678)]
        [TestCase("00000-42a1234", 0)]
        public void Test(string input, int expected)
        {
            var result = MyAtoi(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
