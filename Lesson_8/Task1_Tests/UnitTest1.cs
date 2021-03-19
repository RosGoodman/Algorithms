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
    }
}