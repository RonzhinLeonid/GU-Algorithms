using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les4Ex2
{
    public class BinaryTreeSearch : ITree
    {
        private TreeNode _root;
        public BinaryTreeSearch(int[] array)
        {
            foreach (var item in array)
            {
                AddItem(item);
            }
        }
        public BinaryTreeSearch()
        {
        }

        public static TreeNode GetFreeNode(int value)
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
            if (_root == null)
            {
                _root = GetFreeNode(value);
                return;
            }
            node = _root;
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
            if (_root == null) return null;
            var node = _root;
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
        /// Поиск узла по его значению с выводом родителя
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TreeNode GetNodeByValueWithParent(int value, out TreeNode parent)
        {
            parent = null;
            if (_root == null) return null;
            var node = _root;
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
            if (_root ==  null) return null;
            return _root;
        }
        /// <summary>
        /// Вспомогательный метод получения горизонтального разделителя.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string GetSpacing(int n)
        {
            string str = "";
            if (n == 0) return str;
            else if (n < 0) throw new Exception("Неверное значение");
            else
                for (int i = 0; i < n; i++)
                    str += "_";
            return str;
        }
        /// <summary>
        /// Печать узла дерева по координатам
        /// </summary>
        /// <param name="node"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="spac"></param>
        /// <returns></returns>
        public int _PrintTree(TreeNode node, int x, int y, int spac)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(node.Value);
            var sp = spac;
            var loc = y;
            if (node.RightChild != null)
            {
                while (loc <= y)
                {
                    Console.SetCursorPosition(x + 2, y + 1);
                    Console.Write("\\" + GetSpacing(spac));
                    loc++;
                }
                y = _PrintTree(node.RightChild, x + 4 + spac, y + 2, sp/3);
            }
            sp = spac;
            loc = y;
            if (node.LeftChild != null)
            {
                while (loc <= y)
                {
                    Console.SetCursorPosition(x-2 - spac, loc + 1);
                    Console.Write(GetSpacing(spac) + "/");
                    loc++;
                }
                y = _PrintTree(node.LeftChild, x-4 - spac, y + 2, sp/3);
            }
            
            return y-2;
        }
        /// <summary>
        /// Вывод дерева в консоль
        /// </summary>
        public void PrintTree()
        {
            if (_root == null) return;
            var TreeArray = TreeHelper.GetTreeInLine(_root);

            var spacing = TreeArray[TreeArray.Length - 1].Depth - 1;
            var cursorPositionX = (int)Math.Pow(2,TreeArray[TreeArray.Length - 1].Depth) * 4;
            var cursorPositionY = Console.CursorTop+2;
            _PrintTree(_root, cursorPositionX, cursorPositionY, 18);
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
                    _root = node.LeftChild;
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
                    _root = node.RightChild;
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
                leftParent.LeftChild = leftNode.RightChild;
                leftNode.LeftChild = node.LeftChild;
                leftNode.RightChild = node.RightChild;
                if (parent==null)
                    _root = leftNode;
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

