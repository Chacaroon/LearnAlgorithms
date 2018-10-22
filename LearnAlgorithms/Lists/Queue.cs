using System;

namespace LearnAlgorithms.Lists
{
	class Queue<T>
	{
		private Node<T> _first;
		private Node<T> _last;

		public int Length { get; private set; } = 0;

		public void Enqueue(T value)
		{
			Node<T> newNode = new Node<T>(value);

			Length++;

			if (_first == null)
			{
				_first = _last = newNode;
				return;
			}

			_last.NextNode = newNode;
			_last = newNode;

		}

		public T Deqeue()
		{
			if (_first == null) throw new ArgumentOutOfRangeException();

			Length--;

			T value = _first.Value;

			if (_first.NextNode == null)
			{
				_first = _last = null;
				return value;
			}

			_first = _first.NextNode;


			return value;
		}
	}
}
