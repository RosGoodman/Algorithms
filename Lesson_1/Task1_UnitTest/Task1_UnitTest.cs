using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1;

namespace Task1_UnitTests
{
    [TestClass]
    public class Task1_UnitTest
    {
        [TestMethod]
        public void SimpleNumb_NumberLessI()
        {
            // Arrange
            int number2 = 0;
            bool actual2 = false;

            // Act
            actual2 = CheckNumbers.SimpleNumb(number2);

            // Assert
            Assert.AreEqual(true, actual2, "Неверный результат.");
        }

        [TestMethod]
        public void SimpleNumb_NumberMoreI_NotSimple()
        {
            // Arrange
            int number1 = 4;
            bool actual1 = false;

            // Act
            actual1 = CheckNumbers.SimpleNumb(number1);

            // Assert
            Assert.AreEqual(false, actual1, "Неверный результат.");
        }

        [TestMethod]
        public void SimpleNumb_NumberMoreI_Simple()
        {
            // Arrange
            int number4 = 23;
            bool actual4 = false;

            // Act
            actual4 = CheckNumbers.SimpleNumb(number4);

            // Assert
            Assert.AreEqual(true, actual4, "Неверный результат.");
        }
    }
}
