using System;
using System.Collections.Generic;
using System.Text;

namespace Les2ExCore
{
    class Node : ILinkedList
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
        /// <summary>
        /// добавляет новый элемент списка
        /// </summary>
        /// <param name="value"></param>
        public void AddNode(int value)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// добавляет новый элемент списка после определённого элемента
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        public static void AddNodeAfter(Node node, int value)
        {
            Node newNode = new Node { Value = value };

            Node nextItem = node.NextNode; // запоминаем следующий элемент в списке за указанным.

            node.NextNode = newNode; // в текущем заменяем ссылку на следующий на новый элемент
            if (nextItem != null)
            {
                nextItem.PrevNode = newNode; // в следующем за указанным в ссылке на предыдущий указываем новый элемнт
            }
            newNode.NextNode = nextItem; //в новом указываем ссылку на следующий из сохраненного ранее элемента nextItem
            newNode.PrevNode = node; //в новом указываем ссылку на предыдущий на стьартовый элемнт
        }
        /// <summary>
        /// ищет элемент по его значению
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public Node FindNode(int searchValue)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// возвращает количество элементов в списке
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// удаляет элемент по порядковому номеру
        /// </summary>
        /// <param name="index"></param>
        public void RemoveNode(int index)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// удаляет указанный элемент
        /// </summary>
        /// <param name="node"></param>
        public void RemoveNode(Node node)
        {
            throw new NotImplementedException();
        }
    }
}
