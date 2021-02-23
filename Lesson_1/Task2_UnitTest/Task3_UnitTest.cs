using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_3;

namespace Task3_UnitTests
{
    [TestClass]
    public class Task3_UnitTest
    {
        [TestMethod]
        public void Test_FibonachiRecurive()
        {
            // Arrange
            int number1 = 1;
            int number2 = 3;
            int number3 = 5;
            int number4 = 11;

            // Act
            int actual1 = Program.FibonachiRecurive(number1);
            int actual2 = Program.FibonachiRecurive(number2);
            int actual3 = Program.FibonachiRecurive(number3);
            int actual4 = Program.FibonachiRecurive(number4);

            // Assert
            Assert.AreEqual(1, actual1, "Ожидается 1");
            Assert.AreEqual(2, actual2, "Ожидается 2");
            Assert.AreEqual(5, actual3, "Ожидается 5");
            Assert.AreEqual(89, actual4, "Ожидается 89");
        }

        [TestMethod]
        public void Test_FibonacciCycle()
        {
            // Arrange
            int number1 = 1;
            int number2 = 3;
            int number3 = 5;
            int number4 = 11;

            // Act
            int actual1 = Program.FibonacciCycle(number1);
            int actual2 = Program.FibonacciCycle(number2);
            int actual3 = Program.FibonacciCycle(number3);
            int actual4 = Program.FibonacciCycle(number4);

            // Assert
            Assert.AreEqual(1, actual1, "Ожидается 1");
            Assert.AreEqual(2, actual2, "Ожидается 2");
            Assert.AreEqual(5, actual3, "Ожидается 5");
            Assert.AreEqual(89, actual4, "Ожидается 89");
        }
    }
}
