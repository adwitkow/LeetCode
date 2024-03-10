using System.Text.Json;
using NUnit.Framework;

namespace LeetCode._30_39
{
    // https://leetcode.com/problems/valid-sudoku/
    public class _36
    {
        private HashSet<int> _validator = new HashSet<int>();

        public bool IsValidSudoku(char[][] board)
        {
            var intBoard = board
                .Select(array => array
                    .Select(element => (int)char.GetNumericValue(element))
                    .ToArray())
                .ToArray();

            for (int x = 0; x < 9; x++)
            {
                if (!ValidateColumn(intBoard, x))
                {
                    return false;
                }
            }

            for (int y = 0; y < 9; y++)
            {
                if (!ValidateRow(intBoard, y))
                {
                    return false;
                }
            }

            for (int x = 0; x < 9; x += 3)
            {
                for (int y = 0; y < 9; y += 3)
                {
                    if (!ValidateBox(intBoard, x, y))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool ValidateRow(int[][] board, int yOffset)
        {
            _validator.Clear();

            var row = board[yOffset];
            foreach (var number in row)
            {
                if (number != -1 && !_validator.Add(number))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidateColumn(int[][] board, int xOffset)
        {
            _validator.Clear();

            for (int y = 0; y < 9; y++)
            {
                var number = board[y][xOffset];

                if (number != -1 && !_validator.Add(number))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidateBox(int[][] board, int xOffset, int yOffset)
        {
            _validator.Clear();

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    var number = board[yOffset + y][xOffset + x];

                    if (number != -1 && !_validator.Add(number))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

#pragma warning disable SA1202 // Elements should be ordered by access

        [Test]
        [TestCase(
            """
                [
                  ["5","3",".",".","7",".",".",".","."],
                  ["6",".",".","1","9","5",".",".","."],
                  [".","9","8",".",".",".",".","6","."],
                  ["8",".",".",".","6",".",".",".","3"],
                  ["4",".",".","8",".","3",".",".","1"],
                  ["7",".",".",".","2",".",".",".","6"],
                  [".","6",".",".",".",".","2","8","."],
                  [".",".",".","4","1","9",".",".","5"],
                  [".",".",".",".","8",".",".","7","9"]
                ]
            """,
            true)]
        [TestCase(
            """
                [
                  ["8","3",".",".","7",".",".",".","."],
                  ["6",".",".","1","9","5",".",".","."],
                  [".","9","8",".",".",".",".","6","."],
                  ["8",".",".",".","6",".",".",".","3"],
                  ["4",".",".","8",".","3",".",".","1"],
                  ["7",".",".",".","2",".",".",".","6"],
                  [".","6",".",".",".",".","2","8","."],
                  [".",".",".","4","1","9",".",".","5"],
                  [".",".",".",".","8",".",".","7","9"]
                ]
            """,
            false)]
        [TestCase(
            """
                [
                  [".",".",".",".","5",".",".","1","."],
                  [".","4",".","3",".",".",".",".","."],
                  [".",".",".",".",".","3",".",".","1"],
                  ["8",".",".",".",".",".",".","2","."],
                  [".",".","2",".","7",".",".",".","."],
                  [".","1","5",".",".",".",".",".","."],
                  [".",".",".",".",".","2",".",".","."],
                  [".","2",".","9",".",".",".",".","."],
                  [".",".","4",".",".",".",".",".","."]
                ]
            """,
            false)]
        public void Test(string input, bool expected)
        {
            var numberArrays = JsonSerializer.Deserialize<char[][]>(input)!;

            foreach (var array in numberArrays)
            {
                foreach (var number in array)
                {
                    Console.Write(number);
                    Console.Write(' ');
                }

                Console.WriteLine();
            }

            var result = IsValidSudoku(numberArrays);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
