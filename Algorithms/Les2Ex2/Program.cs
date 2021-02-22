using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Les2Ex2Library;

namespace Les2Ex2
{
    class Program
    {
        //Ронжин Л.
        //Требуется написать функцию бинарного поиска, посчитать его асимптотическую сложность и проверить работоспособность функции.
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            MyClass.BinarySearch(arr, 4);
        }
    }
}
