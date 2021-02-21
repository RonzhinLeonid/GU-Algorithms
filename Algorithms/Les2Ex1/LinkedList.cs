using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les2Ex1
{
    class LinkedList : ILinkedList
    {
        private Node startNode;
        private Node endNode;

        public LinkedList()
        {
            startNode = null;
            endNode = null;
        }

        /// <summary>
        /// добавляет новый элемент в конец списка
        /// </summary>
        /// <param name="value"></param>
        public void AddNode(int value)
        {
            Node newNode = new Node { Value = value };
            if (startNode ==  null)
            {
                startNode = newNode;
            }
            else 
            {
                var node = startNode;
                while (node.NextNode != null)
                {
                    node = node.NextNode;
                }
                node.NextNode = newNode;
                newNode.PrevNode = node;
            }
            endNode = newNode;
        }
        /// <summary>
        /// добавляет новый элемент списка после определённого элемента
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        public void AddNodeAfter(Node node, int value)
        {
            Node newNode = new Node { Value = value };
            Node nextItem = node.NextNode; // запоминаем следующий элемент в списке за указанным.
            node.NextNode = newNode; // в текущем заменяем ссылку на следующий на новый элемент
            if (nextItem != null)
            {
                nextItem.PrevNode = newNode; // в следующем за указанным в ссылке на предыдущий указываем новый элемнт
            }
            newNode.NextNode = nextItem; //в новом указываем ссылку на следующий из сохраненного ранее элемента nextItem
            newNode.PrevNode = node; //в новом указываем ссылку на предыдущий на стартовый элемнт
            if (node == endNode) endNode = newNode;
        }
        /// <summary>
        /// ищет элемент по его значению
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public Node FindNode(int searchValue)
        {
            var currentNode = startNode;

            while (currentNode != null)
            {
                if (currentNode.Value == searchValue)
                    return currentNode;

                currentNode = currentNode.NextNode;
            }
            return null; // если ничего не нашли, то null

        }
        /// <summary>
        /// возвращает количество элементов в списке
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            int count = 0;
            var currentNode = startNode;
            while (currentNode != null)
            {
                count++;
                currentNode = currentNode.NextNode;
            }
            return count;
        }
        /// <summary>
        /// удаляет элемент по порядковому номеру
        /// </summary>
        /// <param name="index"></param>
        public void RemoveNode(int index)
        {
            if (index == 0)
            {
                var newStartNode = startNode.NextNode;
                newStartNode.PrevNode = null;
                startNode = newStartNode;
                return;
            }
            if (index == GetCount() - 1)
            {
                var newEndNode = endNode.PrevNode;
                newEndNode.NextNode = null;
                endNode = newEndNode;
                return;
            }
            int currentIndex = 0;
            var currentNode = startNode;
            while (currentNode != null)
            {
                if (currentIndex == index)
                {
                    RemoveNode(currentNode);
                    return;
                }
                currentNode = currentNode.NextNode;
                currentIndex++;
            }
        }
        /// <summary>
        /// удаляет указанный элемент
        /// </summary>
        /// <param name="node"></param>
        public void RemoveNode(Node node)
        {
            if (node == endNode)
            {
                endNode = node.PrevNode;
                endNode.NextNode = null;
                return;
            }
            if (node == startNode)
            {
                startNode = node.NextNode;
                startNode.PrevNode = null;
                return;
            }
            var prevItem = node.PrevNode;
            var nextItem = node.NextNode;
            prevItem.NextNode = nextItem;
            nextItem.PrevNode = prevItem;
        }

    }
}
