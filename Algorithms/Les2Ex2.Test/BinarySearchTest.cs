using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Les2Ex2Library;

namespace Les2Ex2.Test
{
    [TestClass]
    public class BinarySearchTest
    {
        [TestMethod]
        public void BinarySearch_2_1Returned()
        {
            int[] array = new int[] {-100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000,100000 };
            int value = 2;
            int expected = 4;

            int actual = MyClass.BinarySearch(array, value);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearch_125_7Returned()
        {
            int[] array = new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000 };
            int value = 125;
            int expected = 7;

            int actual = MyClass.BinarySearch(array, value);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearch_m100_0Returned()
        {
            int[] array = new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000 };
            int value = -100;
            int expected = 0;

            int actual = MyClass.BinarySearch(array, value);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearch_100000_11Returned()
        {
            int[] array = new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000 };
            int value = 100000;
            int expected = 11;

            int actual = MyClass.BinarySearch(array, value);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearch_1000000_m1Returned()
        {
            int[] array = new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000 };
            int value = 1000000;
            int expected = int.MinValue;

            int actual = MyClass.BinarySearch(array, value);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void BinarySearch_NullArray_ExpectedException()
        {
            int[] array = null;
            int value = 1000000;
            int actual = MyClass.BinarySearch(array, value);
        }

    }
}
