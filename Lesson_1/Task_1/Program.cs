using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 11;
            SimpleNumb(n);

            Console.WriteLine(SimpleNumb(n));
            Console.ReadLine();
        }

        /// <summary>Проверка, является ли число простым.</summary>
        /// <param name="n">Проверяемое число.</param>
        /// <returns>True/False - простое/не простое</returns>
        private static bool SimpleNumb(int number)
        {
            int d = 0;
            int i = 2;

            while(i < number)
            {
                if (number % i == 0) d++;

                i++;
            }

            if (d == 0)
                return true;
            else
                return false;
        }
    }
}
