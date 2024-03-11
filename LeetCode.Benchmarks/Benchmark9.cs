using BenchmarkDotNet.Attributes;
using LeetCode._1_9;

namespace LeetCode.Benchmarks
{
    [MemoryDiagnoser]
    public class Benchmark9
    {
        [ParamsSource(nameof(ParamRange))]
        public int _param;

        private _9 _sut = default!;

        public IEnumerable<int> ParamRange => [121, 123454321, 1234543210, -123456, 0, int.MinValue, int.MaxValue];
        
        [GlobalSetup]
        public void Setup()
        {
            _sut = new _9();
        }

        [Benchmark]
        public bool IsPalindrome()
        {
            return _sut.IsPalindrome(_param);
        }

        [Benchmark]
        public bool IsPalindrome_CharArray_Linq()
        {
            return _sut.IsPalindrome_CharArray_Linq(_param);
        }

        [Benchmark]
        public bool IsPalindrome_CharArray_SingleArray()
        {
            return _sut.IsPalindrome_CharArray_SingleArray(_param);
        }
    }
}
