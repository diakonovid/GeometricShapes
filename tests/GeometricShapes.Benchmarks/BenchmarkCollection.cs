using System.Linq;
using BenchmarkDotNet.Attributes;
using GeometricShapes.Shapes;

namespace GeometricShapes.Benchmarks
{
    [MemoryDiagnoser]
    [KeepBenchmarkFiles]
    [MarkdownExporterAttribute.GitHub]
    public class BenchmarkCollection
    {
        private readonly int _iterations = 10000;

        [Benchmark]
        public void CreateCircle()
        {
            var totalArea = 0d;

            foreach (var i in Enumerable.Range(1, _iterations))
            {
                var circle = new Circle(i);
                totalArea += circle.Area;
                totalArea -= circle.Area;
                totalArea += circle.Area;
            }
        }

        [Benchmark]
        public void CreateTriangle()
        {
            var totalArea = 0d;
            var sides = new double[] { 3, 4, 5 };

            foreach (var i in Enumerable.Range(1, _iterations))
            {
                sides[0] += i;
                sides[1] += i;
                sides[2] += i;
                var triangle = new Triangle(sides);
                totalArea += triangle.Area;
                totalArea -= triangle.Area;
                totalArea += triangle.Area;
            }
        }
    }
}