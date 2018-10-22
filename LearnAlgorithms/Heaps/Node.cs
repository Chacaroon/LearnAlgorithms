using System;
using System.Collections.Generic;
using System.Text;

namespace LearnAlgorithms.Heaps
{
	class Node<T>
	{
		public T Value { get; set; }

		public Node<T> ParentNode { get; private set; }

		public Node<T> LeftNextNode { get; private set; }
		public Node<T> RightNextNode { get; private set; }

		public Node() { }

		public Node(T value)
		{
			Value = value;
		}

		public void AttachLeft(Node<T> node)
		{
			if (node == null)
			{
				LeftNextNode = null;
				return;
			}

			LeftNextNode = node;
			node.ParentNode = this;
		}

		public void AttachRight(Node<T> node)
		{
			if (node == null)
			{
				RightNextNode = null;
				return;
			}

			RightNextNode = node;
			node.ParentNode = this;
		}

		public void DetachParent()
		{
			if (ParentNode == null) return;

			if (ParentNode.RightNextNode == this)
				ParentNode.RightNextNode = null;

			if (ParentNode.LeftNextNode == this)
				ParentNode.LeftNextNode = null;

			ParentNode = null;
		}
	}
}
