using System;

namespace Task2
{
    public class Program
    {
        static void Main(string[] args)
        {
            //асимптотическая сложность - log n.
            //т.к. с каждой итерацией цикла размер входящих данных уменьшается в 2 раза
            
            int[] array = new int[] { 1, 3, 6, 8, 34, 43, 56, 567, 2456 };
            int numb = 3;
            int indexNumb = BinarySearch(array, 0, array.Length, numb);

            if(indexNumb != -1)
                Console.WriteLine(indexNumb);
            else
                Console.WriteLine("Число не найдено.");

            Console.ReadLine();
        }

        /// <summary>Бинарный поиск.</summary>
        /// <param name="array">Массив значений.</param>
        /// <param name="left">Индекс первого значения в массиве.</param>
        /// <param name="right">Индекс последнего значения в массиве.</param>
        /// <param name="searchedValue">Искомое значение.</param>
        /// <returns>Индекс искомого числа.</returns>
        public static int BinarySearch(int[] array, int left, int right, int searchedValue)
        {
            while (left <= right)
            {
                var middle = (left + right) / 2;

                if (searchedValue == array[middle])
                {
                    return middle;
                }
                else if (searchedValue < array[middle])
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }
            return -1;
        }
    }
}
