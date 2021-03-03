using System;

namespace Task_1
{
    class Generator
    {
        /// <summary>Генератор массива координат типа float.</summary>
        /// <param name="count">Кол-во координат.</param>
        /// <returns>Сгенерированный массив.</returns>
        internal float[,] FloatCoordinatesGen(int count)
        {
            float[,] floatArray = new float[count, 2];
            Random random = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < count; i++)
            {
                floatArray[i, 0] = random.Next(254);
                floatArray[i, 0] = (float)(floatArray[i, 0] + random.NextDouble());
                floatArray[i, 1] = random.Next(254);
                floatArray[i, 1] = (float)(floatArray[i, 0] + random.NextDouble());
            }
            return floatArray;
        }

        /// <summary>Генератор массива координат типа dluble.</summary>
        /// <param name="count">Кол-во координат.</param>
        /// <returns>Сгенерированный массив.</returns>
        internal double[,] DoubleCoordinatesGen(int count)
        {
            double[,] floatArray = new double[count, 2];
            Random random = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < count; i++)
            {
                floatArray[i, 0] = random.Next(254);
                floatArray[i, 0] = floatArray[i, 0] + random.NextDouble();
                floatArray[i, 1] = random.Next(254);
                floatArray[i, 1] = floatArray[i, 0] + random.NextDouble();
            }
            return floatArray;
        }
    }
}
