using System.Text;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/count-and-say/
    public class _0038
    {
        public string CountAndSay(int n)
        {
            if (n <= 1)
            {
                return "1";
            }

            var builder = new StringBuilder();

            var previousResult = CountAndSay(n - 1);
            var previousChar = previousResult[0];
            var count = 0;

            for (int i = 0; i < previousResult.Length; i++)
            {
                var ch = previousResult[i];
                if (ch == previousChar)
                {
                    count++;
                }
                else
                {
                    builder.Append(count);
                    builder.Append(previousChar);

                    previousChar = ch;
                    count = 1;
                }
            }

            builder.Append(count);
            builder.Append(previousChar);

            return builder.ToString();
        }

        [Test]
        [TestCase(1, "1")]
        [TestCase(4, "1211")]
        [TestCase(5, "111221")]
        public void Test(int input, string expected)
        {
            var result = CountAndSay(input);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
