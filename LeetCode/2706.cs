using System.Text.Json;
using NUnit.Framework;

namespace LeetCode
{
    internal class _2706
    {
        // https://leetcode.com/problems/buy-two-chocolates/
        public int BuyChoco(int[] prices, int money)
        {
            Array.Sort(prices);

            var currentMoney = money;
            for (int i = 0; i < 2; i++)
            {
                currentMoney -= prices[i];
            }

            return currentMoney < 0 ? money : currentMoney;
        }

        [Test]
        [TestCase("[1,2,2]", 3, 0)]
        [TestCase("[3,2,3]", 3, 3)]
        public void Test(string input, int money, int expected)
        {
            var numbers = JsonSerializer.Deserialize<int[]>(input);
            var result = BuyChoco(numbers, money);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
