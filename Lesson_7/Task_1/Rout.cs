
using System;

namespace Task_1
{
    public class Rout
    {
        /// <summary>Вычислить кол-во путеймежду точками (Движение только вниз или направо).</summary>
        /// <param name="map">Двумерный массив представляющий карту (x - препятствие).</param>
        /// <returns>Кол-во возможных маршрутов.</returns>
        public int GetRoutCount(string[,] map)
        {
            map[0, 0] = "1";
            for (int j = 1; j < map.GetLength(1); j++)
            {
                if (map[j - 1, 0] == "1" && map[j, 0] != "X")
                    map[j, 0] = "1";
                else if(map[j - 1, 0] == null)
                    map[j, 0] = "";

                if (map[0, j - 1] == "1" && map[0, j] != "X")
                    map[0, j] = "1";
                else if (map[0, j] == null)
                    map[0, j] = "";
            }

            for (int i = 1; i < map.GetLength(0); i++)
            {
                for (int j = 1; j < map.GetLength(1); j++)
                {
                    int routs1 = 0;
                    int routs2 = 0;

                    if (map[i, j - 1] != "X" && map[i, j - 1] != string.Empty)
                        routs1 = Convert.ToInt32(map[i, j - 1]);

                    if (map[i - 1, j] != "X" && map[i - 1, j] != string.Empty)
                        routs2 = Convert.ToInt32(map[i - 1, j]);

                    if(map[i,j] != "X")
                        map[i, j] = (routs1 + routs2).ToString();
                }
            }

            Print2(map);

            int routsCount = Convert.ToInt32(map[map.GetLength(0) - 1, map.GetLength(1) - 1]);

            return routsCount;
        }

        /// <summary>Вывести в консоль карту, с числовым отображением кол-ва маршрутов.</summary>
        /// <param name="map">Выводимая карта.</param>
        private static void Print2(string[,] map)
        {
            int i, j;
            for (i = 0; i < map.GetLength(0); i++)
            {
                string space = string.Empty;
                for (j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == "X")
                        Console.ForegroundColor = ConsoleColor.Red;

                    space = new string(' ', 5 - map[i, j].Length);
                    Console.Write(map[i, j] + space);

                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write("\r\n");
            }
        }
    }
}
