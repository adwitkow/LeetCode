using BenchmarkDotNet.Attributes;

namespace LeetCode.Benchmarks
{
    [MemoryDiagnoser]
    public class Benchmark442
    {
        [ParamsSource(nameof(ParamRange))]
        public Benchmark442Target Param { get; set; }

        private _442 _sut = default!;

        public IEnumerable<Benchmark442Target> ParamRange => new[]
        {
            new Benchmark442Target("[]", Array.Empty<int>()),
            new Benchmark442Target("[4,3,2,7,8,2,3,1]", [4, 3, 2, 7, 8, 2, 3, 1]),
            new Benchmark442Target("Many duplicates", GenerateRandomValues(() => Random.Shared.Next(0, 10) < 3)),
            new Benchmark442Target("Few duplicates", GenerateRandomValues(() => Random.Shared.Next(0, 10) < 8)),
        };

        [GlobalSetup]
        public void Setup()
        {
            _sut = new _442();
        }

        [Benchmark]
        public IList<int> FindDuplicates_Linq()
        {
            return _sut.FindDuplicates_Linq(Param.Nums);
        }

        [Benchmark]
        public IList<int> FindDuplicates_HashSet()
        {
            return _sut.FindDuplicates_HashSet(Param.Nums);
        }

        [Benchmark]
        public IList<int> FindDuplicates_Sort()
        {
            return _sut.FindDuplicates_Sort(Param.Nums);
        }

        [Benchmark]
        public IList<int> FindDuplicates_Inverts()
        {
            return _sut.FindDuplicates_Inverts(Param.Nums);
        }

        private int[] GenerateRandomValues(Func<bool> predicate)
        {
            var values = new int[100_000];
            var previous = 0;
            values[0] = 1;
            for (int i = 1; i < 100_000; i++)
            {
                var invoked = predicate.Invoke();
                if (invoked && previous != values[i - 1])
                {
                    values[i] = values[i - 1];
                }
                else
                {
                    values[i] = i;
                }

                previous = values[i - 1];
            }

            if (values.GroupBy(x => x).Any(group => group.Count() > 2))
            {
                throw new InvalidOperationException($"More than one duplicate");
            }

            Random.Shared.Shuffle(values);

            return values;
        }

        public class Benchmark442Target : BenchmarkTarget
        {
            public Benchmark442Target(string name, int[] nums)
                : base(name)
            {
                Nums = nums;
            }

            public int[] Nums { get; set; } = Array.Empty<int>();
        }
    }
}
