using System;

namespace Task_2.Tree
{
    public class TreeClass : ITree
    {
        private TreeNode _rootNode;
        private int maxDeepTree = 0;

        public int Count { get; private set; }

        /// <summary>Добавить ноду в дерево.</summary>
        /// <param name="value">Значение добавляемой ноды.</param>
        public void AddItem(int value)
        {
            TreeNode node = new TreeNode();
            node.Value = value;
            Count++;

            if (_rootNode == null)
            {
                _rootNode = node;
                Count = 1;
                return;
            }

            TreeNode parentNode = PrefixBypass(value, false);
            if(value >= parentNode.Value && parentNode.RightChild == null)
                parentNode.RightChild = node;
            else
                parentNode.LeftChild = node;

            node.ParentNode = parentNode;
        }

        /// <summary>Найти ноду по начению.</summary>
        /// <param name="value">Значение искомой ноды.</param>
        /// <returns>Найденная нода, null, если не найдена.</returns>
        public TreeNode GetNodeByValue(int value)
        {
            return PrefixBypass(value, true);
        }

        /// <summary>Получить корневую ноду дерева.</summary>
        /// <returns>Корневая нода.</returns>
        public TreeNode GetRoot()
        {
            return _rootNode;
        }

        /// <summary>Вывести дерево в консоль.</summary>
        public void PrintTree()
        {
            maxDeepTree = 0;
            GetDepthTree(_rootNode, 0);
            int x = maxDeepTree;
            PrintNodes();
        }

        /// <summary>Вывести дерево в консоль.</summary>
        private void PrintNodes()
        {
            //int center = Center(maxDeepTree, 0);
            PrintingTree(_rootNode, maxDeepTree);
        }

        /// <summary>Вывод нод на консоль.</summary>
        /// <param name="p">Нода.</param>
        /// <param name="padding">Максимальная глубина дерева.</param>
        private void PrintingTree(TreeNode p, int padding)
        {
            if (p != null)
            {
                if (p.RightChild != null)
                {
                    PrintingTree(p.RightChild, padding + 4);
                }
                if (padding > 0)
                {
                    Console.Write(" ".PadLeft(padding));
                }
                if (p.RightChild != null)
                {
                    Console.Write("/\n");
                    Console.Write(" ".PadLeft(padding));
                }
                Console.Write(p.Value+ "\n ");
                if (p.LeftChild != null)
                {
                    Console.Write(" ".PadLeft(padding) + "\\\n");
                    PrintingTree(p.LeftChild, padding + 4);
                }
            }
        }

        /// <summary>Получить максимальную глубину дерева.</summary>
        /// <param name="node">Коренная нода.</param>
        /// <param name="depth">Глубина рекурсии.</param>
        private void GetDepthTree(TreeNode node, int depth)
        {
            if (node.LeftChild != null)
            {
                GetDepthTree(node.LeftChild, ++depth);
                depth--;
            }

            if (node.RightChild != null)
            {
                GetDepthTree(node.RightChild, ++depth);
                depth--;
            }

            if (depth > maxDeepTree)
                maxDeepTree = depth;
        }

        /// <summary>Удалить ноду по значению.</summary>
        /// <param name="value">Значение удаляеой ноды.</param>
        public void RemoveItem(int value)
        {
            TreeNode deletingNode = PrefixBypass(value, true);
            TreeNode repastNode = PostfixBypass(deletingNode);

            if(deletingNode.ParentNode == null) //удаляем корень
            {
                if (deletingNode.LeftChild != null) deletingNode.LeftChild.ParentNode = repastNode;
                if (deletingNode.RightChild != null) deletingNode.RightChild.ParentNode = repastNode;
                repastNode.ParentNode = null;
                repastNode.LeftChild = deletingNode.LeftChild;
                repastNode.RightChild = deletingNode.RightChild;

                _rootNode = repastNode;
            }
            //удаление в левой ветви
            else if (deletingNode.ParentNode.Value > deletingNode.Value)
            {
                //лист (нет замещающей ноды)
                if (repastNode == null)  
                {
                    deletingNode.ParentNode.LeftChild = null;
                }
                //замещающая нода является дочерней удаляемой
                else if (repastNode.ParentNode == deletingNode)
                {
                    deletingNode.ParentNode.LeftChild = repastNode;
                    repastNode.ParentNode = deletingNode.ParentNode;
                    if (repastNode.Value > deletingNode.Value)
                    {
                        repastNode.LeftChild = deletingNode.LeftChild;
                        if (deletingNode.LeftChild != null && deletingNode.LeftChild != repastNode) repastNode.LeftChild.ParentNode = repastNode;
                    }
                    else
                    {
                        repastNode.RightChild = deletingNode.RightChild;
                        if (deletingNode.RightChild != null && deletingNode.RightChild != repastNode) repastNode.RightChild.ParentNode = repastNode;
                    }
                }
                //замещение узла
                else
                {
                    if (repastNode.Value > repastNode.ParentNode.Value)
                        repastNode.ParentNode.RightChild = null;
                    else
                        repastNode.ParentNode.LeftChild = null;

                    deletingNode.ParentNode.LeftChild = repastNode;
                    deletingNode.LeftChild.ParentNode = repastNode;
                    deletingNode.RightChild.ParentNode = repastNode;
                    repastNode.ParentNode = deletingNode.ParentNode;
                    repastNode.LeftChild = deletingNode.LeftChild;
                    repastNode.RightChild = deletingNode.RightChild;
                }
            }
            //удаление в правой ветви
            else
            {
                //лист (нет замещающей ноды)
                if (repastNode == null) 
                {
                    deletingNode.ParentNode.RightChild = null;
                }
                //замещающая нода является дочерней удаляемой
                else if (repastNode.ParentNode == deletingNode)
                {
                    deletingNode.ParentNode.RightChild = repastNode;
                    repastNode.ParentNode = deletingNode.ParentNode;

                    if (repastNode.Value > deletingNode.Value)
                    {
                        repastNode.LeftChild = deletingNode.LeftChild;
                        if (deletingNode.LeftChild != null) repastNode.LeftChild.ParentNode = repastNode;
                    }
                    else
                    {
                        repastNode.RightChild = deletingNode.RightChild;
                        if (deletingNode.RightChild != null) repastNode.RightChild.ParentNode = repastNode;
                    }
                }
                //замещение узла
                else
                {
                    if (repastNode.Value > repastNode.ParentNode.Value)
                        repastNode.ParentNode.RightChild = null;
                    else
                        repastNode.ParentNode.LeftChild = null;

                    deletingNode.ParentNode.LeftChild = repastNode;
                    deletingNode.LeftChild.ParentNode = repastNode;
                    deletingNode.RightChild.ParentNode = repastNode;
                    repastNode.ParentNode = deletingNode.ParentNode;
                    repastNode.LeftChild = deletingNode.LeftChild;
                    repastNode.RightChild = deletingNode.RightChild;
                }
            }
        }

        /// <summary>Постфиксный обход дерева.</summary>
        /// <param name="deletingNode">Удаляемая нода.</param>
        /// <returns>Нода замещающая удаляемую.</returns>
        private TreeNode PostfixBypass(TreeNode deletingNode)
        {
            TreeNode repastNode = null;
            TreeNode thisRoot = new TreeNode();

            thisRoot = deletingNode.RightChild;

            if (thisRoot == null) return thisRoot;

            do
            {
                if (thisRoot.LeftChild != null)
                {
                    thisRoot = thisRoot.LeftChild;
                    continue;
                }
                else if (thisRoot.LeftChild == null)
                {
                    repastNode = thisRoot;
                    if(thisRoot.ParentNode != deletingNode)
                        thisRoot.ParentNode.LeftChild = thisRoot.RightChild;
                    else
                    {
                        repastNode = deletingNode.RightChild;
                    }
                    //if(thisRoot.RightChild != null) thisRoot.RightChild.ParentNode = thisRoot.ParentNode;
                    break;
                }
            } while (true);

            return repastNode;
        }

        /// <summary>Префиксный обход дерева.</summary>
        /// <param name="value">Искомое значение.</param>
        /// <returns>Ближайшая родительская нода.</returns>
        private TreeNode PrefixBypass(int value, bool search)
        {
            if (_rootNode.Value == value) return _rootNode;

            var current = _rootNode;

            do
            {
                if (value < current.Value)
                {
                    if (search && current.LeftChild == null)
                        return null;
                    else if (search && current.LeftChild.Value == value)     //условие при поиске по значению
                        return current.LeftChild;
                    else
                    {
                        if (current.LeftChild == null)      //условие при поиске места для вставки
                            return current;
                        else
                            current = current.LeftChild;
                    }
                }
                else
                {
                    if (search && current.RightChild.Value == value)    //условие при поиске по значению
                        return current.RightChild;
                    else
                    {
                        if (current.RightChild == null)     //условие при поиске места для вставки
                            return current;
                        else
                            current = current.RightChild;
                    }
                }
            } while (true);
        }
    }
}
