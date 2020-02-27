using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binary_Tree_Students;

namespace Binary_tree
{
	class Program
	{
		static void Main(string[] args)
		{
			Tree<int> MyTree = new Tree<int>(5);
			MyTree.Acknowledgement += Aknow;
			Console.WriteLine(MyTree.ToString());
			MyTree.Add(5);
			MyTree.Add(4);
			MyTree.Add(3);
			MyTree.Add(6);
			MyTree.Add(45);
			MyTree.Add(7);

			int ToFind = default;
			if (MyTree.Search(7, ref ToFind))
			{
				Console.WriteLine($"We have found {ToFind}");
			}
			else
				Console.WriteLine("Null eptat");
			
			/*Console.Write(MyTree.Root.ToString());
			Console.Write(MyTree.Root.RightNode.ToString());
			Console.Write(MyTree.Root.LeftNode.ToString());*/
			string t = "";
			MyTree.NLR(ref t);
			Console.WriteLine(t);
			int o = 1;

			foreach (var x in MyTree)
			{
				Console.WriteLine($"Iteration {o} Numerator returned -> " + x.ToString());
				o++;
			}

			if (MyTree.DeleteElement(45))
				Console.WriteLine("Success");
			Console.WriteLine();
			o = 1;

			foreach (var x in MyTree)
			{
				Console.WriteLine($"Iteration {o} Numerator returned -> " + x.ToString());
				o++;
			}

			/*Student teststud = new Student("Winnie The Pooh", "Hole Test", DateTime.Parse("01.01.2020"), 95);
			Console.WriteLine(teststud.ToString());


			Student TestStudent1 = new Student("Winnie The Pooh", "Hole Test", DateTime.Parse("01.01.2020"), 95);
			Student TestStudent2 = new Student("Winnie The Pooh", "Hole Test", DateTime.Parse("01.01.2020"), 95);
			Console.WriteLine(TestStudent1.ToString());
			Console.WriteLine(TestStudent2.ToString());
			Console.WriteLine("Результат теста: " + TestStudent1.CompareTo(TestStudent2).ToString());*/

			Console.ReadKey();
		}
		public static void Aknow(string message)
		{
			Console.WriteLine("Message from event: " + message);
		}
	}
}
