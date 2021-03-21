using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "Data.bin";
            CreateBigRandomFile.OutputData(fileName);
            CreateBigRandomFile.Split(fileName);

            Console.Read();
        }

    }
}
