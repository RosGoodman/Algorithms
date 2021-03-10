using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2;
using Task_2.Tree;

namespace Task2_UnitTest
{
    [TestClass]
    public class Tests
    {
        #region leafTree

        [TestMethod]
        public void Test_RemoveItem_LeftLeafInLeftBranch()
        {
            //Arrange
            Generator generator = new Generator();
            int[] array = new int[] { 55, 24, 15, 18, 10, 36, 30, 31, 26, 28, 41, 39, 38, 48, 84, 95, 61, 58, 64, 63, 90, 96, 97 };
            TreeClass tree = new TreeClass();

            //Act
            for (int i = 0; i < array.Length; i++)
            {
                tree.AddItem(array[i]);
            }
            tree.RemoveItem(10);

            TreeNode parentNode = tree.GetNodeByValue(15);

            //Assert
            Assert.AreEqual(24, parentNode.ParentNode.Value);
            Assert.AreEqual(null, parentNode.LeftChild);
            Assert.AreEqual(18, parentNode.RightChild.Value);
        }

        [TestMethod]
        public void Test_RemoveItem_RightLeafInLeftBranch()
        {
            //Arrange
            Generator generator = new Generator();
            int[] array = new int[] { 55, 24, 15, 18, 10, 36, 30, 31, 26, 28, 41, 39, 38, 48, 84, 95, 61, 58, 64, 63, 90, 96, 97 };
            TreeClass tree = new TreeClass();

            //Act
            for (int i = 0; i < array.Length; i++)
            {
                tree.AddItem(array[i]);
            }
            tree.RemoveItem(18);

            TreeNode parentNode = tree.GetNodeByValue(15);

            //Assert
            Assert.AreEqual(24, parentNode.ParentNode.Value);
            Assert.AreEqual(10, parentNode.LeftChild.Value);
            Assert.AreEqual(null, parentNode.RightChild);
        }

        [TestMethod]
        public void Test_RemoveItem_LeftLeafInRightBranch()
        {
            //Arrange
            Generator generator = new Generator();
            int[] array = new int[] { 55, 24, 15, 18, 10, 36, 30, 31, 26, 28, 41, 39, 38, 48, 84, 95, 61, 58, 64, 63, 90, 96, 97 };
            TreeClass tree = new TreeClass();

            //Act
            for (int i = 0; i < array.Length; i++)
            {
                tree.AddItem(array[i]);
            }
            tree.RemoveItem(58);

            TreeNode parentNode = tree.GetNodeByValue(61);

            //Assert
            Assert.AreEqual(84, parentNode.ParentNode.Value);
            Assert.AreEqual(null, parentNode.LeftChild);
            Assert.AreEqual(64, parentNode.RightChild.Value);
        }

        [TestMethod]
        public void Test_RemoveItem_RightLeafInRightBranch()
        {
            //Arrange
            Generator generator = new Generator();
            int[] array = new int[] { 55, 24, 15, 18, 10, 36, 30, 31, 26, 28, 41, 39, 38, 48, 84, 95, 61, 58, 64, 63, 90, 96, 97 };
            TreeClass tree = new TreeClass();

            //Act
            for (int i = 0; i < array.Length; i++)
            {
                tree.AddItem(array[i]);
            }
            tree.RemoveItem(97);

            TreeNode parentNode = tree.GetNodeByValue(96);

            //Assert
            Assert.AreEqual(95, parentNode.ParentNode.Value);
            Assert.AreEqual(null, parentNode.LeftChild);
            Assert.AreEqual(null, parentNode.RightChild);
        }

        #endregion

        [TestMethod]
        public void Test_RemoveItem_LeftKnotInLeftBranch()
        {
            //Arrange
            Generator generator = new Generator();
            int[] array = new int[] { 55, 24, 15, 18, 10, 36, 30, 31, 26, 28, 41, 39, 38, 48, 84, 95, 61, 58, 64, 63, 90, 96, 97 };
            TreeClass tree = new TreeClass();

            //Act
            for (int i = 0; i < array.Length; i++)
            {
                tree.AddItem(array[i]);
            }
            tree.RemoveItem(15);

            TreeNode parentNode = tree.GetNodeByValue(24);
            TreeNode replaceNode = tree.GetNodeByValue(18);
            TreeNode leftNode = tree.GetNodeByValue(10);

            //Assert
            Assert.AreEqual(18, parentNode.LeftChild.Value);
            Assert.AreEqual(24, replaceNode.ParentNode.Value);
            Assert.AreEqual(10, replaceNode.LeftChild.Value);
            Assert.AreEqual(null, replaceNode.RightChild);
            Assert.AreEqual(18, leftNode.ParentNode.Value);
        }

        [TestMethod]
        public void Test_RemoveItem_RightKnotInLeftBranch()
        {
            //Arrange
            Generator generator = new Generator();
            int[] array = new int[] { 55, 24, 15, 18, 10, 36, 30, 31, 26, 28, 41, 39, 38, 48, 84, 95, 61, 58, 64, 63, 90, 96, 97 };
            TreeClass tree = new TreeClass();

            //Act
            for (int i = 0; i < array.Length; i++)
            {
                tree.AddItem(array[i]);
            }
            tree.RemoveItem(36);

            TreeNode parentNode = tree.GetNodeByValue(24);
            TreeNode replaceNode = tree.GetNodeByValue(38);
            TreeNode leftNode = tree.GetNodeByValue(30);
            TreeNode rightNode = tree.GetNodeByValue(41);

            //Assert
            Assert.AreEqual(38, parentNode.RightChild.Value);

            Assert.AreEqual(24, replaceNode.ParentNode.Value);
            Assert.AreEqual(30, replaceNode.LeftChild.Value);
            Assert.AreEqual(41, replaceNode.RightChild.Value);

            Assert.AreEqual(38, leftNode.ParentNode.Value);
            Assert.AreEqual(38, rightNode.ParentNode.Value);
        }

        [TestMethod]
        public void Test_RemoveItem_LeftKnotInRightBranch()
        {
            //Arrange
            Generator generator = new Generator();
            int[] array = new int[] { 55, 24, 15, 18, 10, 36, 30, 31, 26, 28, 41, 39, 38, 48, 84, 95, 61, 58, 64, 63, 90, 96, 97 };
            TreeClass tree = new TreeClass();

            //Act
            for (int i = 0; i < array.Length; i++)
            {
                tree.AddItem(array[i]);
            }
            tree.RemoveItem(61);

            TreeNode parentNode = tree.GetNodeByValue(84);
            TreeNode replaceNode = tree.GetNodeByValue(63);
            TreeNode leftNode = tree.GetNodeByValue(58);
            TreeNode rightNode = tree.GetNodeByValue(64);

            //Assert
            Assert.AreEqual(63, parentNode.LeftChild.Value);

            Assert.AreEqual(84, replaceNode.ParentNode.Value);
            Assert.AreEqual(58, replaceNode.LeftChild.Value);
            Assert.AreEqual(64, replaceNode.RightChild.Value);

            Assert.AreEqual(63, leftNode.ParentNode.Value);
            Assert.AreEqual(63, rightNode.ParentNode.Value);
            Assert.AreEqual(null, rightNode.LeftChild);
        }

        [TestMethod]
        public void Test_RemoveItem_RightKnotInRightBranch()
        {
            //Arrange
            Generator generator = new Generator();
            int[] array = new int[] { 55, 24, 15, 18, 10, 36, 30, 31, 26, 28, 41, 39, 38, 48, 84, 95, 61, 58, 64, 63, 90, 96, 97 };
            TreeClass tree = new TreeClass();

            //Act
            for (int i = 0; i < array.Length; i++)
            {
                tree.AddItem(array[i]);
            }
            tree.RemoveItem(95);

            TreeNode parentNode = tree.GetNodeByValue(84);
            TreeNode replaceNode = tree.GetNodeByValue(96);
            TreeNode leftNode = tree.GetNodeByValue(90);
            TreeNode rightNode = tree.GetNodeByValue(97);

            //Assert
            Assert.AreEqual(96, parentNode.RightChild.Value);

            Assert.AreEqual(84, replaceNode.ParentNode.Value);
            Assert.AreEqual(90, replaceNode.LeftChild.Value);
            Assert.AreEqual(97, replaceNode.RightChild.Value);

            Assert.AreEqual(96, leftNode.ParentNode.Value);
            Assert.AreEqual(96, rightNode.ParentNode.Value);
        }
    }
}