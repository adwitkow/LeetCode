namespace LeetCode.Benchmarks
{
    public abstract class BenchmarkTarget
    {
        public string Name { get; set; } = string.Empty;

        protected BenchmarkTarget(string name)
        {
            Name = name;
        }

        public override string ToString() => Name;
    }
}
