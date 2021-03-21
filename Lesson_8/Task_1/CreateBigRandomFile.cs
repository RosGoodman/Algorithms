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
            using (BinaryWriter bw = new BinaryWriter(File.Create(fileName, 65536)))
            {
                Random rnd = new Random();
                for (int i = 0; i < 256000000; i++)
                {
                    bw.Write(rnd.Next(0, 256000000));
                }
            }
        }

        public static void OutputData(string file) // вывод первых 100 чисел для проверки
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

        public static void Split(string file)
        {
            int split_num = 1;
            StreamWriter sw = new StreamWriter(string.Format("split{0:d5}.dat", split_num));
            long read_line = 0;
            using (StreamReader sr = new StreamReader(file))
            {
                while (sr.Peek() >= 0)
                {
                    // Progress reporting
                    if (++read_line % 5000 == 0)
                        Console.Write("{0:f2}%   \r", 100.0 * sr.BaseStream.Position / sr.BaseStream.Length);

                    // Copy a line
                    sw.WriteLine(sr.ReadLine());

                    // If the file is big, then make a new split,
                    // however if this was the last line then don't bother
                    if (sw.BaseStream.Length > 100000000 && sr.Peek() >= 0)
                    {
                        sw.Close();
                        split_num++;
                        sw = new StreamWriter(string.Format("split{0:d5}.dat", split_num));
                    }
                }
            }
            sw.Close();
        }
    }
}
