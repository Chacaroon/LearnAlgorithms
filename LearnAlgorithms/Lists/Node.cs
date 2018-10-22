using System;
using System.Collections.Generic;
using System.Text;

namespace LearnAlgorithms.Lists
{
	class Node<T>
	{
		public T Value { get; set; }

		public Node<T> NextNode { get; set; }

		public Node() { }

		public Node(T value)
		{
			Value = value;
		}

		public Node(T value, Node<T> nextNode)
			: this(value)
		{
			NextNode = nextNode;
		}
	}
}
