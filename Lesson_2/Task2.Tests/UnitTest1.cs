using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void BinarySearch_ValueInTheArray_Test()
        {
            //Arrange
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 654 };
            int numb = 3;

            //Act
            int indexNumb = Program.BinarySearch(array, 0, array.Length, numb);

            //Assert
            Assert.AreEqual(2, indexNumb, "ожидается 2");
        }

        [TestMethod]
        public void BinarySearch_IsNotInTheArray_Test()
        {
            //Arrange
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 654 };
            int numb = 13;

            //Act
            int indexNumb = Program.BinarySearch(array, 0, array.Length, numb);

            //Assert
            Assert.AreEqual(-1, indexNumb, "ожидается -1");
        }
    }
}