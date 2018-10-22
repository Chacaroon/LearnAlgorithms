using LearnAlgorithms.Heaps;
using System;

namespace LearnAlgorithms.Lists
{
	class Program
	{
		static void Main(string[] args)
		{
			Heap<int> heap = new Heap<int>();

			DateTime startTime = DateTime.Now;

			for (int i = 0; i < 10000; i++)
			{
				heap.Add(i);
			}

			for (int i = 0; i < 10000; i++)
			{
				heap.Get();
			}

			DateTime endtTime = DateTime.Now;

			Console.WriteLine("Program has been runnung for {0} seconds", (endtTime - startTime).Seconds);
			GC.GetTotalMemory(true);
			Console.Read();
		}
	}
}
