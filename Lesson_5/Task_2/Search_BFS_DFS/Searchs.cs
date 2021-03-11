using System.Collections.Generic;
using Task_2.Tree;

namespace Task_1.Search_BFS_DFS
{
    public class Searchs
    {
        /// <summary>Найти значение в дереве.(BFS поиск)</summary>
        /// <param name="root">Корень дерева.</param>
        /// <param name="sought">Искомое значение.</param>
        /// <returns>Найденная нода или null.</returns>
        public TreeNode SearchBFS(TreeNode root, int sought)
        {
            if (root == null) return null;

            Queue<TreeNode> nodes = new Queue<TreeNode>();
            TreeNode node;
            nodes.Enqueue(root);
            string checkedNodes = string.Empty;

            do
            {
                node = nodes.Dequeue();
                if (node.LeftChild != null) nodes.Enqueue(node.LeftChild);
                if (node.RightChild != null) nodes.Enqueue(node.RightChild);
                checkedNodes += node.Value;
                
                if (node.Value == sought)
                {
                    break;
                }
                else if(nodes.Count > 0)
                {
                    checkedNodes += " -> ";
                }
                else
                {
                    node = null;
                }

            } while (nodes.Count > 0);

            WriteSearchSequence("BFS  " + checkedNodes);
            return node;
        }

        /// <summary>Найти значение в дереве.(DFS поиск)</summary>
        /// <param name="root">Корень дерева.</param>
        /// <param name="sought">Искомое значение.</param>
        /// <returns>Найденная нода или null.</returns>
        public TreeNode SearchDFS(TreeNode root, int sought)
        {
            if (root == null) return null;

            Stack<TreeNode> nodesStack = new Stack<TreeNode>();
            TreeNode node = root;
            nodesStack.Push(node);
            string checkedNodes = string.Empty;

            do
            {
                node = nodesStack.Pop();
                if (node.LeftChild != null) nodesStack.Push(node.LeftChild);
                if (node.RightChild != null) nodesStack.Push(node.RightChild);
                checkedNodes += node.Value;

                if (node.Value == sought)
                {
                    break;
                }
                else if(nodesStack.Count > 0)
                {
                    checkedNodes += " -> ";
                }
                else
                {
                    node = null;
                }

            } while (nodesStack.Count > 0);

            WriteSearchSequence("DFS  " + checkedNodes);
            return node;
        }

        /// <summary>Вывести последовательност в консоль.</summary>
        /// <param name="checkedNodes">Последовательность поиска.</param>
        private void WriteSearchSequence(string checkedNodes)
        {
            System.Console.WriteLine(checkedNodes);
        }
    }
}
