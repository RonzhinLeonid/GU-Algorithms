using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les2Ex1
{
    class Program
    {
        //Ронжин Л.
        //Требуется реализовать класс двусвязного списка и операции вставки, удаления и поиска элемента в нём в соответствии с интерфейсом
        static void Main(string[] args)
        {
            LinkedList root = new LinkedList();
            root.ToString();
            int[] array = new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000 };
            LinkedList root1 = new LinkedList(array);
            LinkedList expected = new LinkedList(new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000, 100 });
            int value = 100;
            root1.AddNode(value);
            

            Console.WriteLine(root.GetCount());
            root.AddNode(100);
            Console.WriteLine(root.GetCount());
            root.AddNode(200);
            Console.WriteLine(root.GetCount());
            root.AddNode(300);
            Console.WriteLine(root.GetCount());
            var test = root.FindNode(200);
            root.AddNodeAfter(root.FindNode(201), 250);
            Console.WriteLine(root.GetCount());
            root.AddNodeAfter(root.FindNode(250), 270);
            Console.WriteLine(root.GetCount());
            root.AddNodeAfter(root.FindNode(300), 350);
            Console.WriteLine(root.GetCount());
            root.RemoveNode(root.FindNode(100));
            root.RemoveNode(root.FindNode(350));
            root.RemoveNode(root.FindNode(200));
            //root.RemoveNode(0);
            //root.RemoveNode(2);
            //root.RemoveNode(root.GetCount()-1);

            Console.ReadKey();
        }
    }
}
