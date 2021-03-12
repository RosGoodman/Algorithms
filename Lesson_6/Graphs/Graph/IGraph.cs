using System.Collections.Generic;

namespace Graphs.Graph
{
    public interface IGraph
    {
        List<Node> GetNodesList();
        void AddItem(int value, List<Edge> edges); // добавить узел
        void AddItem(int[,] graphMatrix); //добавить множество узлов с помощью матрицы связей
        void RemoveItem(int value); // удалить узел по значению
        Node GetNodeByValue(int value); //получить узел дерева по значению
        void PrintGraphMatrix(); //вывести матрицу в консоль
    }
}
