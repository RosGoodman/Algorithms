using System;

namespace Task_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int y = 6;
            Console.WriteLine("Получено рекурсией 5-е число: {0}", Program.FibonachiRecurive(n));
            Console.WriteLine("Получено рекурсией 6-е число: {0}", Program.FibonachiRecurive(y));

            Console.ReadLine();
        }

        /// <summary>Послучить число Фибоначчи рекурсией.</summary>
        /// <param name="n">Порядковый номер числа.</param>
        /// <returns>Значение.</returns>
        public static int FibonachiRecurive(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return FibonachiRecurive(n - 1) + FibonachiRecurive(n - 2);
            }
        }

        /// <summary>Получить число Фибоначчи циклом.</summary>
        /// <param name="n">Порядковый номер числа.</param>
        /// <returns>Значение.</returns>
        public static int FibonacciCycle(int n)
        {
            int a = 0;
            int b = 1;
            int tmp;

            for (int i = 0; i < n; i++)
            {
                tmp = a;
                a = b;
                b += tmp;
            }

            return a;
        }
    }
}
