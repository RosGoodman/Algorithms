using Graphs.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Graph_Tests
{
    [TestClass]
    public class Tests
    {
        #region AddItemsTests

        [TestMethod]
        public void AddItem_Matrix_Test()
        {
            //Arrange
            int[][] matrix = new int[5][];
            matrix[0] = new int[] { 1, 1, 0, 2, 3};
            matrix[1] = new int[] { 1, 0, 0, 0, 0};
            matrix[2] = new int[] { 0, 0, 0, 2, 2};
            matrix[3] = new int[] { 2, 0, 2, 0, 0};
            matrix[4] = new int[] { 3, 0, 2, 0, 0};

            GraphClass graph = new GraphClass();
            graph.AddItem(matrix);

            //Act
            Node node0 = graph.SearchBFS(0, 0);
            Node node1 = graph.SearchBFS(1, 0);
            Node node2 = graph.SearchBFS(2, 0);
            Node node3 = graph.SearchBFS(3, 0);
            Node node4 = graph.SearchBFS(4, 0);
            Edge edge0 = node0.Edges[0];
            Edge edge1 = node0.Edges[1];
            Edge edge2 = node0.Edges[2];
            Edge edge3 = node0.Edges[3];

            //Assert
            Assert.AreEqual(0, node0.Value);
            Assert.AreEqual(1, node1.Value);
            Assert.AreEqual(2, node2.Value);
            Assert.AreEqual(3, node3.Value);
            Assert.AreEqual(4, node4.Value);

            Assert.AreEqual(1, edge0.Weight);
            Assert.AreEqual(1, edge1.Weight);
            Assert.AreEqual(2, edge2.Weight);
            Assert.AreEqual(3, edge3.Weight);

            Assert.AreEqual(0, edge0.Node.Value);
            Assert.AreEqual(1, edge1.Node.Value);
            Assert.AreEqual(3, edge2.Node.Value);
            Assert.AreEqual(4, edge3.Node.Value);
        }

        [TestMethod]
        public void AddItem_Node_Test()
        {
            //Arrange
            int[][] matrix = new int[4][];
            matrix[0] = new int[] { 1, 1, 0, 2, 3 };
            matrix[1] = new int[] { 1, 0, 0, 0, 0 };
            matrix[2] = new int[] { 0, 0, 0, 2, 2 };
            matrix[3] = new int[] { 2, 0, 2, 0, 0 };
            //matrix[4] = new int[] { 3, 0, 2, 0, 0 };  //добавляемая нода

            GraphClass graph = new GraphClass();
            List<Edge> edges = new List<Edge>();
            graph.AddItem(matrix);

            //Act
            Edge edge0 = new Edge();
            Edge edge1 = new Edge();
            edge0.Weight = 3;
            edge1.Weight = 2;
            edge0.Node = graph.SearchBFS(0, 0);
            edge1.Node = graph.SearchBFS(2, 0);
            edges.Add(edge0);
            edges.Add(edge1);
            graph.AddItem(4, edges);

            Node newNode = graph.SearchBFS(4, 0);
            edge0 = newNode.Edges[0];
            edge1 = newNode.Edges[1];

            //Assert
            Assert.AreEqual(4, newNode.Value);
            Assert.AreEqual(2, newNode.Edges.Count);
            Assert.AreEqual(3, edge0.Weight);
            Assert.AreEqual(2, edge1.Weight);
            Assert.AreEqual(0, edge0.Node.Value);
            Assert.AreEqual(2, edge1.Node.Value);
        }

        #endregion

        #region SearchTests

        [TestMethod]
        public void SearchBFS_Test()
        {
            //Arrange
            int[][] matrix = new int[5][];
            matrix[0] = new int[] { 1, 1, 0, 2, 3 };
            matrix[1] = new int[] { 1, 0, 0, 0, 0 };
            matrix[2] = new int[] { 0, 0, 0, 2, 2 };
            matrix[3] = new int[] { 2, 0, 2, 0, 0 };
            matrix[4] = new int[] { 3, 0, 2, 0, 0 };

            GraphClass graph = new GraphClass();
            graph.AddItem(matrix);

            //Act
            Node node0 = graph.SearchBFS(0, 4);
            Node node1 = graph.SearchBFS(1, 3);
            Node node2 = graph.SearchBFS(2, 2);
            Node node3 = graph.SearchBFS(3, 1);
            Node node4 = graph.SearchBFS(4, 0);

            //Assert
            Assert.AreEqual(0, node0.Value);
            Assert.AreEqual(1, node1.Value);
            Assert.AreEqual(2, node2.Value);
            Assert.AreEqual(3, node3.Value);
            Assert.AreEqual(4, node4.Value);
        }

        [TestMethod]
        public void SearchBFS_NotFound_Test()
        {
            //Arrange
            int[][] matrix = new int[5][];
            matrix[0] = new int[] { 1, 1, 0, 2, 3 };
            matrix[1] = new int[] { 1, 0, 0, 0, 0 };
            matrix[2] = new int[] { 0, 0, 0, 2, 2 };
            matrix[3] = new int[] { 2, 0, 2, 0, 0 };
            matrix[4] = new int[] { 3, 0, 2, 0, 0 };

            GraphClass graph = new GraphClass();
            graph.AddItem(matrix);

            //Act
            Node node0 = graph.SearchBFS(8, 4);

            //Assert
            Assert.AreEqual(null, node0);
        }

        [TestMethod]
        public void SearchDFS_Test()
        {
            //Arrange
            int[][] matrix = new int[5][];
            matrix[0] = new int[] { 1, 1, 0, 2, 3 };
            matrix[1] = new int[] { 1, 0, 0, 0, 0 };
            matrix[2] = new int[] { 0, 0, 0, 2, 2 };
            matrix[3] = new int[] { 2, 0, 2, 0, 0 };
            matrix[4] = new int[] { 3, 0, 2, 0, 0 };

            GraphClass graph = new GraphClass();
            graph.AddItem(matrix);

            //Act
            Node node0 = graph.SearchDFS(0, 4);
            Node node1 = graph.SearchDFS(1, 3);
            Node node2 = graph.SearchDFS(2, 2);
            Node node3 = graph.SearchDFS(3, 1);
            Node node4 = graph.SearchDFS(4, 0);

            //Assert
            Assert.AreEqual(0, node0.Value);
            Assert.AreEqual(1, node1.Value);
            Assert.AreEqual(2, node2.Value);
            Assert.AreEqual(3, node3.Value);
            Assert.AreEqual(4, node4.Value);
        }

        [TestMethod]
        public void SearchDFS_NotFound_Test()
        {
            //Arrange
            int[][] matrix = new int[5][];
            matrix[0] = new int[] { 1, 1, 0, 2, 3 };
            matrix[1] = new int[] { 1, 0, 0, 0, 0 };
            matrix[2] = new int[] { 0, 0, 0, 2, 2 };
            matrix[3] = new int[] { 2, 0, 2, 0, 0 };
            matrix[4] = new int[] { 3, 0, 2, 0, 0 };

            GraphClass graph = new GraphClass();
            graph.AddItem(matrix);

            //Act
            Node node0 = graph.SearchDFS(8, 4);

            //Assert
            Assert.AreEqual(null, node0);
        }

        #endregion

        #region GetNodesListTests

        [TestMethod]
        public void GetNodesList_Test()
        {
            //Arrange
            int[][] matrix = new int[5][];
            matrix[0] = new int[] { 1, 1, 0, 2, 3 };
            matrix[1] = new int[] { 1, 0, 0, 0, 0 };
            matrix[2] = new int[] { 0, 0, 0, 2, 2 };
            matrix[3] = new int[] { 2, 0, 2, 0, 0 };
            matrix[4] = new int[] { 3, 0, 2, 0, 0 };

            GraphClass graph = new GraphClass();
            graph.AddItem(matrix);

            //Act
            List<Node> nodes = graph.GetNodesList();

            //Assert
            Assert.AreEqual(0, nodes[0].Value);
            Assert.AreEqual(1, nodes[1].Value);
            Assert.AreEqual(2, nodes[2].Value);
            Assert.AreEqual(3, nodes[3].Value);
            Assert.AreEqual(4, nodes[4].Value);
        }

        [TestMethod]
        public void GetNodesList_Empty_Test()
        {
            //Arrange
            GraphClass graph = new GraphClass();

            //Act
            List<Node> nodes = graph.GetNodesList();

            //Assert
            Assert.AreEqual(0, nodes.Count);
        }

        #endregion

        #region RemoveItemTests

        [TestMethod]
        public void RemoveItem_Test()
        {
            //Arrange
            int[][] matrix = new int[5][];
            matrix[0] = new int[] { 1, 1, 0, 2, 3 };
            matrix[1] = new int[] { 1, 0, 0, 0, 0 };
            matrix[2] = new int[] { 0, 0, 0, 2, 2 };
            matrix[3] = new int[] { 2, 0, 2, 0, 0 };
            matrix[4] = new int[] { 3, 0, 2, 0, 0 };

            GraphClass graph = new GraphClass();
            graph.AddItem(matrix);

            //Act
            graph.RemoveItem(4);
            Node removedNode = graph.SearchBFS(4, 0);
            Node node0 = graph.SearchBFS(0, 0);
            Node node1 = graph.SearchBFS(2, 0);
            List<Node> nodes = graph.GetNodesList();

            //Assert
            Assert.AreEqual(null, removedNode);
            Assert.AreEqual(3, node0.Edges.Count);
            Assert.AreEqual(1, node1.Edges.Count);
            Assert.AreEqual(4, nodes.Count);
        }

        [TestMethod]
        public void RemoveItem_NoItem_Test()
        {
            //Arrange
            int[][] matrix = new int[5][];
            matrix[0] = new int[] { 1, 1, 0, 2, 3 };
            matrix[1] = new int[] { 1, 0, 0, 0, 0 };
            matrix[2] = new int[] { 0, 0, 0, 2, 2 };
            matrix[3] = new int[] { 2, 0, 2, 0, 0 };
            matrix[4] = new int[] { 3, 0, 2, 0, 0 };

            GraphClass graph = new GraphClass();
            graph.AddItem(matrix);

            //Act
            graph.RemoveItem(9);
            List<Node> nodes = graph.GetNodesList();
            Node node0 = graph.SearchBFS(0, 0);
            Node node1 = graph.SearchBFS(1, 0);
            Node node2 = graph.SearchBFS(2, 0);
            Node node3 = graph.SearchBFS(3, 0);
            Node node4 = graph.SearchBFS(4, 0);

            //Assert
            Assert.AreEqual(5, nodes.Count);
            Assert.AreEqual(4, node0.Edges.Count);
            Assert.AreEqual(1, node1.Edges.Count);
            Assert.AreEqual(2, node2.Edges.Count);
            Assert.AreEqual(2, node3.Edges.Count);
            Assert.AreEqual(2, node4.Edges.Count);
        }

        #endregion
    }
}