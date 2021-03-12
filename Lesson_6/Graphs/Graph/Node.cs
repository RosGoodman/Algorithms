using System.Collections.Generic;

namespace Graphs.Graph
{
    public class Node
    {
        /// <summary>Значение ноды.</summary>
        public int Value { get; set; }

        /// <summary>Исходящие связи.</summary>
        public List<Edge> Edges { get; set; }
    }
}
