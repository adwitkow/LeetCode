using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/find-the-pivot-integer/description/
    public class _2485
    {
        public int PivotInteger(int n)
        {
            // After seeing the top LeetCode submissions
            // I'm a bit embarassed about this little monster.
            if (n == 1)
            {
                return 1;
            }

            var candidate = n / 2;
            var left = 1;
            var right = n;
            while (left <= right)
            {
                var sumLeft = 0;
                var sumRight = 0;

                for (int i = 1; i <= candidate; i++)
                {
                    sumLeft += i;
                }

                for (int i = candidate; i <= n; i++)
                {
                    sumRight += i;
                }

                if (sumLeft == sumRight)
                {
                    return candidate;
                }
                else if (sumLeft > sumRight)
                {
                    right = candidate - 1;
                }
                else
                {
                    left = candidate + 1;
                }

                candidate = (left + right) / 2;
            }

            return -1;
        }

        [Test]
        [TestCase(8, 6)]
        [TestCase(1, 1)]
        [TestCase(4, -1)]
        [TestCase(49, 35)]
        public void Test(int input, int expected)
        {
            var result = PivotInteger(input);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
