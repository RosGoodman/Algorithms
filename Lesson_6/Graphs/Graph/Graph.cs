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
        public void AddItem(int value, Edge edges)
        {
            throw new NotImplementedException();
        }

        /// <summary>Добавить множество нод с помощью матрицы связей.</summary>
        /// <param name="graphMatrix">Матрица связей, где первая вертикаль и горизонталь - значения нод.</param>
        public void AddItem(int[,] graphMatrix)
        {
            throw new NotImplementedException();
        }

        /// <summary>Найти ноду по значению.</summary>
        /// <param name="value">Искомое значение.</param>
        /// <returns>Найденная нода.</returns>
        public Node GetNodeByValue(int value)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>Удалить ноду.</summary>
        /// <param name="value">Значение удаляемой ноды.</param>
        public void RemoveItem(int value)
        {
            throw new NotImplementedException();
        }
    }
}
