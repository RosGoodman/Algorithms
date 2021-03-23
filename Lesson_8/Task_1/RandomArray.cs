using System;

namespace Task_1
{
    public class RandomArray
    {
        /// <summary>Создать массив рандомных чисел.</summary>
        /// <param name="arraySize">Размер массива.</param>
        /// <param name="minValue">Минимальное значение.</param>
        /// <param name="maxValue">Максимальное значение.</param>
        /// <returns>Массив рандомных чисел.</returns>
        public static int[] GetRandomArray(int arraySize, int minValue, int maxValue)
        {
            var random = new Random();
            var randomArray = new int[arraySize];
            for (var i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = random.Next(minValue, maxValue);
            }

            return randomArray;
        }
    }
}
