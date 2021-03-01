
namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator gen = new Generator();
            int count = 5000;
            float[,] floatArray = gen.FloatCoordinatesGen(count);
            double[,] doubleArray = gen.DoubleCoordinatesGen(count);


        }
    }
}
