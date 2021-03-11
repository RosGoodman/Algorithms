using System.Collections.Generic;
using Task_2.Tree;

namespace Task_1.Search_BFS_DFS
{
    public class Search_BFS
    {
        //поиск с помощью очереди

        /// <summary>Найти значение в дереве.(BFS поиск)</summary>
        /// <param name="root">Корень дерева.</param>
        /// <param name="sought">Искомое значение.</param>
        /// <returns></returns>
        public TreeNode SearchBFS(TreeNode root, int sought)
        {
            if (root == null) return null;

            Queue<TreeNode> nodes = new Queue<TreeNode>();
            TreeNode node;
            nodes.Enqueue(root);

            do
            {
                node = nodes.Dequeue();
                if (node.Value == sought) break;
                if (node.LeftChild != null) nodes.Enqueue(node.LeftChild);
                if (node.RightChild != null) nodes.Enqueue(node.RightChild);
            } while (nodes.Count > 0);

            return node;
        }
    }
}
