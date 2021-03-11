using System;

namespace Task_2
{
    public class Generator
    {
        private Random random = new Random();

        /// <summary>Сгенерировать массив рандомных чисел от 0 до 1000.</summary>
        /// <param name="length">Размер массива.</param>
        /// <returns>Заполненный массив.</returns>
        public int[] GetIntArray(int length)
        {
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(100);
            }
            return array;
        }
    }
}
