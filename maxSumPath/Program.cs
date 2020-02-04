using System;
using System.Collections.Generic;
using System.Linq;

namespace maxSumPath
{
	class Program
	{
		static void Main()
		{
			App app = new App();
			app.Run();
		}
	}

	class App
	{
		List<List<int>> store = new List<List<int>>();

		public void Run()
		{
			Input();
			Go();
			Console.WriteLine("value: " + store[0][0]);
		}

		void Input()
		{
			string inputstr = "";
			while (true)
			{
				inputstr = Console.ReadLine();
				if (inputstr == "")
				{
					break;
				}
				List<string> tempLis = inputstr.Split(' ').OfType<string>().ToList();
				List<int> tempIntList = tempLis.Select(int.Parse).ToList();
				store.Add(tempIntList);
			}
		}
		
		void Go()
		{
			for (int i = store.Count - 1; i >= 0; i--)
			{
				for (int j = 0; j < store[i].Count; j++)
				{
					store[i][j] = CalcValueForPos(i, j);
				}
			}
		}

		int CalcValueForPos(int depth, int left)
		{
			if(depth >= store.Count - 1)
			{
				return store[depth][left];
			}
			if(store[depth + 1][left] > store[depth + 1][left + 1])
			{
				return store[depth][left] + store[depth + 1][left];
			}
			else
			{
				return store[depth][left] + store[depth + 1][left + 1];
			}
		}

	}
}
