using BenchmarkDotNet.Attributes;

namespace Task_1
{
    public class Benchmark
    {
        public Benchmark()
        {

        }

        public int SumValueType(int value)
        {
            return 9 + value;
        }

        public int SumRefType(object value)
        {
            return 9 + (int)value;
        }


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
