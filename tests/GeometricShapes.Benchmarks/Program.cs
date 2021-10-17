using BenchmarkDotNet.Running;

namespace GeometricShapes.Benchmarks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkCollection>();
        }
    }
}