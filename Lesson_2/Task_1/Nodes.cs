
namespace Task_1
{
    public class Nodes : ILinkedList
    {
        private Node _lastNode;
        private Node _firstNode;

        /// <summary>Добавить новую ноду (в конец).</summary>
        /// <param name="value">Значение ноды.</param>
        public void AddNode(int value)
        {
            if(_firstNode != _lastNode)
            {
                Node node = _lastNode;
                Node newNode = new Node(value, null, node);
                node.NextNode = newNode;
                _lastNode = newNode;
            }
            else
            {
                Node node = new Node(value, null, null);
                _firstNode = node;
            }
        }

        /// <summary>Вставить ноду после указанной.</summary>
        /// <param name="node">Нода, после которой будет вставка новой.</param>
        /// <param name="value">Значение новой ноды.</param>
        public void AddNodeAfter(Node node, int value)
        {
            Node newNode = new Node(value, node.NextNode, node.PrevNode);
            Node nextNode = node.NextNode;
            nextNode.PrevNode = newNode;
            node.NextNode = newNode;
        }

        /// <summary>Поиск ноды по значению.</summary>
        /// <param name="searchValue">Искомое значение.</param>
        /// <returns>Найденная нода.</returns>
        public Node FindNode(int searchValue)
        {
            Node searchNode = null;
            Node node = _firstNode;
            while(node.Value != searchValue)
            {
                if (node.NextNode != null)
                    node = node.NextNode;
                else
                    return searchNode;
            }
            return node;
        }

        /// <summary>Получить кол-во нод.</summary>
        /// <returns>Кол-во нод.</returns>
        public int GetCount()
        {
            Node node = _firstNode;
            int count = 0;
            while(node.NextNode != null)
            {
                node = node.NextNode;
                count++;
            }
            return count;
        }

        /// <summary>Удалить ноду по порядковому номеру.</summary>
        /// <param name="index">Порядковый номер.</param>
        public void RemoveNode(int index)
        {
            Node node = _firstNode;
            while(index != 0)
            {
                if (node.NextNode != null)
                {
                    node = node.NextNode;
                    index--;
                }
                else
                    break;

                if(index == 0)
                {
                    RemoveNode(node);
                }
            }
        }

        /// <summary>Удалить указанную ноду.</summary>
        /// <param name="node">Удаляемая нода.</param>
        public void RemoveNode(Node node)
        {
            node.NextNode.PrevNode = node.PrevNode;
            node.PrevNode.NextNode = node.NextNode;
        }

        #region Метод для упрощения тестов.

        //Метод создан только для тестов

        /// <summary>Получить ноду по порядковому номеру.</summary>
        /// <param name="index">Порядковый номер.</param>
        /// <returns>Найденная нода.</returns>
        public Node GetNodeByIndex(int index)
        {
            Node node = _firstNode;
            while (index != 0)
            {
                if (node.NextNode != null)
                {
                    node = node.NextNode;
                    index--;
                }
                else
                    break;

                if (index == 0)
                {
                    return node;
                }
            }
            return node;
        }
        #endregion
    }
}
