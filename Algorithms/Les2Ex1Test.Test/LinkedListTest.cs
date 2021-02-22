using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Les2Ex1;

namespace Les2Ex1Test.Test
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void ToString_str()
        {
            int[] array = new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000 };
            LinkedList root = new LinkedList(array);

            string expected = "-100 -55 -25 1 2 4 5 125 300 900 90000 100000";

            Assert.AreEqual(expected, root.ToString());
        }

        [TestMethod]
        public void ToString_null()
        {
            LinkedList root = new LinkedList();
            string expected = "";
            Assert.AreEqual(expected, root.ToString());
        }

        [TestMethod]
        public void AddNode_100()
        {
            int[] array = new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000 };
            LinkedList root = new LinkedList(array);
            int value = 100;
            LinkedList expected = new LinkedList(new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000, 100 });

            root.AddNode(value);
            Assert.AreEqual(expected.ToString(), root.ToString());
        }

        [TestMethod]
        public void AddNode_200()
        {
            LinkedList root = new LinkedList();
            int value = 200;
            LinkedList expected = new LinkedList(new int[] { 200 });

            root.AddNode(value);
            Assert.AreEqual(expected.ToString(), root.ToString());
        }

        [TestMethod]
        public void FindNode_200Returned()
        {
            LinkedList root = new LinkedList(new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 200, 900, 90000, 100000 });
            int value = 200;
            Node expected = new Node() { Value = 200 };

            var actual = root.FindNode(value);
            Assert.AreEqual(expected.Value, actual.Value);
        }

        [TestMethod]
        public void FindNode_nullReturned()
        {
            LinkedList root = new LinkedList(new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000 });
            int value = 200;
            Node expected = null;

            var actual = root.FindNode(value);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetCount_0Returned()
        {
            LinkedList root = new LinkedList();
            var expected = 0;
            Assert.AreEqual(expected, root.GetCount());
        }

        [TestMethod]
        public void GetCount_12Returned()
        {
            LinkedList root = new LinkedList(new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000 });
            var expected = 12;
            Assert.AreEqual(expected, root.GetCount());
        }

        [TestMethod]
        public void AddNodeAfter_mid()
        {
            int[] array = new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000 };
            LinkedList root = new LinkedList(array);
            int value = 100;
            LinkedList expected = new LinkedList(new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 100, 900, 90000, 100000 });
            root.AddNodeAfter(root.FindNode(300), value);
            Assert.AreEqual(expected.ToString(), root.ToString());
        }
        [TestMethod]
        public void AddNodeAfter_end()
        {
            int[] array = new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000 };
            LinkedList root = new LinkedList(array);
            int value = 100;
            LinkedList expected = new LinkedList(new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000, 100 });
            root.AddNodeAfter(root.FindNode(200), value);
            Assert.AreEqual(expected.ToString(), root.ToString());
        }
        [TestMethod]
        public void AddNodeAfter_endNull()
        {
            int[] array = new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000 };
            LinkedList root = new LinkedList(array);
            int value = 100;
            LinkedList expected = new LinkedList(new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000, 100 });
            root.AddNodeAfter(null, value);
            Assert.AreEqual(expected.ToString(), root.ToString());
        }


        [TestMethod]
        public void RemoveNode_index_1()
        {
            int[] array = new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000 };
            LinkedList root = new LinkedList(array);
            string expected = "-100 -25 1 2 4 5 125 300 900 90000 100000";
            int value = 1;
            root.RemoveNode(value);
            Assert.AreEqual(expected.ToString(), root.ToString());
        }

        [TestMethod]
        public void RemoveNode_index_m1()
        {
            int[] array = new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000 };
            LinkedList root = new LinkedList(array);
            string expected = "-100 -55 -25 1 2 4 5 125 300 900 90000 100000";
            int value = -1;
            root.RemoveNode(value);
            Assert.AreEqual(expected.ToString(), root.ToString());
        }

        [TestMethod]
        public void RemoveNode_index_100()
        {
            int[] array = new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000 };
            LinkedList root = new LinkedList(array);
            string expected = "-100 -55 -25 1 2 4 5 125 300 900 90000 100000";
            int value = 100;
            root.RemoveNode(value);
            Assert.AreEqual(expected.ToString(), root.ToString());
        }

        [TestMethod]
        public void RemoveNode_Node_125()
        {
            int[] array = new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000 };
            LinkedList root = new LinkedList(array);
            string expected = "-100 -55 -25 1 2 4 5 300 900 90000 100000";
            int value = 125;
            root.RemoveNode(root.FindNode(value));
            Assert.AreEqual(expected.ToString(), root.ToString());
        }
        [TestMethod]
        public void RemoveNode_Node_100()
        {
            int[] array = new int[] { -100, -55, -25, 1, 2, 4, 5, 125, 300, 900, 90000, 100000 };
            LinkedList root = new LinkedList(array);
            string expected = "-100 -55 -25 1 2 4 5 125 300 900 90000 100000";
            int value = 100;
            root.RemoveNode(root.FindNode(value));
            Assert.AreEqual(expected.ToString(), root.ToString());
        }
    }
}
