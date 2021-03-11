﻿
namespace Task_1
{
    public class StringFinder
    {
        /// <summary>Найти строку в массиве.</summary>
        /// <param name="str">Искомая строка.</param>
        /// <param name="strArray">Массив строк.</param>
        /// <returns>Индекс найденной строки.</returns>
        public int Find(string str, string[] strArray)
        {
            for (int i = 0; i < strArray.Length; i++)
            {
                if (str == strArray[i])
                    return i;
            }
            return -1;
        }
    }
}
