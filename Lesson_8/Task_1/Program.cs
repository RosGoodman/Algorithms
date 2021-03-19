using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 3, 5, 3, 98, 1, 2, 5, 44, 32, 70, 70, 85, 11, 4, 23, 48 };

            //Sortings.Quicksort(array, 0, array.Length - 1);
            Sortings.ShellSort(array);

            Console.Read();
        }

    }
}
