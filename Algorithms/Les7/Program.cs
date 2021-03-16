using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les7
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 8;
            int n = 8;
            GetCountWay(GetMap(n, m, false));
            Console.WriteLine();
            GetCountWay(GetMap(n, m, true));

            Console.ReadLine();
        }
        /// <summary>
        /// Создание карты препятствий
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="wall">false если препятствий не должно быть</param>
        /// <returns></returns>
        private static int[,] GetMap(int n, int m, bool wall)
        {
            int[,] arr = new int[n, m];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (wall)
                    {
                        int temp = rnd.Next(0, 100);
                        if (temp < 10) arr[i, j] = 0;
                        else arr[i, j] = 1;
                    }
                    else arr[i, j] = 1;
                }
            }
            Console.WriteLine("Карта:");
            Print(arr);
            return arr; 
        }
        /// <summary>
        /// Получение матрицы путей
        /// </summary>
        /// <param name="map">Карта препятствий</param>
        private static void GetCountWay(int[,] map)
        {
            int n = map.GetLength(0);
            int m = map.GetLength(1);

            int[,] arr = new int[n, m];
            //Заполнение 1й строки
            for (int i = 0; i < m; i++)
            {
                if (map[0, i] == 1) arr[0, i] = 1;
                else
                {
                    for (int j = i; j < m; j++)
                        arr[0, j] = 0;
                    break;
                }
            }
            //Заполнение 1го стобца
            for (int i = 0; i < n; i++)
            {
                if (map[i, 0] == 1) arr[i, 0] = 1;
                else
                {
                    for (int j = i; j < m; j++)
                        arr[j, 0] = 0;
                    break;
                }
            }


            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (map[i, j] == 1) arr[i, j] = arr[i, j - 1] + arr[i - 1, j];
                    else arr[i, j] = 0;
                }
            }
            Console.WriteLine("Количество путей:");
            Print(arr);
        }
        /// <summary>
        /// Вывод массива в консоль
        /// </summary>
        /// <param name="array"></param>
        public static void Print(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j],4} ");
                }
                Console.WriteLine();
            }

        }
    }
}
