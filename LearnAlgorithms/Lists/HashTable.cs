using System;
using System.Collections.Generic;
using System.Text;

namespace LearnAlgorithms.Lists
{
	class HashTable<T>
	{
		private List<T>[] nodes = new List<T>[10];

		public void Add(T value)
		{
			int number = value.GetHashCode() % nodes.Length;

			nodes[number].Add(value);
		}


	}
}
