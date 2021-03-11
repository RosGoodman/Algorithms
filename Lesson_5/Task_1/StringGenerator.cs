using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    public class StringGenerator
    {
        private Random _random = new Random(Environment.TickCount);

        /// <summary>Сгенерировать массив строк случайных символов.</summary>
        /// <param name="count">Количество строк.</param>
        /// <param name="legth">Количество символов.</param>
        /// <returns>Массив строк.</returns>
        public string[] GetRandomStringArray(int count, int length)
        {
            string[] str = new string[count];

            for (int i = 0; i < count; i++)
            {
                str[i] = GetRandomString(length); ;
            }
            return str;
        }

        /// <summary>Получить строку рандомных символов указанной длины.</summary>
        /// <param name="length">Длина строки.</param>
        /// <returns>Сгенерированная строка.</returns>
        public string GetRandomString(int length)
        {
            string chars = "0123456789abcdefghijklmnopqrstuvwxyz";
            StringBuilder builder = new StringBuilder(length);

            builder.Clear();
            for (int j = 0; j < length; ++j)
                builder.Append(chars[_random.Next(chars.Length)]);

            return builder.ToString();
        }

        /// <summary>Получить хэш-таблицу из указанного кол-ва строк.</summary>
        /// <param name="count">Кол-во строк.</param>
        /// <param name="length">Длина строк.</param>
        /// <returns>Хэш-таблица.</returns>
        public HashSet<string> GetHashSet(int count, int length)
        {
            HashSet<string> hashSet = new HashSet<string>();

            while(hashSet.Count < count)
            {
                hashSet.Add(GetRandomString(length));
            }
            return hashSet;
        }
    }
}
