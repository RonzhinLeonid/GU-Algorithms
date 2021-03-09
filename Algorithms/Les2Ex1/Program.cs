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
            int[] array = new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000 };
            LinkedList root = new LinkedList(array);

            foreach (var item in root)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
        }
    }
}
