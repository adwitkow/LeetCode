using BenchmarkDotNet.Attributes;

namespace LeetCode.Benchmarks
{
    [MemoryDiagnoser]
    public class _0930
    {
        [ParamsSource(nameof(Params))]
        public (int[] Nums, int Goal) Param { get; set; }

        private LeetCode._0930 _sut = default!;

        public IEnumerable<(int[] Nums, int Goal)> Params => new[]
        {
            ([1,0,1,0,1], 2),
            ([0,0,0,0,0], 0),
            (new int[1000], 0),
        };

        [GlobalSetup]
        public void Setup()
        {
            _sut = new LeetCode._0930();
        }

        [Benchmark]
        public int NumSubarraysWithSum_PrefixSum()
        {
            return _sut.NumSubarraysWithSum(Param.Nums, Param.Goal);
        }

        [Benchmark]
        public int NumSubarraysWithSum_Intuition()
        {
            return _sut.NumSubarraysWithSum_Intuition(Param.Nums, Param.Goal);
        }
    }
}
