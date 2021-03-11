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
        }
    }
}
