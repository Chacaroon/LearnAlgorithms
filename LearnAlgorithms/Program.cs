using System;

namespace LearnAlgorithms.Lists
{
	class Program
	{
		static void Main(string[] args)
		{
			Random random = new Random();

			Queue<int> queue = new Queue<int>();

			for (int i = 0; i < 10000; i++)
			{
				queue.Enqueue(random.Next(1, 10000));
			}

			Console.WriteLine(queue.Deqeue());

			Console.WriteLine(queue.Deqeue());

			Console.WriteLine(queue.Deqeue());
			
			Console.Read();
		}
	}
}
