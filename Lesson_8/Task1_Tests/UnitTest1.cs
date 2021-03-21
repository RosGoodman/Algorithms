using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1;

namespace Task1_Tests
{
    [TestClass]
    public class Tests
    {
        #region Quick sort tests

        [TestMethod]
        public void QuickSort_Test()
        {
            //Arrange
            bool sorted = true;
            int count = 10000;
            int max = 50000;
            int min = -49999;

            //Act
            int[] array = RandomArray.GetRandomArray(count, min, max);
            Sortings.Quicksort(array, 0, array.Length-1);

            for (int i = 0; i < array.Length-1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    sorted = false;
                    break;
                }
            }

            //Assert
            Assert.AreEqual(true, sorted);
        }

        [TestMethod]
        public void QuickSort_OneValue_Test()
        {
            //Arrange
            bool sorted = true;
            int count = 1;
            int max = 1;
            int min = 1;

            //Act
            int[] array = RandomArray.GetRandomArray(count, min, max);
            Sortings.Quicksort(array, 0, array.Length - 1);

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    sorted = false;
                    break;
                }
            }

            //Assert
            Assert.AreEqual(true, sorted);
        }

        #endregion

        #region Heap sort tests

        [TestMethod]
        public void HeapSort_Test()
        {
            //Arrange
            bool sorted = true;
            int count = 10000;
            int max = 50000;
            int min = -49999;

            //Act
            int[] array = RandomArray.GetRandomArray(count, min, max);
            Sortings.HeapSort(array);

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    sorted = false;
                    break;
                }
            }

            //Assert
            Assert.AreEqual(true, sorted);
        }

        [TestMethod]
        public void HeapSort_OneValue_Test()
        {
            //Arrange
            bool sorted = true;
            int count = 1;
            int max = 1;
            int min = 1;

            //Act
            int[] array = RandomArray.GetRandomArray(count, min, max);
            Sortings.HeapSort(array);

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    sorted = false;
                    break;
                }
            }

            //Assert
            Assert.AreEqual(true, sorted);
        }

        #endregion

        #region Inserton sort tests

        [TestMethod]
        public void InsertonSort_Test()
        {
            //Arrange
            bool sorted = true;
            int count = 10000;
            int max = 50000;
            int min = -49999;

            //Act
            int[] array = RandomArray.GetRandomArray(count, min, max);
            Sortings.InsertionSort(array);

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    sorted = false;
                    break;
                }
            }

            //Assert
            Assert.AreEqual(true, sorted);
        }

        [TestMethod]
        public void InsertonSort_OneValue_Test()
        {
            //Arrange
            bool sorted = true;
            int count = 1;
            int max = 1;
            int min = 1;

            //Act
            int[] array = RandomArray.GetRandomArray(count, min, max);
            Sortings.InsertionSort(array);

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    sorted = false;
                    break;
                }
            }

            //Assert
            Assert.AreEqual(true, sorted);
        }

        #endregion

        #region Shell sort tests

        [TestMethod]
        public void ShellSort_Test()
        {
            //Arrange
            bool sorted = true;
            int count = 10000;
            int max = 50000;
            int min = -49999;

            //Act
            int[] array = RandomArray.GetRandomArray(count, min, max);
            Sortings.ShellSort(array);

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    sorted = false;
                    break;
                }
            }

            //Assert
            Assert.AreEqual(true, sorted);
        }

        [TestMethod]
        public void ShellSort_OneValue_Test()
        {
            //Arrange
            bool sorted = true;
            int count = 1;
            int max = 1;
            int min = 1;

            //Act
            int[] array = RandomArray.GetRandomArray(count, min, max);
            Sortings.ShellSort(array);

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    sorted = false;
                    break;
                }
            }

            //Assert
            Assert.AreEqual(true, sorted);
        }

        #endregion

        #region Merge sort tests

        [TestMethod]
        public void MergeSort_Test()
        {
            //Arrange
            bool sorted = true;
            int count = 10000;
            int max = 50000;
            int min = -49999;

            //Act
            int[] array = RandomArray.GetRandomArray(count, min, max);
            Sortings.MergeSort(array);

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    sorted = false;
                    break;
                }
            }

            //Assert
            Assert.AreEqual(true, sorted);
        }

        [TestMethod]
        public void MergeSort_OneValue_Test()
        {
            //Arrange
            bool sorted = true;
            int count = 1;
            int max = 1;
            int min = 1;

            //Act
            int[] array = RandomArray.GetRandomArray(count, min, max);
            Sortings.MergeSort(array);

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    sorted = false;
                    break;
                }
            }

            //Assert
            Assert.AreEqual(true, sorted);
        }

        #endregion

        #region Counting sort tests

        [TestMethod]
        public void CountingSort_Test()
        {
            //Arrange
            bool sorted = true;
            int count = 10000;
            int max = 50000;
            int min = 0;

            //Act
            int[] array = RandomArray.GetRandomArray(count, min, max);
            Sortings.CountingSort(array, max);
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    sorted = false;
                    break;
                }
            }

            //Assert
            Assert.AreEqual(true, sorted);
        }

        [TestMethod]
        public void CountingSort_OneValue_Test()
        {
            //Arrange
            bool sorted = true;
            int count = 1;
            int max = 1;
            int min = 1;

            //Act
            int[] array = RandomArray.GetRandomArray(count, min, max);
            Sortings.CountingSort(array, max);

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    sorted = false;
                    break;
                }
            }

            //Assert
            Assert.AreEqual(true, sorted);
        }

        #endregion

        #region Bucket sort tests

        [TestMethod]
        public void BucketSort_Test()
        {
            //Arrange
            bool sorted = true;
            int count = 10000;
            int max = 50000;
            int min = 0;

            //Act
            int[] array = RandomArray.GetRandomArray(count, min, max);
            Sortings.BucketSort(array);
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    sorted = false;
                    break;
                }
            }

            //Assert
            Assert.AreEqual(true, sorted);
        }

        [TestMethod]
        public void BucketSort_OneValue_Test()
        {
            //Arrange
            bool sorted = true;
            int count = 1;
            int max = 1;
            int min = 1;

            //Act
            int[] array = RandomArray.GetRandomArray(count, min, max);
            Sortings.BucketSort(array);

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    sorted = false;
                    break;
                }
            }

            //Assert
            Assert.AreEqual(true, sorted);
        }

        #endregion
    }
}