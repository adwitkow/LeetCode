using NUnit.Framework;

namespace LeetCode._1_9
{
    // https://leetcode.com/problems/reverse-integer/
    internal class _7
    {
        public int Reverse(int x)
        {
            // It's ugly and uses a LOT of memory
            // but it's faster than I expected (still quite slow)
            try
            {
                if (x < 0)
                {
                    var reversed = new string(x.ToString().Substring(1).Reverse().ToArray());
                    return Convert.ToInt32(reversed) * -1;
                }
                else
                {
                    var reversed = new string(x.ToString().Reverse().ToArray());
                    return Convert.ToInt32(reversed);
                }
            }
            catch
            {
                return 0;
            }
        }

        [Test]
        [TestCase(123, 321)]
        [TestCase(-123, -321)]
        [TestCase(-120, -21)]
        public void Test(int input, int expected)
        {
            var result = Reverse(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
