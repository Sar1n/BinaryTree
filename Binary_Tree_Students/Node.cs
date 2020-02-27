using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree_Students
{
	public partial class Tree<T> where T : IComparable
	{
		public class Node : IEnumerable
		{
			public T Data { get; set; }
			public Node()
			{
				Data = default;
				LeftNode = null;
				RightNode = null;
			}
			public Node(T data)
			{
				Data = data;
				LeftNode = null;
				RightNode = null;
			}
			public Node ParentNode { get; set; }
			public Node LeftNode { get; set; }
			public Node RightNode { get; set; }
			
			public override string ToString()
			{
				return Data.ToString();
			}
			public IEnumerator GetEnumerator()
			{
				yield return Data;
				if (LeftNode != null)
				{
					foreach (var x in LeftNode)
					{
						yield return x;
					}
				}
				if (RightNode != null)
				{
					foreach (var x in RightNode)
					{
						yield return x;
					}
				}
			}
		}
	}
}
 