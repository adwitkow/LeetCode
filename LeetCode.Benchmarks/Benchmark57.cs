using BenchmarkDotNet.Attributes;

namespace LeetCode.Benchmarks
{
    [MemoryDiagnoser]
    public class Benchmark57
    {
        [ParamsSource(nameof(Params))]
        public Benchmark57Target Param { get; set; }

        private _57 _sut = default!;

        public IEnumerable<Benchmark57Target> Params => new[]
        {
            new Benchmark57Target("[[2,4],[5,7],[8,10],[11,13]], [3,6]", [[2,4],[5,7],[8,10],[11,13]], [3,6]),
            new Benchmark57Target("[[0,0],[2,4],[9,9]], [0,7]", [[0,0],[2,4],[9,9]], [0,7]),
            new Benchmark57Target("[[0,10],[14,14],[15,20]], [11,11]", [[0,10],[14,14],[15,20]], [11,11]),
            new Benchmark57Target("[[1,2],[5,6]], [2,5]", [[1,2],[5,6]], [2,5]),
            new Benchmark57Target("[[1,2],[5,6]], [2,10]", [[1,2],[5,6]], [2,10]),
            new Benchmark57Target("[[1,3],[4,4],[5,5]], [3,3]", [[1,3],[4,4],[5,5]], [3,3]),
            new Benchmark57Target("[[1,2],[3,5],[6,7],[8,10],[12,16]], [4,8]", [[1,2],[3,5],[6,7],[8,10],[12,16]], [4,8]),
            new Benchmark57Target("[] [5,7]", [], [5,7]),
            new Benchmark57Target("High volume", GetHighVolumeIntervals(), [21_000, 22_000])
        };

        private int[][] GetHighVolumeIntervals()
        {
            const int bound = 10_000;
            var results = new int[bound][];
            for (int i = 0; i < bound; i++)
            {
                results[i] = [i * 2, i * 2 + 1];
            }

            return results;
        }

        [GlobalSetup]
        public void Setup()
        {
            _sut = new _57();
        }

        [Benchmark]
        public int[][] Insert()
        {
            return _sut.Insert(Param.Intervals, Param.NewInterval);
        }

        [Benchmark]
        public int[][] Insert_Popular()
        {
            return _sut.Insert_Popular(Param.Intervals, Param.NewInterval);
        }

        [Benchmark]
        public int[][] Insert_Editorial()
        {
            return _sut.Insert_Editorial(Param.Intervals, Param.NewInterval);
        }

        public class Benchmark57Target : BenchmarkTarget
        {
            public Benchmark57Target(string name, int[][] intervals, int[] newInterval)
                : base(name)
            {
                Intervals = intervals;
                NewInterval = newInterval;
            }

            public int[][] Intervals { get; set; } = Array.Empty<int[]>();

            public int[] NewInterval { get; set; } = Array.Empty<int>();
        }
    }
}
