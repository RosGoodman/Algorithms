using System.Collections.Generic;

namespace Graphs.Graph
{
    public class Node
    {
        public Node()
        {

        }

        public Node(int value, List<Edge> edges)
        {
            Value = value;
            Edges = edges;
        }
        /// <summary>Значение ноды.</summary>
        public int Value { get; set; }

        /// <summary>Исходящие связи.</summary>
        public List<Edge> Edges { get; set; }
    }
}
