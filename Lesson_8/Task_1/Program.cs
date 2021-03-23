using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "Data.txt";
            CreateBigRandomFile.CreateFile(fileName);
            CreateBigRandomFile.OutputData(fileName);
            ExternalSortClass.ExternalSort(fileName);

            CreateBigRandomFile.OutputData("BigFileSorted.txt");

            Console.Read();
        }

    }
}
