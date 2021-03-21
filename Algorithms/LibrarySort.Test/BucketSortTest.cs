using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LibrarySort.Test
{
    [TestClass]
    public class BucketSortTest
    {
        Random rnd = new Random();
        int[] array;
        int[] sortArray;
        [TestInitialize]
        public void Setup()
        {
            int n = 10000;
            array = new int[n];
            sortArray = new int[n];
            for (int i = 0; i < array.Length; i++)
            {
                var num = rnd.Next(array.Length);
                array[i] = num;
                sortArray[i] = num;
            }
            Array.Sort(sortArray);
        }

        [TestMethod]
        public void TestBucketSort_norm()
        {
            var expected = sortArray;
            var actual = Sorts.BucketSort(array, 100);
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestBucketSort_null()
        {
            int[] expected = null;
            var actual = Sorts.BucketSort(expected, 100);
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestBucketSort_ExpectedException()
        {
            var expected = sortArray;
            var actual = Sorts.BucketSort(array, -0);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
