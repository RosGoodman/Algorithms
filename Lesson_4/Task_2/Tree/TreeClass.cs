using System;
using System.Collections.Generic;

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

        private void PrintNodes()
        {
            int center = Center(maxDeepTree, 0);
        }

        private int Center(int deepth, int lenght)
        {
            if(deepth > 0)
            {
                lenght = Center(--deepth, lenght + deepth + 2);
            }
            return lenght;
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
            TreeNode repastNode = new TreeNode();

            if(deletingNode.ParentNode == null || deletingNode.ParentNode.Value < deletingNode.Value)
            {
                //смещаем крайнюю левую ноду в правой ветви
                //постфиксный обход
                repastNode = PostfixBypass(deletingNode);

                if (repastNode == null)
                {
                    deletingNode.ParentNode.RightChild = null;
                }
                else if (deletingNode == _rootNode)
                {
                    if (deletingNode.LeftChild != null) deletingNode.LeftChild.ParentNode = repastNode;
                    if (deletingNode.RightChild != null) deletingNode.RightChild.ParentNode = repastNode;
                    repastNode.ParentNode = null;
                    repastNode.LeftChild = deletingNode.LeftChild;
                    repastNode.RightChild = deletingNode.RightChild;
                    
                    _rootNode = repastNode;
                }
                else if(repastNode.ParentNode == deletingNode)
                {
                    if (deletingNode.RightChild != null) deletingNode.RightChild.ParentNode = repastNode;
                    repastNode.ParentNode = deletingNode.ParentNode;
                    repastNode.RightChild = deletingNode.RightChild;
                    deletingNode.ParentNode.RightChild = repastNode;
                }
                else if(repastNode != null)
                {
                    if(deletingNode.LeftChild != null)
                    {
                        repastNode.LeftChild = deletingNode.LeftChild;
                        repastNode.LeftChild.ParentNode = repastNode;
                    }
                    if(deletingNode.RightChild != null)
                    {
                        repastNode.RightChild = deletingNode.RightChild;
                        repastNode.RightChild.ParentNode = repastNode;
                    }
                    deletingNode.ParentNode.RightChild = repastNode;
                    repastNode.ParentNode = deletingNode.ParentNode;
                }
            }
            else
            {
                //смещаем крайнюю правую ноду в левой ветви
                repastNode = PostfixBypass(deletingNode);

                deletingNode.ParentNode.LeftChild = repastNode;
                if (deletingNode.LeftChild != null) deletingNode.LeftChild.ParentNode = repastNode;

                if(repastNode == null)
                {
                    deletingNode.LeftChild = null;
                }
                else if (repastNode.ParentNode == deletingNode)
                {
                    repastNode.ParentNode = deletingNode.ParentNode;
                    repastNode.RightChild = deletingNode.RightChild;
                    if (deletingNode.RightChild != null) deletingNode.RightChild.ParentNode = repastNode;
                    deletingNode.ParentNode.RightChild = repastNode;
                    repastNode.LeftChild = deletingNode.LeftChild;
                }
                else
                {
                    if (deletingNode.RightChild != null) deletingNode.RightChild.ParentNode = repastNode;
                    if (deletingNode.LeftChild != null) deletingNode.LeftChild.ParentNode = repastNode;
                    repastNode.ParentNode = deletingNode.ParentNode;
                    repastNode.RightChild = deletingNode.RightChild;
                    repastNode.LeftChild = deletingNode.LeftChild;
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
                        repastNode = deletingNode.LeftChild;
                    }
                    if(thisRoot.RightChild != null) thisRoot.RightChild.ParentNode = thisRoot.ParentNode;
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
