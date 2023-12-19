using System.Text.Json;
using NUnit.Framework;

namespace LeetCode
{
    // https://leetcode.com/problems/image-smoother/
    internal class _661
    {
        public static int[,] Offsets = new int[,]
        {
            { -1, -1 }, { -1 ,0 }, { -1, 1 },
            { 0, -1 }, { 0, 0 }, { 0, 1 },
            { 1, -1 }, { 1, 0 }, { 1, 1 }
        };

        public int[][] ImageSmoother(int[][] img)
        {
            var lengthX = img[0].Length;
            var lengthY = img.GetLength(0);
            var smoothed = new int[lengthY][];
            for (int z = 0; z < lengthY; z++)
            {
                smoothed[z] = new int[lengthX];
            }

            var toFilter = new List<int>();

            for (int y = 0; y < img.Length; y++)
            {
                for (int x = 0; x < img[y].Length; x++)
                {
                    toFilter.Clear();

                    for (int i = 0; i < Offsets.GetLength(0); i++)
                    {
                        var offsetX = x + Offsets[i, 0];
                        var offsetY = y + Offsets[i, 1];

                        if (offsetX < 0
                            || offsetX >= lengthX
                            || offsetY < 0
                            || offsetY >= lengthY)
                        {
                            continue;
                        }

                        var current = img[offsetY][offsetX];
                        toFilter.Add(current);

                    }

                    smoothed[y][x] = (int)toFilter.Average();
                }
            }

            return smoothed;
        }

        [Test]
        [TestCase("[[1,1,1],[1,0,1],[1,1,1]]", "[[0,0,0],[0,0,0],[0,0,0]]")]
        [TestCase("[[100,200,100],[200,50,200],[100,200,100]]", "[[137,141,137],[141,138,141],[137,141,137]]")]
        [TestCase("[[2,3,4],[5,6,7],[8,9,10],[11,12,13],[14,15,16]]", "[[4,4,5],[5,6,6],[8,9,9],[11,12,12],[13,13,14]]")]
        public void Test(string input, string expectedSerialized)
        {
            var numbers = JsonSerializer.Deserialize<int[][]>(input);
            var result = ImageSmoother(numbers);

            var expected = JsonSerializer.Deserialize<int[][]>(expectedSerialized);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
