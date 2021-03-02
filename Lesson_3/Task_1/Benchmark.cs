using BenchmarkDotNet.Attributes;

namespace Task_1
{
    class Benchmark
    {
        [Benchmark]
        public void TestSum()
        {
            SumValueType(99);
        }

        [Benchmark]
        public void TestSumBoxing()
        {
            object x = 99;
            SumRefType(x);
        }

    }
}
