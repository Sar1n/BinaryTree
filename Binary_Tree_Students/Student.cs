using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree_Students
{
	public class Student : IComparable
	{
		string Name { get; set; }
		string TestTitle { get; set; }
		DateTime Date { get; set; }
		int Grade { get; set; }
		public Student(string name, string title, DateTime date, int grade)
		{
			Name = name;
			TestTitle = title;
			Date = date;
			Grade = grade;
		}
		public int CompareTo(object obj)
		{
			if (obj == null)
				throw new StudentComparingException("Argument is null");
			Student stud = obj as Student;
			if(stud as Student == null)
				throw new StudentComparingException("Argument is not Student type");
			if (Grade >= stud.Grade)
				return 1;
			else 
				if (Grade < stud.Grade)
					return -1;
				else
					if ((Name == stud.Name) && (TestTitle == stud.TestTitle) && (Date == stud.Date))
						return 0;
					else
						return 1;
		}
		public override string ToString()
		{
			return Name + " scored " + Grade.ToString() + " on test \"" + TestTitle + "\" on " + Date.ToString();
		}
	}
}
