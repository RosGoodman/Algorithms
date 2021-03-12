
namespace Graphs.Graph
{
    public class Edge
    {
        /// <summary>Вес связи.</summary>
        public int Weight { get; set; }

        /// <summary>Узел, на который ссылается связь.</summary>
        public Node Node { get; set; }
    }
}
