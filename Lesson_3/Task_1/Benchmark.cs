using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using Task_1.Points;

namespace Task_1
{
    public class Benchmark
    {
        #region TestDistanceForPointClass

        [Benchmark]
        [ArgumentsSource(nameof(PointClasses))]
        public void TestDistanceForPointClass(PointClass point1, PointClass point2)
        {
            Distance distance = new Distance();
            distance.GetDistance(point1, point2);
        }

        public IEnumerable<PointClass[]> PointClasses()
        {
            Generator gen = new Generator();
            int count = 4;
            float[,] floatArray = gen.FloatCoordinatesGen(count);
            List<PointClass> pointClasses = GetListPoints.AddPointsInList(floatArray);
            yield return new PointClass[] { pointClasses[0], pointClasses[1] };
            yield return new PointClass[] { pointClasses[1], pointClasses[2] };
            yield return new PointClass[] { pointClasses[2], pointClasses[3] };
        }

        #endregion

        #region TestDistanceForPointStructDouble

        [Benchmark]
        [ArgumentsSource(nameof(PointStructDouble))]
        public void TestDistanceForPointStructDouble(PointStructDouble point1, PointStructDouble point2)
        {
            Distance distance = new Distance();
            distance.GetDistance(point1, point2);
        }

        public IEnumerable<object[]> PointStructDouble()
        {
            Generator gen = new Generator();
            int count = 4;
            double[,] doubleArray = gen.DoubleCoordinatesGen(count);
            List<PointStructDouble> pointStructs = GetListPoints.AddPointsStructInList(doubleArray);
            yield return new object[] { pointStructs[0], pointStructs[1] };
            yield return new object[] { pointStructs[1], pointStructs[2] };
            yield return new object[] { pointStructs[2], pointStructs[3] };
        }

        #endregion

        #region TestDistanceForPointStructFloat

        [Benchmark]
        [ArgumentsSource(nameof(PointStructFloat))]
        public void TestDistanceForPointStructFloat(PointStructFloat point1, PointStructFloat point2)
        {
            Distance distance = new Distance();
            distance.GetDistance(point1, point2);
        }

        public IEnumerable<object[]> PointStructFloat()
        {
            Generator gen = new Generator();
            int count = 4;
            float[,] floatArray = gen.FloatCoordinatesGen(count);
            List<PointStructFloat> pointStructs = GetListPoints.AddPointsStructInList(floatArray);
            yield return new object[] { pointStructs[0], pointStructs[1] };
            yield return new object[] { pointStructs[1], pointStructs[2] };
            yield return new object[] { pointStructs[2], pointStructs[3] };
        }

        #endregion

        #region TestDistanceNotSqrt

        [Benchmark]
        [ArgumentsSource(nameof(PointStructFloat_2))]
        public void TestDistanceNotSqrt(PointStructFloat point1, PointStructFloat point2)
        {
            Distance distance = new Distance();
            distance.GetDistanceNotSqrt(point1, point2);
        }

        public IEnumerable<object[]> PointStructFloat_2()
        {
            Generator gen = new Generator();
            int count = 4;
            float[,] floatArray = gen.FloatCoordinatesGen(count);
            List<PointStructFloat> pointStructs = GetListPoints.AddPointsStructInList(floatArray);
            yield return new object[] { pointStructs[0], pointStructs[1] };
            yield return new object[] { pointStructs[1], pointStructs[2] };
            yield return new object[] { pointStructs[2], pointStructs[3] };
        }

        #endregion
    }
}
