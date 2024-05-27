using BenchmarkDotNet.Attributes;

namespace LeetCode.Benchmarks
{
    [MemoryDiagnoser]
    public class _1608
    {
        private static readonly Random Random = new Random(69420);
        private static readonly int[] Choices = Enumerable.Range(0, 1000).ToArray();

        [ParamsSource(nameof(Params))]
        public Param1608 Param { get; set; }

        private LeetCode._1608 _sut = default!;

        public IEnumerable<Param1608> Params => new[]
        {
            Generate(1),
            Generate(10),
            Generate(50),
            Generate(100),
        };

        [GlobalSetup]
        public void Setup()
        {
            _sut = new LeetCode._1608();
        }

        [Benchmark]
        public int Array_BinarySearch()
        {
            return _sut.SpecialArray_Array_BinarySearch(Param.Nums);
        }

        [Benchmark]
        public int Span_BinarySearch()
        {
            return _sut.SpecialArray_Span_BinarySearch(Param.Nums);
        }

        [Benchmark(Baseline = true)]
        public int CountingSort()
        {
            return _sut.SpecialArray_CountingSort(Param.Nums);
        }

        private static Param1608 Generate(int length)
        {
            return new Param1608($"{length} elements", Random.GetItems(Choices, length));
        }

        public class Param1608 : BenchmarkParam
        {
            public Param1608(string name, int[] nums)
                : base(name)
            {
                Nums = nums;
            }

            public int[] Nums { get; set; } = Array.Empty<int>();
        }
    }
}
