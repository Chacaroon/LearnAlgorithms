using System;
using System.Collections.Generic;
using System.Text;

namespace LearnAlgorithms.Lists
{
	class List<T>
	{
		private Node<T> _first;
		private Node<T> _last;

		public void Add(T value)
		{
			Node<T> node = new Node<T>(value);

			if (_first == null)
			{
				_first = _last = node;
				return;
			}

			_last.NextNode = node;
			_last = node;
		}

		public void Add(Node<T> afterNode, T value)
		{
			if (afterNode == null) throw new ArgumentNullException();

			Node<T> newNode = new Node<T>(value, afterNode.NextNode);
			afterNode.NextNode = newNode;
		}
	}
}
