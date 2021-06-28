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
                for (int i = 0; i < list.Count; i++)
                {
                    bw.Write(list[i]);
                }
            }
            list.Sort();
            using (BinaryWriter bw = new BinaryWriter(File.Create(fileSort)))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    bw.Write(list[i]);
                }
            }
        }
    }
}
