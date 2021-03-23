using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using Task_1;

namespace BenchmarkTests
{
    public class Benchmark
    {
        [Benchmark]
        [ArgumentsSource(nameof(GetArray))]
        public void TestQuicksort(int[] array, int start, int end)
        {
            Sortings.Quicksort(array, start, end);
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetArray))]
        public void TestHeapSort(int[] array, int start, int end)
        {
            Sortings.HeapSort(array);
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetArray))]
        public void TestInsetionSort(int[] array, int start, int end)
        {
            Sortings.InsertionSort(array);
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetArray))]
        public void TestShellSort(int[] array, int start, int end)
        {
            Sortings.ShellSort(array);
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetArray))]
        public void TestMergeSort(int[] array, int start, int end)
        {
            Sortings.MergeSort(array, start, end);
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetArray))]
        public void TestCountiongSort(int[] array, int start, int maxValue)
        {
            Sortings.CountingSort(array, maxValue);
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetArray))]
        public void TestBucketSort(int[] array, int start, int end)
        {
            Sortings.BucketSort(array);
        }



        public IEnumerable<object[]> GetArray()
        {
            int[] array = RandomArray.GetRandomArray(10000, 0, 9999);
            yield return new object[] { array, 0 , 9999};
        }
    }
}
