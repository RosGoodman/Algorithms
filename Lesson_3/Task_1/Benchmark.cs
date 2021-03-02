using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Threading;
using Task_1.Points;

namespace Task_1
{
    public class Benchmark
    {
        [ParamsSource(nameof(Point1))]
        public PointClass point1 { get; set; }

        [ParamsSource(nameof(Point2))]
        public PointClass point2 { get; set; }


        public IEnumerable<PointClass> Point1 = new[] { new PointClass(12.2345f, 33.987676f) };
        public IEnumerable<PointClass> Point2 = new[] { new PointClass(126.2345f, 38.987676f) };

        [Benchmark]
        public void TestSum()
        {
            Distance distance = new Distance();
            distance.GetDistance(point1, point2);
        }
    }
}
