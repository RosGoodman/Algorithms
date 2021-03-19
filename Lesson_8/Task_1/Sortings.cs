﻿using System;

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
            int temp;
            int marker = start;//divides left and right subarrays
            for (int i = start; i < end; i++)
            {
                if (array[i] < array[end]) //array[end] is pivot
                {

                    /////////////////////////////////////////////////////////////////////////
                    ///TODO: протестить скорость при выносе перестановки в отдельный метод (DRY)
                    /////////////////////////////////////////////////////////////////////////
                    
                    temp = array[marker]; // swap
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            //put pivot(array[end]) between left and right subarrays
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }

        #endregion

        #region Heap sort

        /// <summary>Сортировать массив (пирамидальная сортировка).</summary>
        /// <param name="arr"></param>
        public static void HeapSort(int[] arr)
        {
            int length = arr.Length;

            // Построение кучи (перегруппируем массив)
            for (int i = length / 2 - 1; i >= 0; i--)
                Heapify(arr, length, i);

            // Один за другим извлекаем элементы из кучи
            for (int i = length - 1; i >= 0; i--)
            {
                // Перемещаем текущий корень в конец
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // вызываем процедуру heapify на уменьшенной куче
                Heapify(arr, i, 0);
            }
        }

        /// <summary>Преобразование в двоичную кучу поддерева.</summary>
        /// <param name="arr">Преобразуемый массив (поддерево).</param>
        /// <param name="count">Размер кучи.</param>
        /// <param name="i">Индекс корневого узла.</param>
        private static void Heapify(int[] arr, int count, int i)
        {
            int largest = i;
            // Инициализируем наибольший элемент как корень
            int l = 2 * i + 1; // left = 2*i + 1
            int r = 2 * i + 2; // right = 2*i + 2

            // Если левый дочерний элемент больше корня
            if (l < count && arr[l] > arr[largest])
                largest = l;

            // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
            if (r < count && arr[r] > arr[largest])
                largest = r;

            // Если самый большой элемент не корень
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
                Heapify(arr, count, largest);
            }
        }

        //private static void PrintArr(int[] array)
        //{
        //    string str = string.Empty;
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        str += array[i] + " ";
        //    }
        //    Console.WriteLine(str);
        //}

        #endregion

        #region Insertion sort

        //сортировка вставками
        public static int[] InsertionSort(int[] array)
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

            return array;
        }

        #endregion

        #region Shell sort

        /// <summary>Сортировка Шелла.</summary>
        /// <param name="array">Сортируемый массив.</param>
        /// <returns>Отсортированный массив.</returns>
        public static int[] ShellSort(int[] array)
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
                        j = j - d;
                    }
                }

                d = d / 2;
            }

            return array;
        }

        #endregion

        #region Merge Sort

        /// <summary>Сортировка слиянием.</summary>
        /// <param name="array">Сортируемый массив.</param>
        /// <returns>Отсортированный массив.</returns>
        public static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }


        private static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                if (highIndex - lowIndex == 1)
                {
                    if (array[highIndex] < array[lowIndex])
                    {
                        var t = array[lowIndex];
                        array[lowIndex] = array[highIndex];
                        array[highIndex] = t;
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

            return array;
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
        /// <param name="count">Размер массива.</param>
        /// <param name="max">Максимальное значение.</param>
        public static void CountingSort(int[] array, int count, int max) 
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
