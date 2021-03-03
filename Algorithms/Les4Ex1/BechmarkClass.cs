using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using System.Text;
using System;

namespace Les4Ex1
{
    public class BechmarkClass
    {
        public static Random rnd = new Random(100);
        public static int n = 1000;
        public static string[] stringArray = new string[10000];
        public static string rndString;
        public static HashSet<string> hashSet = new HashSet<string>();

        static BechmarkClass()
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                stringArray[i] = GetRandomString();
                hashSet.Add(GetRandomString());
            }
            rndString = GetRandomString();
        }

        public static string GetRandomString()
        {
            int Length = rnd.Next(100);
            string rndStr = "";
            for (int i = 0; i < Length; i++)
            {
                rndStr += rnd.Next(97, 122).ToString();
            }
            return rndStr.ToString();
        }
        /// <summary>
        /// Поиск перебором по массиву
        /// </summary>
        /// <param name="stringArray"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ContainsString(string[] stringArray, string str)
        {
            foreach (var item in stringArray)
            {
                if (item == str) return true;
            }
            return false;
        }

        /// <summary>
        /// Метод для теста PointDistanceClass
        /// </summary>
        [Benchmark]
        public void TestContainsString()
        {
            for (int i = 0; i < n; i++)
            {
                ContainsString(stringArray, rndString);
            }
        }
        /// <summary>
        /// Метод для теста PointDistanceClass
        /// </summary>
        [Benchmark]
        public void TestContainsHashSet()
        {
            for (int i = 0; i < n; i++)
            {
                hashSet.Contains(rndString);
            }
        }
    }
}
