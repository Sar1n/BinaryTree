using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binary_Tree_Students;

namespace UnitTestTree
{
	[TestClass]
	public class UnitTestBinaryTree
	{
		[TestMethod]
		public void AddingElementToATreeShouldAddNewNodeCorrectly()
		{
			//arrange
			Tree<int> MyTree = new Tree<int>();
			string expected = "5 4 3 6 45 7 ";
			MyTree.Add(5);
			MyTree.Add(4);
			MyTree.Add(3);
			MyTree.Add(6);
			MyTree.Add(45);
			MyTree.Add(7);
			//act
			string actual = MyTree.ToString();
			//assert
			Assert.AreEqual(expected, actual, false, "Tree is not composing correctly.");
		}

		[TestMethod]
		public void CallingTreeNumeratorSholdReturnCorrectValuesInCorrectOrder()
		{
			//arrange
			Tree<int> MyTree = new Tree<int>();
			string expected = "5 4 3 6 45 7 ";
			MyTree.Add(5);
			MyTree.Add(4);
			MyTree.Add(3);
			MyTree.Add(6);
			MyTree.Add(45);
			MyTree.Add(7);
			//act
			string actual = "";
			foreach (var x in MyTree)
			{
				actual = actual + x.ToString() + " ";
			}
			//assert
			Assert.AreEqual(expected, actual, false, "Numerator isnt working correctly.");
		}

		[DataRow(5, 4, 7, 6, 7)]
		[DataRow(6, 4, 3, 5, 6)]
		[DataRow(5, 4, 7, 6, 4)]
		[DataRow(5, 4, 6, 7, 7)]
		[DataTestMethod]
		public void SearchInTreeShouldReturnTrueAndCorrectValue(int a, int b, int c, int d, int tofind)
		{
			//arrange
			Tree<int> MyTree = new Tree<int>();
			string expected = tofind.ToString();
			MyTree.Add(a);
			MyTree.Add(b);
			MyTree.Add(c);
			MyTree.Add(d);
			//act
			string actual = "";
			int finded = 0;
			if (MyTree.Search(tofind, ref finded))
				actual = finded.ToString();
			//assert
			Assert.AreEqual(expected, actual, false, "Numerator isnt working correctly.");
		}

		[DataRow(5, 4, 6, 7, 15)]
		[DataTestMethod]
		public void SearchForAbsentItemInTreeShouldReturnFalse(int a, int b, int c, int d, int tofind)
		{
			//arrange
			Tree<int> MyTree = new Tree<int>();
			bool expected = false;
			MyTree.Add(a);
			MyTree.Add(b);
			MyTree.Add(c);
			MyTree.Add(d);
			//act
			int finded = 0;
			bool actual = MyTree.Search(tofind, ref finded);
			//assert
			Assert.AreEqual(expected, actual, "Searching for an item which does not exist in tree returns true value and it isnt ok.");
		}

		[DataRow(15, "8 4 3 5 6 10 9 14 13 11 12 ")]
		[DataRow(8, "9 4 3 5 6 10 14 13 11 12 ")]
		[DataRow(14, "8 4 3 5 6 10 9 13 11 12 ")]
		[DataRow(10, "8 4 3 5 6 11 9 14 13 12 ")]
		[DataRow(4, "8 5 3 6 10 9 14 13 11 12 ")]
		[DataTestMethod]
		public void DeleteMethodShouldDeleteArgumentFromTree(int todelete, string expected)
		{
			//arrange
			Tree<int> MyTree = new Tree<int>();
			MyTree.Add(8);
			MyTree.Add(4);
			MyTree.Add(3);
			MyTree.Add(5);
			MyTree.Add(6);
			MyTree.Add(10);
			MyTree.Add(9);
			MyTree.Add(14);
			MyTree.Add(13);
			MyTree.Add(11);
			MyTree.Add(12);
			//act
			MyTree.DeleteElement(todelete);
			string actual = MyTree.ToString();
			//assert
			Assert.AreEqual(expected, actual, false, "Method DeleteElement does not deleting items correctly.");
		}

		[DataRow(8)]
		[DataRow(4)]
		[DataRow(12)]
		[DataRow(14)]
		[DataRow(5)]
		[DataRow(3)]
		[DataRow(6)]
		[DataRow(10)]
		[DataRow(11)]
		[DataTestMethod]
		public void SearchMethodShouldReturnCorrectValue(int expected)
		{
			//arrange
			Tree<int> MyTree = new Tree<int>();
			MyTree.Add(8);
			MyTree.Add(4);
			MyTree.Add(3);
			MyTree.Add(5);
			MyTree.Add(6);
			MyTree.Add(10);
			MyTree.Add(9);
			MyTree.Add(14);
			MyTree.Add(13);
			MyTree.Add(11);
			MyTree.Add(12);
			//act
			int actual = 0;
			MyTree.Search(expected, ref actual);
			//assert
			Assert.AreEqual(expected, actual, "Method Search extracting wrong values.");
		}
	}
}
