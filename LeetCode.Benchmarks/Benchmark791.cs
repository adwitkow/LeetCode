using BenchmarkDotNet.Attributes;

namespace LeetCode.Benchmarks
{
    [MemoryDiagnoser]
    public class Benchmark791
    {
        [ParamsSource(nameof(Params))]
        public (string Order, string Input) Param { get; set; }

        private _791 _sut = default!;

        public IEnumerable<(string Order, string Input)> Params => [("ejvdt", "vtedjq"), ("qcglylonk", "lcykngqlo"), ("smjzvxiumph", "xmuzisjvhpm"), ("rngzbwt", "zwrngtb"), ("uohkbpsf", "shkfpbuo"), ("vwltfxekch", "lhcwvfkext"), ("yxiuqmg", "muygxiq"), ("sjvtdzuf", "vufjdstz"), ("lppvfqbsirwtxjk", "kfxtjilvqrbpps"), ("akbeyp", "epybak")];


        [GlobalSetup]
        public void Setup()
        {
            _sut = new _791();
        }

        [Benchmark]
        public string CustomSortString()
        {
            return _sut.CustomSortString(Param.Order, Param.Input);
        }

        [Benchmark]
        public string CustomSortString_BruteSorter()
        {
            return _sut.CustomSortString_BruteSorter(Param.Order, Param.Input);
        }

        [Benchmark]
        public string CustomSortString_BruteSorter_MappedOrder()
        {
            return _sut.CustomSortString_BruteSorter_MappedOrder(Param.Order, Param.Input);
        }
    }
}
