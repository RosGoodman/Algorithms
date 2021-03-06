using BenchmarkDotNet.Running;
using System;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int count = 10000;  //размер массива
            //int length = 5;     //длина строк в массиве

            //StringGenerator stringGenerator = new StringGenerator();
            //string[] strArray = stringGenerator.GetRandomStringArray(count, length);
            //HashSet<string> hashSat = stringGenerator.GetHashSet(count, length);

            //StringFinder stringFinder = new StringFinder();
            //int strIndex = stringFinder.Find(stringGenerator.GetRandomString(length), strArray);

            //Console.WriteLine(strIndex);

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args); //запуск тестов

            Console.ReadLine();
        }
    }
}
