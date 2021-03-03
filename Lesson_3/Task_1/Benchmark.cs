using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Threading;
using Task_1.Points;

namespace Task_1
{
    public class Benchmark
    {
        [Benchmark]
        [ArgumentsSource(nameof(Numbers))]
        public void TestDistance(PointClass point1, PointClass point2)
        {
            Distance distance = new Distance();
            distance.GetDistance(point1, point2);
        }

        public IEnumerable<PointClass[]> Numbers() // for multiple arguments it's an IEnumerable of array of objects (object[])
        {
            yield return new PointClass[] {new PointClass(12.2345f, 33.987676f), new PointClass(126.2345f, 38.987676f) };
            yield return new PointClass[] {new PointClass(33.2345f, 112.987676f), new PointClass(0.2345f, 55.987676f) };
        }


        //[ParamsSource(nameof(Point1))]
        //public PointClass point1 { get; set; }

        //[ParamsSource(nameof(Point2))]
        //public PointClass point2 { get; set; }


        //public IEnumerable<PointClass> Point1 = new[] { new PointClass(12.2345f, 33.987676f) };
        //public IEnumerable<PointClass> Point2 = new[] { new PointClass(126.2345f, 38.987676f) };

        //[Benchmark]
        //public void TestDistance()
        //{
        //    Distance distance = new Distance();
        //    distance.GetDistance(point1, point2);
        //}
    }
}
