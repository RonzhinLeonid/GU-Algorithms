using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les1Ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 30; i++)
            {
                    Console.WriteLine($"{i} - {GetNumberFibRec(i)}, {GetNumberFib(i)}");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Получение числа Фибоначчи по его номеру в ряду рекурсией.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int GetNumberFibRec(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return GetNumberFibRec(n - 2) + GetNumberFibRec(n - 1);
        }

        /// <summary>
        /// Получение числа Фибоначчи по его номеру в ряду циклом.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int GetNumberFib(int n)
        {
            int fib1 = 0;
            int fib2 = 1;

            if (n == 0) return fib1;
            if (n == 1) return fib2;
            int fibSum = 0;
            for (int i = 2; i <= n; i++)
            {
                fibSum = fib1 + fib2;
                fib1 = fib2;
                fib2 = fibSum;
            }
            return fibSum;
        }
    }
}
