using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 8;
            int j = 8;
            string[,] map = new string[i, j];
            map[1, 1] = "X";
            map[2, 5] = "X";
            map[2, 6] = "X";
            map[4, 5] = "X";

            Rout rout = new Rout();
            int routsCount = rout.GetRoutCount(map);

            Console.WriteLine();
            Console.WriteLine("Количество возможных маршрутов: " + routsCount);

            Console.Read();
        }
    }
}
