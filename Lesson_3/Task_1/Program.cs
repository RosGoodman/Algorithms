using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using Task_1.Points;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //тут некоторая эмуляция работы программы (необязательное)
            Generator gen = new Generator();
            int count = 5000;
            float[,] floatArray = gen.FloatCoordinatesGen(count);
            double[,] doubleArray = gen.DoubleCoordinatesGen(count);

            List<PointClass> pointClasses = GetListPoints.AddPointsInList(floatArray);
            List<PointStructDouble> pointDoubleStructs = GetListPoints.AddPointsStructInList(doubleArray);
            List<PointStructFloat> pointFloatFloat = GetListPoints.AddPointsStructInList(floatArray);

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args); //запуск тестов

            Console.ReadLine();
        }
    }
}
