using Les4Ex2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLibrary
{
    public  class BFSAndDFSTree
    {
        /// <summary>
        /// Обход графа в глубину
        /// </summary>
        /// <param name="matrix"></param>
        public static void DFS(BinaryTreeSearch tree)
        {
            var root = tree.GetRoot();
            if (root == null) 
            {
                Console.WriteLine("Дерево пустое");
                return; 
            }
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            Console.WriteLine("Помещаем корень дерева в стек");
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                Console.WriteLine($"Выводим значение узла в консоль {node.Value}");
                if (node.RightChild != null)
                {
                    stack.Push(node.RightChild);
                    Console.WriteLine($"Помещаем правого ребенка узла {node.Value} в стек");
                }
                if (node.LeftChild != null)
                {
                    stack.Push(node.LeftChild);
                    Console.WriteLine($"Помещаем левого ребенка узла {node.Value} в стек");
                }
            }
            Console.WriteLine("Дерево пройдено до конца");
        }
        /// <summary>
        /// Обход графа в глубину
        /// </summary>
        /// <param name="matrix"></param>
        public static void BFS(BinaryTreeSearch tree)
        {
            var root = tree.GetRoot();
            if (root == null)
            {
                Console.WriteLine("Дерево пустое");
                return;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            Console.WriteLine("Помещаем корень дерева в очередь");
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                Console.WriteLine($"Выводим значение узла в консоль {node.Value}");
                if (node.LeftChild != null)
                {
                    queue.Enqueue(node.LeftChild);
                    Console.WriteLine($"Помещаем правого ребенка узла {node.Value} в стек");
                }
                if (node.RightChild != null)
                {
                    queue.Enqueue(node.RightChild);
                    Console.WriteLine($"Помещаем левого ребенка узла {node.Value} в стек");
                }
            }
            Console.WriteLine("Дерево пройдено до конца");
        }
    }
}
