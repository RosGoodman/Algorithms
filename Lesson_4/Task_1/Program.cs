using BenchmarkDotNet.Running;
using System;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args); //запуск тестов

            Console.ReadLine();
        }
    }
}
