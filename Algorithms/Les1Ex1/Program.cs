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
            int[] N            = new int[] { -1,           0,            1,             5,        11,        25,           100,          127 }; //массив исходных данных
            string[] exp    = new string[] { "Простое",    "Простое",    "Простое",    "Простое", "Простое", "Не простое", "Не простое", "Простое" }; //массив ожидаемых значений по алгоритму из методички
            string[] expUpd = new string[] { "Не простое", "Не простое", "Не простое", "Простое", "Простое", "Не простое", "Не простое", "Простое" }; //массив ожидаемых значений по доработанному алгоритму
            Console.WriteLine($"Число |Рез-т ф-ции из алг|Рез. теста|Рез-т дораб ф-ции|Рез. теста");
            for (int i = 0; i < N.Length; i++)
            {
                bool result = exp[i] == CheckPrimeNumber(N[i]);
                bool resultUpd = expUpd[i] == CheckPrimeNumberUpd(N[i]);
                Console.WriteLine($"{N[i],5} | {CheckPrimeNumber(N[i]),16} | {result,8} | {CheckPrimeNumberUpd(N[i]),15} | {resultUpd,8}");
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Проверяет простое число или нет
        /// </summary>
        /// <param name="n">Число</param>
        /// <returns></returns>
        static string CheckPrimeNumber(int n)
        {
            int d = 0;
            int i = 2;
            while (i < n)
            {
                if (n % i == 0) d++;
                i++;
            }
            if (d == 0) return "Простое";
            else return "Не простое";
        }
        /// <summary>
        /// Проверяет простое число или нет
        /// </summary>
        /// <param name="n">Число</param>
        /// <returns></returns>
        static string CheckPrimeNumberUpd(int n)
        {
            if (n <= 1) return "Не простое";
            int i = 2;
            while (i < n)
            {
                if (n % i == 0) 
                { 
                    return "Не простое"; 
                }
                i++;
            }
            return "Простое";
        }
    }
}
