using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les4Ex2
{
    class BinaryTreeSearch : ITree
    {
        private TreeNode head;

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
            TreeNode tmp = null;
            if (head == null)
            {
                head = GetFreeNode(value);
                return;
            }
            tmp = head;
            while (tmp != null)
            {
                if (value > tmp.Value)
                {
                    if (tmp.RightChild != null)
                    {
                        tmp = tmp.RightChild;
                        continue;

                    }
                    else
                    {
                        tmp.RightChild = GetFreeNode(value);
                        return;
                    }
                }
                else if (value < tmp.Value)
                {
                    if (tmp.LeftChild != null)
                    {
                        tmp = tmp.LeftChild;
                        continue;

                    }
                    else
                    {
                        tmp.LeftChild = GetFreeNode(value);
                        return;
                    }
                }
                else
                {
                    throw new Exception("Wrong tree state");  // Дерево построено неправильно
                }
            }
        }

        public TreeNode GetNodeByValue(int value)
        {
            throw new NotImplementedException();
        }

        public TreeNode GetRoot()
        {
            throw new NotImplementedException();
        }

        public void PrintTree()
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(int value)
        {
            throw new NotImplementedException();
        }
    }
}
