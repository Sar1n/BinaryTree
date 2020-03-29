using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree_Students
{
	public partial class Tree<T> : IEnumerable where T : IComparable
	{
		public Node Root { get; set; }
		private bool rootset = false;
		public delegate void EventDelegate(string message); //Делегат для вывода сообщения о событии
		public event EventDelegate Acknowledgement;
		public Tree() //Инициализация дерева без параметров
		{
			Root = default;
		}
		public Tree(T root) //Инициализация дерева значением корня
		{
			Root = new Node(root);
			rootset = true;
		}
		public Tree(List<T> elements) //Инициализация дерева списком значений
		{
			if (elements.Any() != false)
				foreach (T t in elements)
					Add(t);
		}
		public override string ToString()
		{
			string consoletree = "";

			return consoletree;
		}
		public void NLR(ref string res) //Не рекурсивный метод для удобного вызова прямого обхода дерева
		{
			if (Root != null)
			{
				NLRRec(ref res, Root);
			}
			else
			{
				res = "Root is Null";
			}
		}
		private void NLRRec(ref string res, Node currentelement) //Рекурсивный метод для прямого обхода дерева
		{
			if (currentelement != null)
			{
				res += currentelement.Data.ToString() + " ";
				NLRRec(ref res, currentelement.LeftNode);
				NLRRec(ref res, currentelement.RightNode);
			}
		}
		public void Add(T newelement) //Добавление узла в дерево
		{
			if (!rootset)
			{
				Root = new Node(newelement);
				rootset = true;
			}
			else
			{
				AddRec(Root, newelement);
			}
			Acknowledgement?.Invoke("New element was added: " + newelement.ToString());
		}
		private void AddRec(Node currentelement, T newelement) //Рекурсивыный метод для добавления узла в дерево
		{
			if (currentelement.Data.CompareTo(newelement) <= 0)
			{
				if (currentelement.RightNode != null)
				{
					AddRec(currentelement.RightNode, newelement);
				}
				else
				{
					currentelement.RightNode = new Node(newelement);
					currentelement.RightNode.ParentNode = currentelement;
				}
			}
			else
			{
				if (currentelement.LeftNode != null)
				{
					AddRec(currentelement.LeftNode, newelement);
				}
				else
				{
					currentelement.LeftNode = new Node(newelement);
					currentelement.LeftNode.ParentNode = currentelement;
				}
			}
		}
		public bool Search(T value, ref T FindedValue) //Поиск значения в дереве
		{
			if (Root != null)
			{
				Node Find = default;
				RecSearch(Root, value, ref Find);
				if (Find != null)
				{
					FindedValue = Find.Data;
					return true;
				}
				else
					return false;
			}
			else
			{
				throw new RootIsNullException("Root is null");
			}
		}
		private void RecSearch(Node currentelement, T ToFind, ref Node Find) //Рекурсивный метод для поиска в дереве
		{
			if (currentelement != null)
				if (currentelement.Data.CompareTo(ToFind) > 0)
					RecSearch(currentelement.LeftNode, ToFind, ref Find);
				else
				{
					if (currentelement.Data.CompareTo(ToFind) < 0)
						RecSearch(currentelement.RightNode, ToFind, ref Find);
					else
						Find = currentelement;
				}
		}
		public IEnumerator GetEnumerator()
		{
			return Root.GetEnumerator();
		}
		public bool DeleteElement(T ToDelete)
		{
			bool isRoot;
			if (Root.Data.CompareTo(ToDelete) != 0)
				isRoot = false;
			else
				isRoot = true;
			Node Find = default;
			RecSearch(Root, ToDelete, ref Find);
			if (Find != null)
			{
				if (Find.RightNode == null) //Случай 1: У удаляемого узла нет правого ребенка
				{
					if (Find.LeftNode != null) // Если есть левый узел
					{
						if (!isRoot) //Удаляемый элемент - не корень
						{
							if (Find.ParentNode.LeftNode != null) // Если у родительского узла есть левый узел
								if (Find.ParentNode.LeftNode.Data.CompareTo(Find.Data) == 0) // Удаляемый узел - Левый
								{
									Find.ParentNode.LeftNode = Find.LeftNode; //Заменяем дочерний элемент у родителя
									Find.LeftNode.ParentNode = Find.ParentNode; //Заменяем родительский элемент
								}
							if (Find.ParentNode.RightNode != null) // Если у родительского узла есть правый узел                     
								if (Find.ParentNode.RightNode.Data.CompareTo(Find.Data) == 0) // Удаляемый узел - Правый
								{
									Find.ParentNode.RightNode = Find.LeftNode; //Заменяем дочерний элемент у родителя
									Find.LeftNode.ParentNode = Find.ParentNode; //Заменяем родительский элемент
								}
						}
						else //Удаляемый элемент - корень
						{
							Root = Find.LeftNode;
							Root.ParentNode = default;
						}
					}
					else // Если нет дочерних узлов
					{
						if (!isRoot) //Удаляемый элемент - не корень
						{
							if (Find.ParentNode.LeftNode != null) // Если у родительского узла есть левый узел
								if (Find.ParentNode.LeftNode.Data.CompareTo(Find.Data) == 0) // Удаляемый узел - Левый
									Find.ParentNode.LeftNode = default; //Обнуляем дочерний элемент у родителя
							if (Find.ParentNode.RightNode != null) // Если у родительского узла есть правый узел                     
								if (Find.ParentNode.RightNode.Data.CompareTo(Find.Data) == 0) // Удаляемый узел - Правый
									Find.ParentNode.RightNode = Find.LeftNode; //Обнуляем дочерний элемент у родителя
						}
						else //Удаляемый элемент - корень
							Root = default; //Обнуляем корень
					}
					return true;
				}
				else
				if (Find.RightNode.LeftNode == null) //Случай 2: У удаляемого узла есть правый ребенок, у которого, в свою очередь нет левого ребенка
				{
					if (Find.LeftNode != null) //Если есть левое поддерево
						Find.RightNode.LeftNode = Find.LeftNode; //То перемещаем его на лево правого поддерева
					if (!isRoot) //Удаляемый элемент - не корень
					{
						if (Find.ParentNode.LeftNode != null) // Если у родительского узла есть левый узел
							if (Find.ParentNode.LeftNode.Data.CompareTo(Find.Data) == 0) // Удаляемый узел - Левый
							{
								Find.ParentNode.LeftNode = Find.RightNode; //Заменяем дочерний элемент у родителя
								Find.LeftNode.ParentNode = Find.ParentNode; //Заменяем родительский элемент
							}
						if (Find.ParentNode.RightNode != null) // Если у родительского узла есть правый узел
							if (Find.ParentNode.RightNode.Data.CompareTo(Find.Data) == 0) // Удаляемый узел - Правый
							{
								Find.ParentNode.RightNode = Find.RightNode; //Заменяем дочерний элемент у родителя
								Find.RightNode.ParentNode = Find.ParentNode; //Заменяем родительский элемент
							}
					}
					else //Удаляемый элемент - корень
					{
						Root = Find.RightNode;
						Root.ParentNode = default;
					}
					return true;
				}
				else //Случай 3: У удаляемого узла есть правый ребенок, у которого есть левый ребенок
				{
					Node FarLeft = default;
					GiveFarLeft(Find.RightNode, ref FarLeft); // Получаем ссылку на самый левый элемент правого поддерева

					if (Find.LeftNode != null)
					{
						FarLeft.LeftNode = Find.LeftNode; //Помещаем левое поддерево удаляемого узла на лево самого левого узла правого поддерева удаляемого элемента
						Find.LeftNode.ParentNode = FarLeft;
					}

					if (!isRoot) //Удаляемый элемент - не корень
					{
						if (Find.ParentNode.LeftNode != null) // Если у родительского узла есть левый узел
							if (Find.ParentNode.LeftNode.Data.CompareTo(Find.Data) == 0) // Удаляемый узел - Левый
								Find.ParentNode.LeftNode = FarLeft; //Заменяем дочерний элемент у родителя
						if (Find.ParentNode.RightNode != null) // Если у родительского узла есть правый узел
							if (Find.ParentNode.RightNode.Data.CompareTo(Find.Data) == 0) // Удаляемый узел - Правый
								Find.ParentNode.RightNode = FarLeft; //Заменяем дочерний элемент у родителя
						FarLeft.ParentNode.LeftNode = default;
						FarLeft.ParentNode = Find.ParentNode;
					}
					else //Удаляемый элемент - корень
					{
						Root = FarLeft;
						FarLeft.ParentNode.LeftNode = default;
						Root.ParentNode = default;
					}
					return true;
				}
			}
			else
				return false;
		}
		private void GiveFarLeft(Node currentelement, ref Node LeftResult) //(Для удаления) Метод для поиска самого левого элемента
		{
			if (currentelement.LeftNode != null)
				GiveFarLeft(currentelement.LeftNode, ref LeftResult);
			else
				LeftResult = currentelement;
		}
		private bool ReplaceElement(Node k)
		{
			return true;
		}
	}
}
