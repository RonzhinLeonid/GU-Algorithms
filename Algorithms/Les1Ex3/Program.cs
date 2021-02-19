using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les1Ex3
{
    class Program
    {
        //Ронжин Л.
        //Требуется реализовать рекурсивную версию и версию без рекурсии (через цикл).
        static void Main(string[] args)
        {
            int[] N = new int[]         { -5,           0, 1, 5, 11, 25}; //массив исходных данных
            int[] expFibRec = new int[] { int.MinValue, 0, 1, 5, 89, 75025}; //массив ожидаемых значений по алгоритму из методички
            int[] expFibFor = new int[] { int.MinValue, 0, 1, 5, 89, 75025 }; //массив ожидаемых значений по доработанному алгоритму
            Console.WriteLine($"Число |Рез-т рекурс ф-ции|Рез. теста|Рез-т ф-ции с циклом|Рез. теста");
            for (int i = 0; i < N.Length; i++)
            {
                bool resultFibRec = expFibRec[i] == GetNumberFibRec(N[i]);
                bool resultFibFor = expFibFor[i] == GetNumberFibFor(N[i]);
                Console.WriteLine($"{N[i],5} | {GetNumberFibRec(N[i]),16} | {resultFibRec,8} | {GetNumberFibFor(N[i]),18} | {resultFibFor,8}");
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
            try
            { 
            if (n < 0) throw new Exception("Exception");
            if (n == 0) return 0;
            if (n == 1) return 1;
            return GetNumberFibRec(n - 2) + GetNumberFibRec(n - 1);
            }
            catch 
            {
                return int.MinValue;
            }
        }

        /// <summary>
        /// Получение числа Фибоначчи по его номеру в ряду циклом.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int GetNumberFibFor(int n)
        {
            try
            {
                if (n < 0) throw new Exception("Exception");
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
            catch 
            {
                return int.MinValue;
            }
        }
    }
}
