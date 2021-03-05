using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 10000;
            int length = 5;
            string[] str = StringGenerator.GetRandomStringArray(count, length);

            Console.ReadLine();
        }
    }
}
