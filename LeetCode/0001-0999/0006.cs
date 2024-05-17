using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/zigzag-conversion/
    public class _0006
    {
        public string Convert(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }

            var table = new char[numRows, s.Length];
            var goingDown = true;

            var currentRow = 0;
            var currentColumn = 0;
            foreach (var ch in s)
            {
                table[currentRow, currentColumn] = ch;

                if (goingDown)
                {
                    if (currentRow < numRows - 1)
                    {
                        currentRow++;
                    }
                    else
                    {
                        goingDown = false;
                        currentRow--;
                        currentColumn++;
                    }
                }
                else
                {
                    if (currentRow > 0)
                    {
                        currentRow--;
                        currentColumn++;
                    }
                    else
                    {
                        goingDown = true;
                        currentRow++;
                    }
                }
            }

            var results = new List<char>();
            foreach (var ch in table)
            {
                if (ch != 0)
                {
                    results.Add(ch);
                }
            }

            return new string(results.ToArray());
        }

        [Test]
        [TestCase("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
        [TestCase("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
        [TestCase("AB", 1, "AB")]
        [TestCase("ABC", 1, "ABC")]
        public void Test(string input, int rowAmount, string expected)
        {
            var result = Convert(input, rowAmount);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
