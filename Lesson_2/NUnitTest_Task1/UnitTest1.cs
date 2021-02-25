using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1;

namespace NUnitTest_Task1
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void AddNode_FirstAndSecNodes()
        {
            //Arrange
            int val1 = 1;
            int val2 = 2;
            int val3 = 3;
            Node node1 = new Node(val1, null, null);
            Node node2 = new Node(val2, null, node1);
            Node node3 = new Node(val3, null, node2);
            node1.NextNode = node2;
            node2.NextNode = node3;

            //Act
            Nodes nodes = new Nodes();
            nodes.AddNode(val1);
            nodes.AddNode(val2);
            nodes.AddNode(val3);
            Node actNode1 = nodes.FindNode(1);
            Node actNode2 = nodes.FindNode(2);
            Node actNode3 = nodes.FindNode(3);

            //Assert
            Assert.AreEqual(node1, actNode1, "ошибка в первой ноде");
            Assert.AreEqual(node2, actNode2, "ошибка в первой ноде");
            Assert.AreEqual(node3, actNode3, "ошибка в первой ноде");
        }
    }
}