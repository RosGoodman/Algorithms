using System;
using System.Collections.Generic;

namespace Graphs.Graph
{
    class Graph : IGraph
    {
        private List<Node> _nodesList;

        /// <summary>Добавить ноду.</summary>
        /// <param name="value">Значение ноды.</param>
        /// <param name="edges">Связи с другими нодами.</param>
        public void AddItem(int value, List<Edge> edges)
        {
            Node newNode = new Node(value, edges);
            _nodesList.Add(newNode);

            //добавление связей к новой ноде
            for (int i = 0; i < edges.Count; i++)
            {
                for (int j = 0; j < _nodesList.Count; j++)
                {
                    if(edges[i].Node.Value == _nodesList[j].Value)
                    {
                        Edge edge = new Edge();
                        edge.Node = newNode;
                        edge.Weight = edges[i].Weight;
                        _nodesList[j].Edges.Add(edge);
                    }
                }
            }
        }

        /// <summary>Добавить множество нод с помощью матрицы связей.</summary>
        /// <param name="graphMatrix">Матрица связей, где первая вертикаль и горизонталь - значения нод.</param>
        public void AddItem(int[,] graphMatrix)
        {
            int nodeValue;
            Node refNode;
            Edge edge;
            List<Edge> edges = new List<Edge>();

            for (int i = 0; i < graphMatrix.GetLength(0); i++)
            {
                nodeValue = graphMatrix[i, 0];

                for (int j = 1; j < graphMatrix.GetLength(1); j++)
                {
                    edge = new Edge();
                    refNode = new Node();
                    refNode.Value = graphMatrix[0, j];
                    edge.Node = refNode;
                    edge.Weight = graphMatrix[i, j];

                    edges.Add(edge);
                }

                AddItem(nodeValue, edges);
            }
        }

        /// <summary>Найти ноду по значению.</summary>
        /// <param name="value">Искомое значение.</param>
        /// <returns>Найденная нода.</returns>
        public Node GetNodeByValue(int value)
        {
            Node node = SearchBFS(value);
            return node;
        }

        /// <summary>Поиск в ширину (BFS).</summary>
        /// <param name="value">Значение искомой ноды.</param>
        /// <returns>Найденная нода или null.</returns>
        private Node SearchBFS(int value)
        {
            if (_nodesList.Count == 0) return null;

            //очередь сделана через лист, чтобы не делать отдельный массив для проверенных нод
            List <Node> checkList = new List<Node>();
            int index = 0;
            Node node = _nodesList[0];
            checkList.Add(node);

            do
            {
                
            } while (index <= checkList.Count);

            return node;
        }

        /// <summary>Получить список нод.</summary>
        /// <returns>Список нод.</returns>
        public List<Node> GetNodesList()
        {
            return _nodesList;
        }

        /// <summary>Вывести матрицу связей.</summary>
        public void PrintGraphMatrix()
        {
            int[,] graphMatrix = new int[_nodesList.Count+1, _nodesList.Count+1];
            for (int i = 0; i < _nodesList.Count; i++)
            {
                graphMatrix[i + 1, i + 1] = _nodesList[i].Value;
            }
        }

        /// <summary>Удалить ноду.</summary>
        /// <param name="value">Значение удаляемой ноды.</param>
        public void RemoveItem(int value)
        {
            throw new NotImplementedException();
        }
    }
}
