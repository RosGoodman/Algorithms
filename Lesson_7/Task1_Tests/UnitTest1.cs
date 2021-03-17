using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1;

namespace Task1_Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void GetRout_noBlocks_Test()
        {
            //Arrange
            int n = 4;
            int m = 4;
            string[,] map = new string[n, m];
            string[,] standardMap = { { "1", "1", "1", "1"} ,
                                      { "1","2","3","4"},
                                      { "1","3","6","10"},
                                      { "1","4","10","20"} };
            Rout rout = new Rout();

            //Act
            int routsCount = rout.GetRoutCount(map);
            bool equals = true;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] != standardMap[i, j])
                        equals = false;
                    break;
                }
                if (!equals)
                    break;
            }

            //Assert
            Assert.AreEqual(true, equals);
            Assert.AreEqual("20", map[map.GetLength(0) - 1, map.GetLength(1) - 1]);
        }

        [TestMethod]
        public void GetRout_withBlocks_Test()
        {
            //Arrange
            int n = 4;
            int m = 4;
            
            string[,] map = new string[n, m];
            map[0, 1] = "X";
            map[2, 2] = "X";
            map[3, 0] = "X";

            string[,] standardMap = { { "1", "X", "", ""} ,
                                      { "1","1","1","1"},
                                      { "1","2","X","1"},
                                      { "X","2","2","3"} };
            Rout rout = new Rout();

            //Act
            int routsCount = rout.GetRoutCount(map);
            bool equals = true;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] != standardMap[i, j])
                        equals = false;
                    break;
                }
                if (!equals)
                    break;
            }

            //Assert
            Assert.AreEqual(true, equals);
            Assert.AreEqual("3", map[map.GetLength(0) - 1, map.GetLength(1) - 1]);
        }
    }
}