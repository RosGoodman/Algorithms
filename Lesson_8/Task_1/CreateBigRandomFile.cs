using System;
using System.IO;

namespace Task_1
{
    public class CreateBigRandomFile
    {
        /// <summary>Создать файл с рандомными значениями.</summary>
        /// <param name="fileName"></param>
        public static void CreateFile(string fileName)
        {
            int numb;
            using (StreamWriter bw = new StreamWriter(File.Create(fileName, 65536)))
            {
                Random rnd = new Random();
                for (int i = 0; i < 256000; i++)
                {
                    numb = rnd.Next(0, 256000000);
                    bw.WriteLine(numb);
                }
            }
        }

        /// <summary>Вывести 100 первых чисел из файла.</summary>
        /// <param name="file">Имя файла.</param>
        public static void OutputData(string file)
        {
            using (BinaryReader br = new BinaryReader(File.OpenRead(file)))
            {
                long length = br.BaseStream.Length;
                long position = 0;
                for (int i = 0; i < 100; i++)
                {
                    if (position == length)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write($"{br.ReadInt32()} ");
                        position += 4;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
