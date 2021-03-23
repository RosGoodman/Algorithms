using System;
using System.Collections.Generic;
using System.IO;

namespace Task_1
{
    public class ExternalSortClass
    {
        #region External sort

        public static void ExternalSort(string fileName)
        {
            Split(fileName);
            SortTheParts();
            MergeTheParts();
        }

        /// <summary>Разбить файл на несколько маленьких.</summary>
        /// <param name="file">Имя файла.</param>
        private static void Split(string file)
        {
            int split_num = 1;
            StreamWriter sw = new StreamWriter(string.Format("split{0:d5}.dat", split_num));
            long read_line = 0;
            using (StreamReader sr = new StreamReader(file))
            {
                while (sr.Peek() >= 0)
                {
                    //Прогресс
                    if (++read_line % 5000 == 0)
                        Console.Write("{0:f2}%   \r", 100.0 * sr.BaseStream.Position / sr.BaseStream.Length);

                    //Копирование строки
                    sw.WriteLine(sr.ReadLine());

                    // Если файл слишком большой, то сделать еще одно разбитие
                    if (sw.BaseStream.Length > 10000 && sr.Peek() >= 0)
                    {
                        sw.Close();
                        split_num++;
                        sw = new StreamWriter(string.Format("split{0:d5}.dat", split_num));
                    }
                }
            }
            sw.Close();
        }

        /// <summary>Сортировка частей большого файла.</summary>
        private static void SortTheParts()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            foreach (string filePath in Directory.GetFiles(path, "split*.dat"))
            {
                //считываение всех строк в массив.
                string[] arrayStr = File.ReadAllLines(filePath);

                //сортировка
                InsertionSort(arrayStr);
                //Запись в новый файл.
                string newpath = filePath.Replace("split", "sorted");

                File.WriteAllLines(newpath, arrayStr);

                //удаление старого
                File.Delete(filePath);
                arrayStr = null;
                GC.Collect();
            }
        }

        private static void MergeTheParts()
        {
            string folderPath = AppDomain.CurrentDomain.BaseDirectory;
            string[] paths = Directory.GetFiles(folderPath, "sorted*.dat");
            int parts = paths.Length;  //номер части
            int recordSize = 100;       //предполагаемый размер записи
            int maxUsage = 500000000;   //максимальная используемая память
            int buffersize = maxUsage / parts; //байты каждой очереди
            double recordOverhead = 7.5;
            int bufferlen = (int)(buffersize / recordSize / recordOverhead); //кол-во записей в каждой очереди

            //открытие файлов
            StreamReader[] readers = new StreamReader[parts];
            for (int i = 0; i < parts; i++)
                readers[i] = new StreamReader(paths[i]);

            //создание очередей
            Queue<string>[] queues = new Queue<string>[parts];
            for (int i = 0; i < parts; i++)
                queues[i] = new Queue<string>(bufferlen);

            //загрузка очередей
            for (int i = 0; i < parts; i++)
                LoadQueue(queues[i], readers[i], bufferlen);

            //слияние
            StreamWriter sw = new StreamWriter(folderPath + "BigFileSorted.txt");
            bool done = false;
            int lowest_index;
            int lowest_value;
            while (!done)
            {
                //поиск части с наименьшим значением
                lowest_index = -1;
                lowest_value = 0;
                for (int j = 0; j < parts; j++)
                {
                    if (queues[j] != null)
                    {
                        if (lowest_index < 0 || Convert.ToInt32(queues[j].Peek()) <= lowest_value)
                        {
                            lowest_index = j;
                            lowest_value = Convert.ToInt32(queues[j].Peek());
                        }
                    }
                }

                //конец, если ничего нет
                if (lowest_index == -1) { done = true; break; }

                sw.WriteLine(lowest_value);

                queues[lowest_index].Dequeue();

                if (queues[lowest_index].Count == 0)
                {
                    LoadQueue(queues[lowest_index], readers[lowest_index], bufferlen);
                    if (queues[lowest_index].Count == 0)
                    {
                        queues[lowest_index] = null;
                    }
                }
            }
            sw.Close();

            //закрыть и удалить файл
            for (int i = 0; i < parts; i++)
            {
                readers[i].Close();
                File.Delete(paths[i]);
            }
        }

        /// <summary>Загрузить очереди.</summary>
        /// <param name="queue">Очередь для загрузки данных.</param>
        /// <param name="file">Файл, из которого загружаются данные.</param>
        /// <param name="records">Кол-во записей для очереди.</param>
        static void LoadQueue(Queue<string> queue, StreamReader file, int records)
        {
            for (int i = 0; i < records; i++)
            {
                if (file.Peek() < 0) break;
                queue.Enqueue(file.ReadLine());
            }
        }

        //сортировка вставками
        public static void InsertionSort(string[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                var key = Convert.ToInt32(array[i]);
                var j = i;
                while ((j > 0) && (Convert.ToInt32(array[j - 1]) > key))
                {
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }

                array[j] = key.ToString();
            }
        }

        /// <summary>Метод обмена элементов.</summary>
        /// <param name="e1">Элемент 1.</param>
        /// <param name="e2">Элемент 2.</param>
        private static void Swap(ref string e1, ref string e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        #endregion
    }
}
