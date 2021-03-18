using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 3, 5, 3, 98, 1, 2, 5 };
            Sortings sortings = new Sortings();

            sortings.Quicksort(array, 0, array.Length - 1);


            Console.Read();
        }

    }
}
