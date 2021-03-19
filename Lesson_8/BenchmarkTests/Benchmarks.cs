using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using Task_1;

namespace BenchmarkTests
{
    public class Benchmark
    {
        #region TestQuickSort

        [Benchmark]
        [ArgumentsSource(nameof(GetArray))]
        public void TestDistanceForPointClass(int[] array, int x)
        {
            Sortings.Quicksort(array, 0, x);
        }

        public IEnumerable<object[]> GetArray()
        {
            int[] array = RandomArray.GetRandomArray(10000, 0, 9999);
            yield return new object[] { array, 5000};
        }

        #endregion
    }
}
