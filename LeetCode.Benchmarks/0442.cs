using BenchmarkDotNet.Attributes;

namespace LeetCode.Benchmarks
{
    [MemoryDiagnoser]
    public class _0442
    {
        [ParamsSource(nameof(ParamRange))]
        public Param442 Param { get; set; }

        private LeetCode._0442 _sut = default!;

        public IEnumerable<Param442> ParamRange => new[]
        {
            new Param442("[]", Array.Empty<int>()),
            new Param442("[4,3,2,7,8,2,3,1]", [4, 3, 2, 7, 8, 2, 3, 1]),
            new Param442("Many duplicates", GenerateRandomValues(() => Random.Shared.Next(0, 10) < 3)),
            new Param442("Few duplicates", GenerateRandomValues(() => Random.Shared.Next(0, 10) < 8)),
        };

        [GlobalSetup]
        public void Setup()
        {
            _sut = new LeetCode._0442();
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

        public class Param442 : BenchmarkParam
        {
            public Param442(string name, int[] nums)
                : base(name)
            {
                Nums = nums;
            }

            public int[] Nums { get; set; } = Array.Empty<int>();
        }
    }
}
