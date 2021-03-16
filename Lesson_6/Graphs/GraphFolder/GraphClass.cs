using System;
using System.Collections.Generic;

namespace Graphs.Graph
{
    public class GraphClass : IGraph
    {
        private List<Node> _nodesList = new List<Node>();

        /// <summary>Добавить ноду.</summary>
        /// <param name="value">Значение ноды.</param>
        /// <param name="edges">Связи с другими нодами.</param>
        public void AddItem(int value, List<Edge> edges)
        {
            Node newNode = new Node(value, edges);
            Edge edge;
            _nodesList.Add(newNode);

            //добавление связей К новой ноде
            for (int i = 0; i < edges.Count; i++)   //перечисление связей от ноды
            {
                for (int j = 0; j < _nodesList.Count; j++)  //перечисление существующих нод
                {
                    edge = new Edge();
                    edge.Node = newNode;
                    edge.Weight = edges[i].Weight;
                    //нода есть в списке, не петля, в ноде еще не записана связь
                    if (edges[i].Node.Value == _nodesList[j].Value)// && _nodesList[j] != newNode && !_nodesList[i].Edges.Contains(edge))
                    {
                        if(_nodesList[j] != newNode)
                            if(!_nodesList[i].Edges.Contains(edge))
                                _nodesList[j].Edges.Add(edge);
                    }
                }
            }
        }

        /// <summary>Добавить множество нод с помощью матрицы связей.</summary>
        /// <param name="graphMatrix">Матрица связей.</param>
        public void AddItem(int[][] graphMatrix)
        {
            Node refNode;
            Edge edge;
            List<Edge> edges;

            //добавляем все новые ноды в общий список
            for (int i = 0; i < graphMatrix.GetLength(0); i++)
            {
                if (_nodesList.Count == 0)
                {
                    Node node = new Node();
                    node.Value = i;
                    _nodesList.Add(node);
                    continue;
                }

                for (int j = 0; j <= _nodesList.Count-1; j++)
                {
                    if (_nodesList[j].Value == i)
                        break;

                    if (j == _nodesList.Count-1)
                    {
                        Node node = new Node();
                        node.Value = i;
                        _nodesList.Add(node);
                        break;
                    }
                }
            }

            //запись свзязей
            foreach(Node n in _nodesList)
            {
                edges = new List<Edge>();
                for (int i = 0; i < graphMatrix.GetLength(0); i++)
                {
                    if(graphMatrix[n.Value][i] != 0)
                    {
                        edge = new Edge();
                        edge.Weight = graphMatrix[n.Value][i];
                        foreach(Node n1 in _nodesList)
                        {
                            if (n1.Value == i)
                                edge.Node = n1;
                        }
                        edges.Add(edge);
                    }
                }
                n.Edges = edges;
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
            Node node;

            do
            {
                node = checkList[index];
                if (node.Value == value)
                {
                    FoundNode(node, "BFS");
                    break;
                }

                foreach(Edge edge in node.Edges)
                {
                    if(!checkList.Contains(edge.Node))
                        checkList.Add(edge.Node);
                }
            } while (index <= checkList.Count);

            return node;
        }

        /// <summary>Вывести результаты.</summary>
        /// <param name="node">Найденная нода или null.</param>
        /// <param name="searchType">Тип поиска.</param>
        private void FoundNode(Node node, string searchType)
        {
            if (node == null)
                Console.WriteLine("{0}: Узел с таким значение не найден.");
            else
                Console.WriteLine("{0}: {1}", searchType, node.Value);
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
            int[,] graphMatrix = new int[_nodesList.Count + 1, _nodesList.Count + 1];

            //Values
            for (int i = 0; i < _nodesList.Count; i++)
            {
                graphMatrix[i+1, 0] = _nodesList[i].Value;
                graphMatrix[0, i+1] = _nodesList[i].Value;
            }
            //Weight
            Node node;
            for (int i = 0; i < _nodesList.Count-1; i++)  //ноды, для которой прописываются связи
            {
                if (_nodesList[i].Edges.Count == 0)
                    continue;
                foreach(Edge e in _nodesList[i].Edges)
                {
                    graphMatrix[i + 1, e.Node.Value + 1] = e.Weight;
                    graphMatrix[e.Node.Value + 1, i + 1] = e.Weight;
                }
            }

            for (int i = 0; i < graphMatrix.GetLength(0); i++)
            {
                string printStr = string.Empty;
                for (int j = 0; j < graphMatrix.GetLength(1); j++)
                {
                    printStr += graphMatrix[i, j] + "  ";
                }
                Console.WriteLine(printStr);
            }
            
        }

        /// <summary>Удалить ноду.</summary>
        /// <param name="value">Значение удаляемой ноды.</param>
        public void RemoveItem(int value)
        {
            Node node = SearchBFS(value);
            if (node != null)
            {
                foreach(Edge edge in node.Edges)
                {
                    Node refNode = edge.Node;
                    foreach(Edge edge1 in refNode.Edges)
                    {
                        if (edge1.Node == node)
                        {
                            refNode.Edges.Remove(edge1);
                            break;
                        }
                            
                    }
                }
            }
        }
    }
}
