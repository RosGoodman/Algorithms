using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1.Search_BFS_DFS;
using Task_2.Tree;

namespace Task1_Searchs_UnitTesst
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Test_SearchBFS_Found()
        {
            //Arrange
            int[] array = new int[] { 55, 24, 15, 18, 10, 36, 30, 31, 26, 28, 41, 39, 38, 48, 84, 95, 61, 58, 64, 63, 90, 96, 97 };
            int searchValue1 = 55; 
            int searchValue2 = 41;
            int searchValue3 = 97;
            TreeClass tree = new TreeClass();
            Searchs searchs = new Searchs();

            //Act
            for (int i = 0; i < array.Length; i++)
            {
                tree.AddItem(array[i]);
            }
            

            TreeNode searchNode1 = searchs.SearchBFS(tree.GetRoot(), searchValue1);
            TreeNode searchNode2 = searchs.SearchBFS(tree.GetRoot(), searchValue2);
            TreeNode searchNode3 = searchs.SearchBFS(tree.GetRoot(), searchValue3);

            //Assert
            Assert.AreEqual(55, searchNode1.Value);
            Assert.AreEqual(41, searchNode2.Value);
            Assert.AreEqual(97, searchNode3.Value);
        }

        [TestMethod]
        public void Test_SearchBFS_NotFound()
        {
            //Arrange
            int[] array = new int[] { 55, 24, 15, 18, 10, 36, 30, 31, 26, 28, 41, 39, 38, 48, 84, 95, 61, 58, 64, 63, 90, 96, 97 };
            int searchValue1 = 25;
            int searchValue2 = -5;
            int searchValue3 = 115;
            TreeClass tree = new TreeClass();
            Searchs searchs = new Searchs();

            //Act
            for (int i = 0; i < array.Length; i++)
            {
                tree.AddItem(array[i]);
            }

            TreeNode searchNode1 = searchs.SearchBFS(tree.GetRoot(), searchValue1);
            TreeNode searchNode2 = searchs.SearchBFS(tree.GetRoot(), searchValue2);
            TreeNode searchNode3 = searchs.SearchBFS(tree.GetRoot(), searchValue3);

            //Assert
            Assert.AreEqual(null, searchNode1);
            Assert.AreEqual(null, searchNode2);
            Assert.AreEqual(null, searchNode3);
        }

        [TestMethod]
        public void Test_SearchDFS_NotFound()
        {
            //Arrange
            int[] array = new int[] { 55, 24, 15, 18, 10, 36, 30, 31, 26, 28, 41, 39, 38, 48, 84, 95, 61, 58, 64, 63, 90, 96, 97 };
            int searchValue1 = 25;
            int searchValue2 = -5;
            int searchValue3 = 115;
            TreeClass tree = new TreeClass();
            Searchs searchs = new Searchs();

            //Act
            for (int i = 0; i < array.Length; i++)
            {
                tree.AddItem(array[i]);
            }

            TreeNode searchNode1 = searchs.SearchBFS(tree.GetRoot(), searchValue1);
            TreeNode searchNode2 = searchs.SearchBFS(tree.GetRoot(), searchValue2);
            TreeNode searchNode3 = searchs.SearchBFS(tree.GetRoot(), searchValue3);

            //Assert
            Assert.AreEqual(null, searchNode1);
            Assert.AreEqual(null, searchNode2);
            Assert.AreEqual(null, searchNode3);
        }

        [TestMethod]
        public void Test_SearchDFS_Found()
        {
            //Arrange
            int[] array = new int[] { 55, 24, 15, 18, 10, 36, 30, 31, 26, 28, 41, 39, 38, 48, 84, 95, 61, 58, 64, 63, 90, 96, 97 };
            int searchValue1 = 55;
            int searchValue2 = 26;
            int searchValue3 = 97;
            TreeClass tree = new TreeClass();
            Searchs searchs = new Searchs();

            //Act
            for (int i = 0; i < array.Length; i++)
            {
                tree.AddItem(array[i]);
            }

            TreeNode searchNode1 = searchs.SearchBFS(tree.GetRoot(), searchValue1);
            TreeNode searchNode2 = searchs.SearchBFS(tree.GetRoot(), searchValue2);
            TreeNode searchNode3 = searchs.SearchBFS(tree.GetRoot(), searchValue3);

            //Assert
            Assert.AreEqual(55, searchNode1.Value);
            Assert.AreEqual(26, searchNode2.Value);
            Assert.AreEqual(97, searchNode3.Value);
        }
    }
}