using System;
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
            var tree = BinaryTreeSearch.Tree(20);
            var tree2 = new BinaryTreeSearch();
            tree2.AddItem(101);
            tree2.AddItem(99);
            tree2.AddItem(55);
            tree2.AddItem(103);
            tree2.AddItem(102);
            tree2.AddItem(104);
        }
    }
}
