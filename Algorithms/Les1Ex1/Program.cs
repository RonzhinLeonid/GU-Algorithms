using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les1Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 30; i++)
            {
                if (CheckPrimeNumber(i))
                {
                    Console.Write($"{i}, ");
                }
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Проверяет простое число или нет
        /// </summary>
        /// <param name="n">Число</param>
        /// <returns></returns>
        static bool CheckPrimeNumber(int n)
        {
            if(n <= 1) return false;
            int d = 0;
            int i = 2;
            while (i < n)
            {
                if (n % i == 0) d++;
                i++;
            }
            if (d == 0) return true;
            else return false;
        }
    }
}
