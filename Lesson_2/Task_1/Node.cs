
namespace Task_1
{
    class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }

        public Node(int value, Node nextNode, Node prevNode)
        {
            Value = value;
            NextNode = nextNode;
            PrevNode = prevNode;
        }
    }
}
