using BenchmarkDotNet.Attributes;

namespace LeetCode.Benchmarks
{
    [MemoryDiagnoser]
    public class _2000
    {
        [ParamsSource(nameof(ParamRange))]
        public Param2000 Param { get; set; } = default!;

        private LeetCode._2000 _sut = default!;

        public IEnumerable<Param2000> ParamRange => new[]
        {
            new Param2000("Same character", 'a', "a"),
            new Param2000("abcdefd:d", 'd', "abcdefd"),
            new Param2000("long (start)", '1', "1hsadmyhfzkrjgtcuyeiqidyqyubkfvjowgqbwywmyrgeggwrrnnnlwqdgdlbwqehalhfrswgquqowbtvhpfgzxbfzowauavthtalrzrfcbuzxoopfwpvlaztfwnpswpgqfshzbsinawjergsipmnyfjeyuqgvdobntbzpvredbofqpumdzjhhuwevhwiuxbdckidimfhwsndifbctzhavswzwzzmscgvcyjapxsfrezouexyglwdlmkdtq"),
            new Param2000("long (end)", '1', "hsadmyhfzkrjgtcuyeiqidyqyubkfvjowgqbwywmyrgeggwrrnnnlwqdgdlbwqehalhfrswgquqowbtvhpfgzxbfzowauavthtalrzrfcbuzxoopfwpvlaztfwnpswpgqfshzbsinawjergsipmnyfjeyuqgvdobntbzpvredbofqpumdzjhhuwevhwiuxbdckidimfhwsndifbctzhavswzwzzmscgvcyjapxsfrezouexyglwdlmkdtq1"),
        };

        [GlobalSetup]
        public void Setup()
        {
            _sut = new LeetCode._2000();
        }

        [Benchmark]
        public string ReversePrefix_Array()
        {
            return _sut.ReversePrefix_Array(Param.Word, Param.Control);
        }

        [Benchmark]
        public string ReversePrefix_Memory()
        {
            return _sut.ReversePrefix_Memory(Param.Word, Param.Control);
        }

        public class Param2000 : BenchmarkParam
        {
            public Param2000(string name, char control, string word)
                : base(name)
            {
                Control = control;
                Word = word;
            }

            public char Control { get; }

            public string Word { get; }
        }
    }
}
