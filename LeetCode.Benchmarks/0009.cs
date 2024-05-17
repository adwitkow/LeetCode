using BenchmarkDotNet.Attributes;

namespace LeetCode.Benchmarks
{
    [MemoryDiagnoser]
    public class _0009
    {
        [ParamsSource(nameof(ParamRange))]
        public int Param { get; set; }

        private LeetCode._0009 _sut = default!;

        public IEnumerable<int> ParamRange => [121, 123454321, 1234543210, -123456, 0, int.MinValue, int.MaxValue];
        
        [GlobalSetup]
        public void Setup()
        {
            _sut = new LeetCode._0009();
        }

        [Benchmark]
        public bool IsPalindrome()
        {
            return _sut.IsPalindrome(Param);
        }

        [Benchmark]
        public bool IsPalindrome_CharArray_Linq()
        {
            return _sut.IsPalindrome_CharArray_Linq(Param);
        }

        [Benchmark]
        public bool IsPalindrome_CharArray_SingleArray()
        {
            return _sut.IsPalindrome_CharArray_SingleArray(Param);
        }
    }
}
