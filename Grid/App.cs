using System;
using System.Collections.Generic;
using System.Text;

namespace Grid
{
	class App
	{
		public int height;
		public int width;

		public int[,] gridArray;

		public void Run()
		{
			Input();
			Go();
			Help.Print(gridArray);

		}

		public void Input()
		{
			string dimationString = Console.ReadLine();
			string[] splitstring = dimationString.Split(' ');
			height = int.Parse(splitstring[0]);
			width = int.Parse(splitstring[1]);
			gridArray = new int[width, height];

			for (int i = 0; i < height; i++)
			{
				string tempRow = Console.ReadLine();
				for (int i2 = 0; i2 < width; i2++)
				{
					gridArray[i2, i] = int.Parse(tempRow[i2].ToString());
				}
			}
		}

		public void NodeGenerator()
		{
			
		}

		public void Go()
		{
			
		}
	}

	class Node
	{
		public Pos pos;
		public int Value { get; set; }
		public List<int> NeighboursIndex { get; set; }

		public Node(List<int> neighboursIndex)
		{
			NeighboursIndex = neighboursIndex;
		}

	}

	class Pos
	{
		public int x;
		public int y;

		public Pos(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	class Help
	{
		public static void Print(int[,] array)
		{
			for (int y = 0; y < array.GetLength(1); y++)
			{
				string buffer = "";
				for (int x = 0; x < array.GetLength(0); x++)
				{
					buffer += array[x, y] + "";
				}
				Console.WriteLine(buffer);
			}
		}
	}
}
