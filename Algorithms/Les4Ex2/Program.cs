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
            tree2.AddItem(8);
            tree2.AddItem(5);
            tree2.AddItem(10);
            tree2.AddItem(2);
            tree2.AddItem(6);
            tree2.AddItem(7);

            tree2.RemoveItem(5);

            //var qqq = TreeHelper.GetTreeInLine(tree2);
            tree2.PrintTree();
            TreeNode rr = tree2.GetRoot();
            TreeNode rrr = tree2.GetNodeByValue(55);
            Console.ReadKey();
        }
    }
}
