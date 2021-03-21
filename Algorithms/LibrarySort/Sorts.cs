using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySort
{
    public static class Sorts
    {/// <summary>
     /// Блочная сортировка 
     /// </summary>
     /// <param name="array">Массив</param>
     /// <param name="n">Размер корзины</param>
     /// <returns></returns>
        public static int[] BucketSort(int[] array, int n)
        {
            if (array == null)
                return null;
            if (n <= 0) throw new Exception("Размер корзин задан неверно");

            int maxValue = array[0];
            int minValue = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                    maxValue = array[i];

                if (array[i] < minValue)
                    minValue = array[i];
            }
            var count = (maxValue - minValue) / n + 1;
            List<List<int>> buckets = new List<List<int>>();
            for (int i = 0; i < count; i++)
                buckets.Add(new List<int>());

            for (int i = 0; i < array.Length; i++)
            {
                buckets[array[i] / n].Add(array[i]);
            }

            for (int i = 0; i < buckets.Count; i++)
            {
                buckets[i].Sort();
            }
            var sortArray = new List<int>();
            for (int i = 0; i < buckets.Count; i++)
            {
                sortArray.AddRange(buckets[i]);
            }
            return sortArray.ToArray();
        }

        /// <summary>
        /// External sort
        /// </summary>
        /// <param name="array"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static void ExternalSort(string fileName, string fileSort, int size)
        {
            if (!File.Exists(fileName)) throw new InvalidOperationException("Нет исходного файла.");
            if (File.Exists(fileSort)) File.Delete(fileSort);

            List<string> liseTempFile = new List<string>();

            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[size];
            int count = 1;
            while (fileStream.Read(buffer, 0, size) > 0)
            {
                string tempFileName = $"temp{count++}.txt";
                CreateFile(tempFileName, buffer);
                liseTempFile.Add(tempFileName);
            }

            foreach (var item in liseTempFile)
            {
                var temp = ReadFile(item);
                temp.Sort();
                WriteFile(item, temp);
            }
            Merge(liseTempFile, fileSort);
            CleanAfterWork(liseTempFile);
        }
        /// <summary>
        /// Удаление временных файлов после сортировки
        /// </summary>
        /// <param name="liseTempFile"></param>
        private static void CleanAfterWork(List<string> liseTempFile)
        {
            if (liseTempFile.Count <= 0)
                throw new InvalidOperationException("Нет временных файлов.");

            for (var i = 0; i < liseTempFile.Count; i++)
            {
                if (File.Exists(liseTempFile[i]))
                    File.Delete(liseTempFile[i]);
            }
        }
        /// <summary>
        /// Чтение файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static List<int> ReadFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            List<int> temp = new List<int>();
            for (int i = 0; i < fs.Length / sizeof(int); i++)
                temp.Add(br.ReadInt32());
            fs.Close();
            return temp;
        }
        /// <summary>
        /// Создание/Запись файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="buffer"></param>
        private static void WriteFile(string fileName, List<int> buffer)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            for (int i = 0; i < buffer.Count; i++)
                bw.Write(buffer[i]);
            fs.Close();
        }
        /// <summary>
        /// Создание буферного файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="buffer"></param>
        public static void CreateFile(string fileName, byte[] buffer)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            for (int i = 0; i < buffer.Length; i++)
            {
                bw.Write(buffer[i]);
            }
            fs.Close();
        }
        /// <summary>
        /// Слияние файлов в один
        /// </summary>
        /// <param name="liseTempFile">Список файлов</param>
        static void Merge(List<string> liseTempFile, string fileSort)
        {
            if (liseTempFile.Count <= 0)
                throw new InvalidOperationException("Нет временных файлов.");
            List<Queue> listQueue = new List<Queue>();

            foreach (var item in liseTempFile)
                listQueue.Add(new Queue(ReadFile(item)));

            List<int> tempArr = new List<int>();

            for (int i = 0; i < listQueue.Count; i++)
            {
                tempArr.Add((int)listQueue[i].Dequeue());
            }
            FileStream fs = new FileStream(fileSort, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            while (tempArr.Count != 0)
            {
                int index;
                int value = GetMinValue(tempArr, out index);
                bw.Write(value);

                if (listQueue[index].Count != 0)
                    tempArr[index] = (int)listQueue[index].Dequeue();
                else
                {
                    listQueue.RemoveAt(index);
                    tempArr.RemoveAt(index);
                }

            }
            fs.Close();
        }
        /// <summary>
        /// Получить минимальное значение из массива
        /// </summary>
        /// <param name="tempArr">массив</param>
        /// <param name="index">индекс</param>
        /// <returns></returns>
        private static int GetMinValue(List<int> tempArr, out int index)
        {
            int min = tempArr.Min();
            index = tempArr.FindIndex(x => x == min);
            return min;
        }
    }
}
