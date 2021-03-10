﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les4Ex2
{
    //Ронжин Л.
    //2. Реализуйте двоичное дерево и метод вывода его в консоль
    class Program
    {
        static void Main(string[] args)
        {
            var tree2 = new BinaryTreeSearch();
            tree2.AddItem(20);
            tree2.AddItem(30);
            tree2.AddItem(10);
            tree2.AddItem(5);
            tree2.AddItem(9);
            tree2.AddItem(1);
            tree2.AddItem(22);
            tree2.AddItem(15);
            tree2.AddItem(16);
            tree2.AddItem(13);
            tree2.AddItem(25);
            tree2.AddItem(0);
            tree2.PrintTree();
            tree2.RemoveItem(5);
            Console.WriteLine("\nУдалить узел со значение 5");
            tree2.PrintTree();
            tree2.RemoveItem(10);
            Console.WriteLine("\nУдалить узел со значение 10");
            tree2.PrintTree();
            
            Console.ReadKey();
        }
    }
}
