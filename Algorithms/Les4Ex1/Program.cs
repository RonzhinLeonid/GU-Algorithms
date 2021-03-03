using BenchmarkDotNet.Running;
using System;

namespace Les4Ex1
{
    //Ронжин Л.
    //1. Протестируйте поиск строки в HashSet и в массиве
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);


            //string[] stringArray = new string[10];
            //string rndString = RandomString.GenRandomString();

            //for (int i = 0; i < stringArray.Length; i++)
            //{
            //    stringArray[i] = RandomString.GenRandomString();
            //}
            //Console.WriteLine(ContainsString(stringArray, stringArray[3]));

            Console.ReadKey();

            
        }
        public static bool ContainsString(string[] stringArray, string str)
        {
            foreach (var item in stringArray)
            {
                if (item == str) return true;
            }
            return false;
        }
    }
}
