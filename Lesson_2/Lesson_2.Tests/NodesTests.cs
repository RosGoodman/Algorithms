using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1;

namespace Lesson_2.Tests
{
    [TestClass]
    public class NodesTests
    {
        #region AddNodeTests

        [TestMethod]
        public void AddNode_EmptyList_Test()
        {
            //Arrange
            int val1 = 1;

            //Act
            Nodes nodes = new Nodes();
            nodes.AddNode(val1);
            Node actNode1 = nodes.GetNodeByIndex(0);

            //Assert
            Assert.AreEqual(1, actNode1.Value, "��������� 1");
            Assert.AreEqual(null, actNode1.PrevNode, "��������� null");
            Assert.AreEqual(null, actNode1.NextNode, "��������� null");
        }

        [TestMethod]
        public void AddNode_EndList_Test()
        {
            //Arrange
            int val1 = 1;
            int val2 = 2;
            int val3 = 3;
            Nodes nodes = new Nodes();
            nodes.AddNode(val1);
            nodes.AddNode(val2);

            //Act
            nodes.AddNode(val3);
            Node actNode3 = nodes.GetNodeByIndex(2);
            Node actNode2 = nodes.GetNodeByIndex(1);

            //Assert
            Assert.AreEqual(3, actNode3.Value, "��������� 3");
            Assert.AreEqual(actNode2, actNode3.PrevNode, "��������� ������ �� ������ ����");
            Assert.AreEqual(null, actNode3.NextNode, "��������� null");
        }

        #endregion

        #region AddNodeAfterTests

        [TestMethod]
        public void AddNodeAfter_MidlleList_Test()
        {
            //Arrange
            int val1 = 1;
            int val2 = 2;
            int val3 = 3;
            Nodes nodes = new Nodes();
            nodes.AddNode(val1);
            nodes.AddNode(val2);

            //Act
            Node prevNode = nodes.GetNodeByIndex(0);
            Node nextNode = nodes.GetNodeByIndex(2);
            nodes.AddNodeAfter(prevNode, val3);
            Node actNode3 = nodes.GetNodeByIndex(1);

            //Assert
            Assert.AreEqual(3, actNode3.Value, "��������� 3");
            Assert.AreEqual(prevNode, actNode3.PrevNode, "��������� ������ �� prevNode");
            Assert.AreEqual(nextNode, actNode3.NextNode, "��������� ������ �� nextNode");
        }

        [TestMethod]
        public void AddNodeAfter_EndList_Test()
        {
            //Arrange
            int val1 = 1;
            int val2 = 2;
            int val3 = 3;
            Nodes nodes = new Nodes();
            nodes.AddNode(val1);
            nodes.AddNode(val2);

            //Act
            Node prevNode = nodes.GetNodeByIndex(1);
            nodes.AddNodeAfter(prevNode, val3);
            Node actNode3 = nodes.GetNodeByIndex(2);

            //Assert
            Assert.AreEqual(3, actNode3.Value, "��������� 3");
            Assert.AreEqual(prevNode, actNode3.PrevNode, "��������� ������ �� prevNode");
            Assert.AreEqual(null, actNode3.NextNode, "��������� null");
        }

        #endregion

        #region FindNodeTests

        [TestMethod]
        public void FindNode_EmptyleList_Test()
        {
            //Arrange
            Nodes nodes = new Nodes();

            //Act
            Node fNode = nodes.FindNode(2);

            //Assert
            Assert.AreEqual(null, fNode, "��������� null");
        }

        [TestMethod]
        public void FindNode_NodeInTheList_Test()
        {
            //Arrange
            int val1 = 1;
            int val2 = 2;
            int val3 = 3;
            Nodes nodes = new Nodes();
            nodes.AddNode(val1);
            nodes.AddNode(val2);
            nodes.AddNode(val3);

            //Act
            Node prevNode = nodes.FindNode(2);
            Node fNode = nodes.FindNode(3);

            //Assert
            Assert.AreEqual(3, fNode.Value, "��������� 3");
            Assert.AreEqual(prevNode, fNode.PrevNode, "��������� ������ �� prevNode");
            Assert.AreEqual(null, fNode.NextNode, "��������� null");
        }

        [TestMethod]
        public void FindNode_IsNotInTheList_Test()
        {
            //Arrange
            int val1 = 1;
            int val2 = 2;
            int val3 = 3;
            Nodes nodes = new Nodes();
            nodes.AddNode(val1);
            nodes.AddNode(val2);
            nodes.AddNode(val3);

            //Act
            Node fNode = nodes.FindNode(5);

            //Assert
            Assert.AreEqual(null, fNode, "��������� null");
        }

        #endregion

        #region GetCountTests

        [TestMethod]
        public void GetCount_EmptyleList_Test()
        {
            //Arrange
            Nodes nodes = new Nodes();

            //Act
            int count = nodes.GetCount();

            //Assert
            Assert.AreEqual(0, count, "��������� 0");
        }

        [TestMethod]
        public void FindNode_CompliteList_Test()
        {
            //Arrange
            int val1 = 1;
            int val2 = 2;
            int val3 = 3;
            Nodes nodes = new Nodes();
            nodes.AddNode(val1);
            nodes.AddNode(val2);
            nodes.AddNode(val3);

            //Act
            int count = nodes.GetCount();

            //Assert
            Assert.AreEqual(3, count, "��������� 3");
        }

        #endregion

        #region RemoveNodeByIndexTests

        [TestMethod]
        public void RemoveNode_EmptyleList_Test()
        {
            //Arrange
            Nodes nodes = new Nodes();

            //Act
            nodes.RemoveNode(2);
        }

        [TestMethod]
        public void RemoveNode_Exceeding_Test()
        {
            //Arrange
            int val1 = 1;
            int val2 = 2;
            int val3 = 3;
            Nodes nodes = new Nodes();
            nodes.AddNode(val1);
            nodes.AddNode(val2);
            nodes.AddNode(val3);

            //Act
            nodes.RemoveNode(4);
            Node node1 = nodes.FindNode(1);
            Node node2 = nodes.FindNode(2);
            Node node3 = nodes.FindNode(3);

            //Assert
            Assert.AreEqual(1, node1.Value, "��������� 1");
            Assert.AreEqual(2, node2.Value, "��������� 2");
            Assert.AreEqual(3, node3.Value, "��������� 3");
        }

        [TestMethod]
        public void RemoveNode_RemovingFirstNode_Test()
        {
            //Arrange
            int val1 = 1;
            int val2 = 2;
            int val3 = 3;
            Nodes nodes = new Nodes();
            nodes.AddNode(val1);
            nodes.AddNode(val2);
            nodes.AddNode(val3);

            //Act
            nodes.RemoveNode(0);
            Node node1 = nodes.GetNodeByIndex(0);
            Node node2 = nodes.GetNodeByIndex(1);

            //Assert
            Assert.AreEqual(2, node1.Value, "��������� 2");
            Assert.AreEqual(null, node1.PrevNode, "��������� null");
            Assert.AreEqual(node2, node1.NextNode, "��������� ������ �� node2");

            Assert.AreEqual(3, node2.Value, "��������� 3");
            Assert.AreEqual(node1, node2.PrevNode, "��������� ������ �� node1");
            Assert.AreEqual(null, node2.NextNode, "��������� null");

        }

        [TestMethod]
        public void RemoveNode_RemovingMiddleNode_Test()
        {
            //Arrange
            int val1 = 1;
            int val2 = 2;
            int val3 = 3;
            Nodes nodes = new Nodes();
            nodes.AddNode(val1);
            nodes.AddNode(val2);
            nodes.AddNode(val3);

            //Act
            nodes.RemoveNode(1);
            Node node1 = nodes.GetNodeByIndex(0);
            Node node2 = nodes.GetNodeByIndex(1);

            //Assert
            Assert.AreEqual(1, node1.Value, "��������� 1");
            Assert.AreEqual(null, node1.PrevNode, "��������� null");
            Assert.AreEqual(node2, node1.NextNode, "��������� ������ �� node2");

            Assert.AreEqual(3, node2.Value, "��������� 3");
            Assert.AreEqual(node1, node2.PrevNode, "��������� ������ �� node1");
            Assert.AreEqual(null, node2.NextNode, "��������� null");
        }

        [TestMethod]
        public void RemoveNode_RemovingLastNode_Test()
        {
            //Arrange
            int val1 = 1;
            int val2 = 2;
            int val3 = 3;
            Nodes nodes = new Nodes();
            nodes.AddNode(val1);
            nodes.AddNode(val2);
            nodes.AddNode(val3);

            //Act
            nodes.RemoveNode(2);
            Node node1 = nodes.GetNodeByIndex(0);
            Node node2 = nodes.GetNodeByIndex(1);

            //Assert
            Assert.AreEqual(1, node1.Value, "��������� 1");
            Assert.AreEqual(null, node1.PrevNode, "��������� null");
            Assert.AreEqual(node2, node1.NextNode, "��������� ������ �� node2");

            Assert.AreEqual(2, node2.Value, "��������� 2");
            Assert.AreEqual(node1, node2.PrevNode, "��������� ������ �� node1");
            Assert.AreEqual(null, node2.NextNode, "��������� null");
        }

        #endregion

        #region RemoveNodeByNodeTests

        //����������� ������ ����� �� ����� ������
        //�.�. ��� ���������� ����� �������� �� �������

        #endregion
    }
}