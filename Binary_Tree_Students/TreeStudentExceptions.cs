using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree_Students
{
	class StudentComparingException : Exception
	{
		public StudentComparingException (string message) : base()
			{
			}
	}
	class RootIsNullException : Exception
	{
		public RootIsNullException(string message) : base()
		{
		}
	}
}
