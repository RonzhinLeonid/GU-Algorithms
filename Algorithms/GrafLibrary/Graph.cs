using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafLibrary
{
    public class Graph
    {
        public List<Node> Nodes;
        static int сount;
        // Список посещенных вершин
        static HashSet<Node> visited;

        public Graph(int[,] matrix)
        {
            сount = matrix.GetLength(0);
            if (!IsVerifyGraf(matrix))
                throw new Exception("Ошибка! Матрица смежности ошибочна!");
            //Console.WriteLine("Ошибка! Матрица смежности ошибочна!");
            Nodes = new List<Node>();
            for (int i = 0; i < сount; i++)
            {
                Nodes.Add(new Node( Convert.ToChar(65 + i) ));
            }

            for (int row = 0; row < сount; row++)
            {
                for (int col = 0; col < сount; col++)
                {
                    if (matrix[row, col] != 0)
                    {
                        Nodes[row].Edges.Add(Nodes[col]);
                    }
                }
            }
        }
        /// <summary>
        /// Проверка матрицы смежности
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        static bool IsVerifyGraf(int[,] matrix)
        {
            bool error = false;
            if (сount != matrix.GetLength(1))
            {
                error = true;
                throw new Exception("Ошибка! Матрица смежности неверной размерности!");
                //Console.WriteLine("Ошибка! Матрица смежности неверной размерности!");
                //return false;
            }
            if (!error)
            {
                for (int row = 0; row < сount; row++)
                {
                    for (int col = row + 1; col < сount; col++)
                        if (matrix[row, col] != matrix[col, row])
                        {
                            error = true;
                            break;
                        }
                    if (error)
                        break;
                } 
            }
            if (error)
            {
                Console.WriteLine("Ошибка! Матрица смежности ошибочна!");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Обход графа в ширину
        /// </summary>
        /// <param name="startNode"></param>
        public void BFS(Node startNode)
        {
            visited = new HashSet<Node>();

            if (startNode == null)
                return;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(startNode);
            Console.WriteLine("Помещаем начальный узел в очередь.");
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                if (visited.Contains(node))
                { 
                    Console.WriteLine($"Узел {node.Value} был посещен ранее.");
                    continue;
                }

                Console.WriteLine($"Выводим значение узла в консоль. {node.Value}");
                Console.WriteLine($"У узла {node.Value} {node.Edges.Count} ссылка/ссылки/ссылок.");
                visited.Add(node);
                Console.WriteLine($"Помещаем узел {node.Value} в HashSet.");
                foreach (var item in node.Edges)
                {
                    if (!visited.Contains(item))
                    {
                        queue.Enqueue(item);
                        Console.WriteLine($"{item.Value} является ребенком узла {node.Value}. Помещаем в очередь.");
                    }
                    else Console.WriteLine($"{item.Value} является ребенком узла {node.Value}, но он был посещен ранее.");
                }
            }
            Console.WriteLine("Граф пройден до конца.");
        }
        /// <summary>
        /// Обход графа в глубину
        /// </summary>
        /// <param name="startNode"></param>
        public void DFS(Node startNode)
        {
            visited = new HashSet<Node>();

            if (startNode == null)
                return;

            Stack<Node> stack = new Stack<Node>();
            stack.Push(startNode);
            Console.WriteLine("Помещаем начальный узел в стек.");
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                if (visited.Contains(node))
                {
                    Console.WriteLine($"Узел {node.Value} был посещен ранее.");
                    continue;
                }

                Console.WriteLine($"Выводим значение узла в консоль. {node.Value}");
                Console.WriteLine($"У узла {node.Value} {node.Edges.Count} ссылка/ссылки/ссылок.");
                visited.Add(node);
                Console.WriteLine($"Помещаем узел {node.Value} в HashSet.");
                foreach (var item in node.Edges)
                {
                    if (!visited.Contains(item))
                    {
                        stack.Push(item);
                        Console.WriteLine($"{item.Value} является ребенком узла {node.Value}. Помещаем в стек.");
                    }
                    else Console.WriteLine($"{item.Value} является ребенком узла {node.Value}, но он был посещен ранее.");
                }
            }
            Console.WriteLine("Граф пройден до конца.");
        }
        /// <summary>
        /// Вывод матрицы в консоль
        /// </summary>
        /// <param name="matrix"></param>
        public static void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
