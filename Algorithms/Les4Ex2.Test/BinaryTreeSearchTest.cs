using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Les4Ex2.Test
{
    [TestClass]
    public class BinaryTreeSearchTest
    {
        [TestMethod]
        public void TestGetFreeNode()
        {
            var expected = new TreeNode { Value = 10};
            var actual = BinaryTreeSearch.GetFreeNode(10);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetRoot_null()
        {
            TreeNode expected = null;
            var temp = new BinaryTreeSearch();
            var actual = temp.GetRoot();
            
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestGetRoot_8()
        {
            var expected = new TreeNode { Value = 8 };
            var temp = new BinaryTreeSearch(new int[] { 8, 4, 10, 1, 3, 5 });
            var actual = temp.GetRoot();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestGetNodeByValue_null()
        {
            TreeNode expected = null;
            var temp = new BinaryTreeSearch(new int[] { 8, 4, 10, 1, 3, 5 });
            var actual = temp.GetNodeByValue(111);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestGetNodeByValue_10()
        {
            var expected = new TreeNode { Value = 10 };
            var temp = new BinaryTreeSearch(new int[] { 8, 4, 10, 1, 3, 5 });
            var actual = temp.GetNodeByValue(10);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestGetSpacing_0()
        {
            var expected = "";
            var actual = BinaryTreeSearch.GetSpacing(0);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestGetSpacing_ExpectedException()
        {
            var actual = BinaryTreeSearch.GetSpacing(-5);
        }
        [TestMethod]
        public void TestGetSpacing_5()
        {
            var expected = "_____";
            var actual = BinaryTreeSearch.GetSpacing(5);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestAddItem()
        {
            var expected = true;

            var expectedTree = new BinaryTreeSearch(new int[] { 8, 4, 10, 1, 3, 5});
            var expectedList = expectedTree.GetTuple();

            var actualTree = new BinaryTreeSearch();
            actualTree.AddItem(8);
            actualTree.AddItem(4);
            actualTree.AddItem(10);
            actualTree.AddItem(1);
            actualTree.AddItem(3);
            actualTree.AddItem(5);
            var actualList = actualTree.GetTuple();
            var actual = actualList.SequenceEqual(expectedList);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestRemoveItem_10()
        {
            var expected = true;

            var expectedTree = new BinaryTreeSearch(new int[] { 8, 4, 1, 3, 5 });
            var expectedList = expectedTree.GetTuple();

            var actualTree = new BinaryTreeSearch(new int[] { 8, 4, 10, 1, 3, 5 });
            actualTree.RemoveItem(10);
            var actualList = actualTree.GetTuple();

            var actual = actualList.SequenceEqual(expectedList);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestRemoveItem_100()
        {
            var expected = true;

            var expectedTree = new BinaryTreeSearch(new int[] { 8, 4, 1, 3, 5 });
            var expectedList = expectedTree.GetTuple();

            var actualTree = new BinaryTreeSearch(new int[] { 8, 4, 1, 3, 5 });
            actualTree.RemoveItem(100);
            var actualList = actualTree.GetTuple();

            var actual = actualList.SequenceEqual(expectedList);
            Assert.AreEqual(expected, actual);
        }
    }
}
