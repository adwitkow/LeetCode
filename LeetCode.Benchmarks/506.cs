using BenchmarkDotNet.Attributes;

namespace LeetCode.Benchmarks
{
    [MemoryDiagnoser]
    public class _506
    {
        [ParamsSource(nameof(ParamRange))]
        public Param506 Param { get; set; } = default!;

        private LeetCode._506 _sut = default!;

        public IEnumerable<Param506> ParamRange => new[]
        {
            new Param506(1),
            new Param506(10),
            new Param506(100),
            new Param506(1_000),
            new Param506(10_000),
        };

        [GlobalSetup]
        public void Setup()
        {
            _sut = new LeetCode._506();
        }

        [Benchmark]
        public string[] FindRelativeRanks_Linq()
        {
            return _sut.FindRelativeRanks_Linq(Param.Scores);
        }

        [Benchmark]
        public string[] FindRelativeRanks_Array_IndexOf()
        {
            return _sut.FindRelativeRanks_Array_IndexOf(Param.Scores);
        }

        [Benchmark]
        public string[] FindRelativeRanks_Span_BinarySearch()
        {
            return _sut.FindRelativeRanks_Span_BinarySearch(Param.Scores);
        }

        public class Param506 : BenchmarkParam
        {
            private static readonly Random _random = new Random(69420);
            private static readonly int[] _possibleScores = Enumerable.Range(0, 1_000_000).ToArray();

            public Param506(int count)
                : base(count.ToString())
            {
                Scores = GenerateScores(count);
            }

            public int[] Scores { get; }

            private static int[] GenerateScores(int count)
            {
                return _random.GetItems(_possibleScores, count);
            }
        }
    }
}
