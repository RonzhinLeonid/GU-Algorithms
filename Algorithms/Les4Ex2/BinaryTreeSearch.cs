using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les4Ex2
{
    class BinaryTreeSearch : ITree
    {
        private TreeNode _head;

        public static TreeNode Tree(int n)
        {
            TreeNode newNode = null;
            if (n == 0)
                return null;
            else
            {
                var nl = n / 2;
                var nr = n - nl - 1;
                newNode = new TreeNode();
                newNode.Value = new Random().Next(1000);
                newNode.LeftChild = Tree(nl);
                newNode.RightChild = Tree(nr);
            }
            return newNode;
        }

        private TreeNode GetFreeNode(int value)
        {
            return new TreeNode
            {
                Value = value
            };
        }
        /// <summary>
        /// Добавление элемента в дерево
        /// </summary>
        /// <param name="value"></param>
        public void AddItem(int value)
        {
            TreeNode node = null;
            if (_head == null)
            {
                _head = GetFreeNode(value);
                return;
            }
            node = _head;
            while (node != null)
            {
                if (value > node.Value)
                {
                    if (node.RightChild != null)
                    {
                        node = node.RightChild;
                        continue;
                    }
                    else
                    {
                        node.RightChild = GetFreeNode(value);
                        return;
                    }
                }
                else if (value <= node.Value)
                {
                    if (node.LeftChild != null)
                    {
                        node = node.LeftChild;
                        continue;
                    }
                    else
                    {
                        node.LeftChild = GetFreeNode(value);
                        return;
                    }
                }
                //else
                //{
                //    throw new Exception("Wrong tree state");  // Дерево построено неправильно
                //}
            }
        }
        /// <summary>
        /// Поиск узла по его значению
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TreeNode GetNodeByValue(int value)
        {
            if (_head == null) return null;
            var node = _head;
            while (node != null)
            {
                if (node.Value == value)
                    return node;
                else if (value > node.Value)
                    node = node.RightChild; 
                else if (value < node.Value)
                    node = node.LeftChild;
            }
            return null;
        }
        /// <summary>
        /// Поиск узла по его значению
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TreeNode GetNodeByValueWithParent(int value, out TreeNode parent)
        {
            parent = null;
            if (_head == null) return null;
            var node = _head;
            while (node != null)
            {
                if (node.Value == value)
                    return node;
                else if (value > node.Value)
                {
                    parent = node;
                    node = node.RightChild;
                }
                else if (value < node.Value)
                {
                    parent = node;
                    node = node.LeftChild;
                }
            }
            return null;
        }
        /// <summary>
        /// Получить корень дерева
        /// </summary>
        /// <returns></returns>
        public TreeNode GetRoot()
        {
            if (_head ==  null) return null;
            return _head;
        }

        public void PrintTree()
        {
            if (_head == null) return;

            var t = Console.CursorTop;
            var qqq = TreeHelper.GetTreeInLine(_head);
            Console.Write(qqq[0].Node.Value);
            for (int i = 1; i < qqq.Length; i++)
            {
                if (qqq[i-1].Depth == qqq[i].Depth)
                    Console.Write(" " + qqq[i].Node.Value);
                else
                {
                    Console.WriteLine();
                    Console.Write(qqq[i].Node.Value);
                }

            }
            //throw new NotImplementedException();
        }
        /// <summary>
        /// Удалить узел по значению
        /// </summary>
        /// <param name="value"></param>
        public void RemoveItem(int value)
        {
            TreeNode node = null;
            TreeNode parent = null;
            node = GetNodeByValueWithParent(value, out parent);
            if (node == null)
            {
                return;
            }
            // Случай 1: Если нет детей справа, левый ребенок встает на место удаляемого.
            if (node.RightChild == null)
            {
                if (parent == null)
                    _head = node.LeftChild;
                else
                {
                    if (parent.Value > value)
                        parent.LeftChild = node.LeftChild;
                    else if (parent.Value < value)
                        parent.RightChild = node.LeftChild;
                }
            }
            // Случай 2: Если у правого ребенка нет детей слева то он занимает место удаляемого узла.
            else if (node.RightChild.LeftChild == null)
            {
                node.RightChild.LeftChild = node.LeftChild;
                if (parent == null)
                    _head = node.RightChild;
                else 
                {
                    if (parent.Value > value)
                        parent.LeftChild = node.RightChild;
                    else if (parent.Value < value)
                        parent.RightChild = node.RightChild;
                }
            }
            // Случай 3: Если у правого ребенка есть дети слева, крайний левый ребенок из правого поддерева заменяет удаляемый узел.
            else
            {
                TreeNode leftNode = node.RightChild.LeftChild;
                TreeNode leftParent = node.RightChild;
                while (leftNode.LeftChild != null)
                {
                    leftParent = leftNode;
                    leftNode = leftNode.LeftChild;
                }
                leftParent.LeftChild = leftParent.RightChild;
                leftNode.LeftChild = node.LeftChild;
                leftNode.RightChild = node.RightChild;
                if (parent==null)
                    _head = leftNode;
                else
                {
                    if (parent.Value > value)
                        parent.LeftChild = leftNode;
                    else if (parent.Value < value)
                        parent.RightChild = leftNode;
                }
            }
        }
    }
}

