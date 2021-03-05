using System;
using System.Text;

namespace Task_1
{
    internal static class StringGenerator
    {
        /// <summary>Сгенерировать массив строк случайных символов.</summary>
        /// <param name="count">Количество строк.</param>
        /// <param name="legth">Количество символов.</param>
        /// <returns>Массив строк.</returns>
        internal static string[] GetRandomStringArray(int count, int length)
        {
            string[] str = new string[count];
            Random _random = new Random(Environment.TickCount);
            string chars = "0123456789abcdefghijklmnopqrstuvwxyz";
            StringBuilder builder = new StringBuilder(length);

            for (int i = 0; i < count; i++)
            {
                builder.Clear();
                for (int j = 0; j < length; ++j)
                    builder.Append(chars[_random.Next(chars.Length)]);

                str[i] = builder.ToString();
            }

            return str;
        }
    }
}
