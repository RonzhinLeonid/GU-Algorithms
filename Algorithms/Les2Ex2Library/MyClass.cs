using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les2Ex2Library
{
    public class MyClass
    {
        //Ронжин Л.
        //Требуется написать функцию бинарного поиска, посчитать его асимптотическую сложность и проверить работоспособность функции.
        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            if (inputArray == null)
                throw new NullReferenceException("Массив не задан");
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return int.MinValue;
            //С каждой итерацией список делится пополам
            //0-я итерация: n
            //1-я итерация: n/2
            //2-я итерация: n/4
            //...
            //i-я итерация: n/2^i
            //n-я итерация: 1
            //т.е. для нахождения на какой итерации мы получим решение надо решить уравнение 1=n/2^i или же 2^i=n
            //отсюда получаем i = log2(n) 
            //асимптотическая сложность для бинарного поиска равна log(n) 
        }
    }
}
