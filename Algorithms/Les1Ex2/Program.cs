using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les1Ex2
{
    class Program
    {
        //Ронжин Л.
        //Вычислите асимптотическую сложность функции из примера ниже.
        static void Main(string[] args)
        {

        }
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0; //O(1)
            for (int i = 0; i < inputArray.Length; i++) // сложность цикла for O(N)
            {
                for (int j = 0; j < inputArray.Length; j++) // сложность вложенного цикла for O(N^2) по правилу 4
                {
                    for (int k = 0; k < inputArray.Length; k++) // сложность второго вложенного цикла for O(N^3)
                    {
                        int y = 0; //O(1)

                        if (j != 0) //O(1)
                        {
                            y = k / j;
                        }

                        sum += inputArray[i] + i + k + j + y; //O(1) при выполнении всех 3х условий O(3*N^3) по правилу 5 получаем O(N^3)
                    }
                }
            }
            return sum; //O(1)
            ///Итоговая сложность получается O(2+N^3), по правилу 3 получаем O(N^3)
        }
    }
}
