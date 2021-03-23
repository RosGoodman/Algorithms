using System.Collections.Generic;

namespace Task_1
{
    public class Sortings
    {
        #region Quick sort

        /// <summary>Сортировать массив (сортировка Хоара).</summary>
        /// <param name="array">Сортируемый массив.</param>
        /// <param name="start">Точка старта.</param>
        /// <param name="end">Конец сортируемой части массива, так же индекс числа относительно которого
        /// происходит сортировка.</param>
        public static void Quicksort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = Partition(array, start, end);
            Quicksort(array, start, pivot - 1);
            Quicksort(array, pivot + 1, end);
            return;
        }

        /// <summary>Перестановка массива относительно end.</summary>
        /// <param name="array">Сортируемый массив.</param>
        /// <param name="start">Точка старта.</param>
        /// <param name="end">Конец сортируемой части массива, так же индекс числа относительно которого
        /// происходит сортировка.</param>
        /// <returns>Следующая относительная точка сортировки.</returns>
        private static int Partition(int[] array, int start, int end)
        {
            int marker = start;//divides left and right subarrays
            for (int i = start; i < end; i++)
            {
                if (array[i] < array[end]) //array[end] is pivot
                {
                    Swap(ref array[marker], ref array[i]);
                    marker += 1;
                }
            }
            Swap(ref array[marker], ref array[end]);
            return marker;
        }

        #endregion

        #region Heap sort

        /// <summary>Сортировать массив (пирамидальная сортировка).</summary>
        /// <param name="array"></param>
        public static void HeapSort(int[] array)
        {
            int length = array.Length;

            // Построение кучи (перегруппируем массив)
            for (int i = length / 2 - 1; i >= 0; i--)
                Heapify(array, length, i);

            // Один за другим извлекаем элементы из кучи
            for (int i = length - 1; i >= 0; i--)
            {
                // Перемещаем текущий корень в конец
                Swap(ref array[0], ref array[i]);

                // вызываем процедуру heapify на уменьшенной куче
                Heapify(array, i, 0);
            }
        }

        /// <summary>Преобразование в двоичную кучу поддерева.</summary>
        /// <param name="array">Преобразуемый массив (поддерево).</param>
        /// <param name="count">Размер кучи.</param>
        /// <param name="i">Индекс корневого узла.</param>
        private static void Heapify(int[] array, int count, int i)
        {
            int largest = i;
            // Инициализируем наибольший элемент как корень
            int l = 2 * i + 1; // left = 2*i + 1
            int r = 2 * i + 2; // right = 2*i + 2

            // Если левый дочерний элемент больше корня
            if (l < count && array[l] > array[largest])
                largest = l;

            // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
            if (r < count && array[r] > array[largest])
                largest = r;

            // Если самый большой элемент не корень
            if (largest != i)
            {
                Swap(ref array[i], ref array[largest]);

                // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
                Heapify(array, count, largest);
            }
        }

        #endregion

        #region Insertion sort

        //сортировка вставками
        public static void InsertionSort(int[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                var key = array[i];
                var j = i;
                while ((j > 0) && (array[j - 1] > key))
                {
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }

                array[j] = key;
            }
        }

        #endregion

        #region Shell sort

        /// <summary>Сортировка Шелла.</summary>
        /// <param name="array">Сортируемый массив.</param>
        /// <returns>Отсортированный массив.</returns>
        public static void ShellSort(int[] array)
        {
            //расстояние между элементами, которые сравниваются
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j -= d;
                    }
                }

                d /= 2;
            }
        }

        #endregion

        #region Merge Sort

        /// <summary>Сортировка слиянием.</summary>
        /// <param name="array">Сортируемый массив.</param>
        /// <returns>Отсортированный массив.</returns>
        public static void MergeSort(int[] array)
        {
            MergeSort(array, 0, array.Length - 1);
        }


        public static void MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                if (highIndex - lowIndex == 1)
                {
                    if (array[highIndex] < array[lowIndex])
                    {
                        Swap(ref array[lowIndex], ref array[highIndex]);
                    }
                }
                else
                {
                    var middleIndex = (lowIndex + highIndex) / 2;
                    MergeSort(array, lowIndex, middleIndex);
                    MergeSort(array, middleIndex + 1, highIndex);
                    Merge(array, lowIndex, middleIndex, highIndex);
                }
            }
        }

        private static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }

        #endregion

        #region Counting sort

        /// <summary>Сортировка подсчетом.</summary>
        /// <param name="array">Сортируемый массив.</param>
        /// <param name="max">Максимальное значение.</param>
        public static void CountingSort(int[] array, int max) 
        {
            int[] countArray = new int[max+1];

            for (int i = 0; i < array.Length; i++)
                countArray[array[i]]++;

            var b = 0;
            for (int j = 0; j < countArray.Length; j++)
            {
                for (int i = 0; i < countArray[j]; i++)
                {
                    array[b++] = j;
                }
            }
        }

        #endregion

        #region Bucket sort

        /// <summary>Блочная сортировка.</summary>
        /// <param name="array">Сортируемый массив.</param>
        public static void BucketSort(int[] array)
        {
            if (array == null || array.Length < 2)
                return;

            int max = array[0];
            int min = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];

                if (array[i] < min)
                    min = array[i];
            }

            // Создание временного массива "карманов" в количестве,
            // достаточном для хранения всех возможных элементов,
            // чьи значения лежат в диапазоне между minValue и maxValue.
            // Т.е. для каждого элемента массива выделяется "карман" List<int>.
            // При заполнении данных "карманов" элементы исходного не отсортированного массива
            // будут размещаться в порядке возрастания собственных значений "слева направо".

            List<int>[] bucket = new List<int>[max - min + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            // Занесение значений в пакеты
            for (int i = 0; i < array.Length; i++)
            {
                bucket[array[i] - min].Add(array[i]);
            }

            // Восстановление элементов в исходный массив
            // из карманов в порядке возрастания значений
            int position = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        array[position] = bucket[i][j];
                        position++;
                    }
                }
            }
        }

        #endregion

        /// <summary>Метод обмена элементов.</summary>
        /// <param name="e1">Элемент 1.</param>
        /// <param name="e2">Элемент 2.</param>
        private static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }
    }
}
