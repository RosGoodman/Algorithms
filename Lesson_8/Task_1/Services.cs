using System;
using System.IO;

namespace Task_1
{
    public class Services
    {
        public static void ReadFile()
        {

        }

        public static void WriteFile()
        {
            using (FileStream fstream = File.OpenRead("text.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");
            }
        }
    }
}
