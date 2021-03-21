using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySort;

namespace Les8Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 100000;
            string fileName = "file.txt";
            string referenceFile = "referenceFile.txt";
            string sortFile = "sortFile.txt";

            if (File.Exists(fileName)) File.Delete(fileName);
            if (File.Exists(referenceFile)) File.Delete(referenceFile);
            if (File.Exists(sortFile)) File.Delete(sortFile);

            Generator(fileName, referenceFile, 1000000);

            Sorts.ExternalSort(fileName, sortFile,  size);
            Console.ReadKey();
        }

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
        private static void WriteFile(string fileName, List<int> buffer)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            for (int i = 0; i < buffer.Count; i++)
                bw.Write(buffer[i]);
            fs.Close();
        }
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

        static void Merge(List<string> liseTempFile, string outputFile)
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
            FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            while (tempArr.Count !=0 )
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

        private static int GetMinValue(List<int> tempArr, out int index)
        {
            int min = tempArr.Min();
            index = tempArr.FindIndex(x => x == min);
            return min;
        }

       
        public static void Generator(string file, string fileSort, int count) 
        {
            List<int> list = new List<int>(count);

            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                list.Add(rnd.Next(count));
            }
            using (BinaryWriter bw = new BinaryWriter(File.Create(file)))
            {
                //FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write);
                //BinaryWriter bw = new BinaryWriter(fs);
                for (int i = 0; i < list.Count; i++)
                {
                    bw.Write(list[i]);
                }
                //fs.Close();
            }
            list.Sort();
            using (BinaryWriter bw = new BinaryWriter(File.Create(fileSort)))
            {
                //fs = new FileStream("Sort" + file, FileMode.Create, FileAccess.Write);
                //bw = new BinaryWriter(fs);
                for (int i = 0; i < list.Count; i++)
                {
                    bw.Write(list[i]);
                }
                //fs.Close();
            }
            //using (BinaryWriter bw = new BinaryWriter(File.Create(file)))
            //{
            //    Random rnd = new Random();
            //    for (int i = 0; i < count; i++)
            //    {
            //        bw.Write(rnd.Next(count));
            //    }
            //}
        }

    }
}
