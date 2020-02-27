using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binary_Tree_Students;

namespace UnitTestTree
{
	[TestClass]
	public class UnitTestStudents
	{
		[TestMethod]
		public void StudentToStringMustReturnExpectedString()
		{
			//arragne
			Student TestStudent = new Student("Winnie The Pooh", "Hole Test", DateTime.Parse("01.01.2020"), 95);
			string expected = $"Winnie The Pooh scored 95 on test \"Hole Test\" on 01.01.2020 0:00:00";

			//act
			string actual = TestStudent.ToString();

			//assert
			Assert.AreEqual(expected, actual, false, "The student not converting to string correctly");
		}

		[DataRow("Winnie The Pooh", "Hole Test", 95, "Winnie The Pooh", "Hole Test", 96, -1)]
		[DataRow("Winnie The Pooh", "Hole Test", 95, "Winnie The Pooh", "Hole Test", 94, 1)]
		[DataRow("Winnie The Pooh", "Hole Test", 95, "Winnie The Pooh", "Hole Test", 95, 1)]
		[DataTestMethod]
		public void StudentComparasingMustReturnCorrectAnswer(string studname1, string testname1, int grade1, string studname2, string testname2, int grade2, int expected)
		{
			//arragne
			Student TestStudent1 = new Student(studname1, testname1, DateTime.Parse("01.01.2020"), grade1);
			Student TestStudent2 = new Student(studname2, testname2, DateTime.Parse("01.01.2020"), grade2);

			//act
			int actual = TestStudent1.CompareTo(TestStudent2);

			//assert
			Assert.AreEqual(expected, actual, "The student not converting to string correctly");
		}
	}
}
