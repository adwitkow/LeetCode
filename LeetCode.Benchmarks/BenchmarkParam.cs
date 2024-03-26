namespace LeetCode.Benchmarks
{
    public abstract class BenchmarkParam
    {
        public string Name { get; set; } = string.Empty;

        protected BenchmarkParam(string name)
        {
            Name = name;
        }

        public override string ToString() => Name;
    }
}
