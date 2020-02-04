using System;
using System.Collections.Generic;

namespace tempTest
{
	class Program
	{
		public static void Main()
		{
			App app = new App();
			app.Start();
		}
	}
	
	class App
	{
		int[,] orderArray = new int[3,3];
		List<Pos> posOrder = new List<Pos>();
		double totalDistens = 0;
		public void Start(){
			Input();
			MakePosList();
			for (int i = 1; i < 9; i++)
			{
				totalDistens += CalcDist(posOrder[i], posOrder[i - 1]);
			}
			Console.WriteLine(totalDistens);
		}

		void Input(){
			for (int i = 0; i < 3; i++)
			{
				string inputString = Console.ReadLine();
				string[] splitInputString = inputString.Split(' ');
				List<int> rowList = new List<int>();
				foreach (string item in splitInputString)
				{
					rowList.Add(int.Parse(item));
				}
				for (int j = 0; j < rowList.Count; j++)
				{
					orderArray[i, j] = rowList[j];
				}
			}
		}

		void MakePosList()
		{
			while (posOrder.Count <= 9)
			{
				for (int c = 1; c <= 9; c++)
				{
					posOrder.Add(Find(c));
				}
			}
		}

		double CalcDist(int point1, int point2)
		{
			return Math.Sqrt(point1 * point1 + point2 * point2);
		}
		double CalcDist(Pos point1, Pos point2)
		{
			int disx = point1.x - point2.x;
			int disy = point1.y - point2.y;
			return Math.Sqrt(disx * disx + disy * disy);
		}

		Pos Find(int value)
		{
			for (int r = 0; r < 3; r++)
			{
				for (int c = 0; c < 3; c++)
				{
					if(orderArray[c,r] == value)
					{
						return new Pos(c, r);
					}
				}
			}
			return new Pos(-1, -1);
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
}
