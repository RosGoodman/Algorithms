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
            Generator gen = new Generator();
            int count = 5000;
            float[,] floatArray = gen.FloatCoordinatesGen(count);
            double[,] doubleArray = gen.DoubleCoordinatesGen(count);

            List<PointClass> pointClasses = AddPointsInList(floatArray);
            List<PointStructDouble> pointDoubleStructs = AddPointsStructInList(doubleArray);
            List<PointStructFloat> pointFloatFloat = AddPointsStructInList(floatArray);

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            Console.ReadLine();
        }

        /// <summary>Создать список PointClass из массива.</summary>
        /// <param name="floatArray">Массив с координатами.</param>
        /// <returns>Список экземпляров класса.</returns>
        private static List<PointClass> AddPointsInList(float[,] floatArray)
        {
            List<PointClass> pointClasses = new List<PointClass>();
            PointClass point;
            for (int i = 0; i < floatArray.GetLength(0); i++)
            {
                point = new PointClass(floatArray[i, 0], floatArray[i, 1]);
                pointClasses.Add(point);
            }
            return pointClasses;
        }

        /// <summary>Создать список PointStructDouble из массива.</summary>
        /// <param name="doubleArray">Массив с координатами.</param>
        /// <returns>Список экземпляров.</returns>
        private static List<PointStructDouble> AddPointsStructInList(double[,] doubleArray)
        {
            List<PointStructDouble> pointStructs = new List<PointStructDouble>();
            PointStructDouble point;
            for (int i = 0; i < doubleArray.GetLength(0); i++)
            {
                point = new PointStructDouble(doubleArray[i, 0], doubleArray[i, 1]);
                pointStructs.Add(point);
            }
            return pointStructs;
        }

        /// <summary>Создать список PointStructFloat из массива.</summary>
        /// <param name="floatArray">Массив с координатами.</param>
        /// <returns>Список экземпляров.</returns>
        private static List<PointStructFloat> AddPointsStructInList(float[,] floatArray)
        {
            List<PointStructFloat> pointStructs = new List<PointStructFloat>();
            PointStructFloat point;
            for (int i = 0; i < floatArray.GetLength(0); i++)
            {
                point = new PointStructFloat(floatArray[i, 0], floatArray[i, 1]);
                pointStructs.Add(point);
            }
            return pointStructs;
        }
    }
}
