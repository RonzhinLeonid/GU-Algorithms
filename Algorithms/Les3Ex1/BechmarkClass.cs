using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Les3Ex1
{
    public class BechmarkClass
    {
        public static int n = 1;
        public static PointClass[] pointsClassFirst = new PointClass[n];
        public static PointClass[] pointsClassSecond = new PointClass[n];

        public static PointStruct[] pointsStructFirst = new PointStruct[n];
        public static PointStruct[] pointsStructSecond = new PointStruct[n];

        static BechmarkClass()
        { 
            Random rnd = new Random(100);
            for (int i = 0; i<n; i++)
            {
                pointsClassFirst[i] = new PointClass() { X = rnd.Next(100), Y = rnd.Next(100) };
                pointsClassSecond[i] = new PointClass() { X = rnd.Next(100), Y = rnd.Next(100) };

                pointsStructFirst[i] = new PointStruct() { X = rnd.Next(100), Y = rnd.Next(100) };
                pointsStructSecond[i] = new PointStruct() { X = rnd.Next(100), Y = rnd.Next(100) };
            } 
        }
        /// <summary>
        /// Обычный метод расчёта дистанции со ссылочным типом (PointClass — координаты типа float).
        /// </summary>
        /// <param name="pointOne"></param>
        /// <param name="pointTwo"></param>
        /// <returns></returns>
        public static float PointDistanceClass(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        /// <summary>
        /// Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа float).
        /// </summary>
        /// <param name="pointOne"></param>
        /// <param name="pointTwo"></param>
        /// <returns></returns>
        public static float PointDistanceStruct(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        /// <summary>
        /// Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа double).
        /// </summary>
        /// <param name="pointOne"></param>
        /// <param name="pointTwo"></param>
        /// <returns></returns>
        public static double PointDistanceDouble(PointStruct pointOne, PointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        /// <summary>
        /// Метод расчёта дистанции без квадратного корня со значимым типом (PointStruct — координаты типа float).
        /// </summary>
        /// <param name="pointOne"></param>
        /// <param name="pointTwo"></param>
        /// <returns></returns>
        ///
        public static float PointDistanceWithoutSqrt(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return fsrt((x * x) + (y * y));
        }
        /// <summary>
        /// Метод расчета корня без использования Math.Sqrt
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public static float fsrt(float z)
        {
            if (z == 0) return 0;
            FloatIntUnion u;
            u.i = 0;
            u.f = z;
            u.i -= 1 << 23; /* Subtract 2^m. */
            u.i >>= 1; /* Divide by 2. */
            u.i += 1 << 29; /* Add ((b + 1) / 2) * 2^m. */
            return u.f;
        }
        /// <summary>
        /// Метод для теста PointDistanceClass
        /// </summary>
        [Benchmark]
        public void TestPointDistanceClass()
        {
            for (int i = 0; i < n; i++)
            {
                PointDistanceClass(pointsClassFirst[i], pointsClassSecond[i]); 
            }
        }
        /// <summary>
        /// Метод для теста PointDistanceStruct
        /// </summary>
        [Benchmark]
        public void TestPointDistanceStruct()
        {
            for (int i = 0; i < n; i++)
            {
                PointDistanceStruct(pointsStructFirst[i], pointsStructSecond[i]);
            }
        }
        /// <summary>
        /// Метод для теста PointDistanceDouble
        /// </summary>
        [Benchmark]
        public void TestPointDistanceDouble()
        {
            for (int i = 0; i < n; i++)
            {
                PointDistanceDouble(pointsStructFirst[i], pointsStructSecond[i]);
            }
        }
        /// <summary>
        /// Метод для теста PointDistanceWithoutSqrt
        /// </summary>
        [Benchmark]
        public void TestPointDistanceWithoutSqrt()
        {
            for (int i = 0; i < n; i++)
            {
                PointDistanceWithoutSqrt(pointsStructFirst[i], pointsStructSecond[i]);
            }
        }
    }
}
