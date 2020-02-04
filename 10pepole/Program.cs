using System;
using System.Collections.Generic;

namespace _10pepole
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
		public int rows;
		public int colums;

		public int amountOfTests;

		public Node[,] gridArray;
		public Queue<Question> questionQueue = new Queue<Question>();
		int CurrentIdNumb = 0;

		public void Run()
		{
			Input();
			Go();
			
		}

		void Input()
		{
			string dimationString = Console.ReadLine();
			string[] splitstring = dimationString.Split(' ');
			rows = int.Parse(splitstring[0]);
			colums = int.Parse(splitstring[1]);
			gridArray = new Node[rows, colums];

			for (int r = 0; r < rows; r++)
			{
				string tempRow = Console.ReadLine();
				for (int c = 0; c < colums; c++)
				{
					gridArray[r, c] = new Node(int.Parse(tempRow[c].ToString()), r, c);
				}
			}

			amountOfTests = int.Parse(Console.ReadLine());

			for (int i = 0; i < amountOfTests; i++)
			{
				string questionString = Console.ReadLine();
				string[] tempArray = questionString.Split(' ');
				questionQueue.Enqueue(new Question(
					int.Parse(tempArray[0])-1,
					int.Parse(tempArray[1])-1,
					int.Parse(tempArray[2])-1,
					int.Parse(tempArray[3])-1
				));
			}
			
		}

		void Go()
		{
			while(questionQueue.Count > 0)
			{
				Question question = questionQueue.Dequeue();
				if(gridArray[question.startR, question.startC].ID == -1)
				{
					CurrentIdNumb++;
					Dfs(gridArray[question.startR, question.startC], CurrentIdNumb);
				}
				if (gridArray[question.startR, question.startC].ID == gridArray[question.endR, question.endC].ID)
				{
					if(gridArray[question.startR, question.startC].Value == 1)
					{
						Console.WriteLine("decimal");
					}
					else
					{
						Console.WriteLine("binary");
					}
				}
				else
				{
					Console.WriteLine("neither");
				}
			}
		}

		void Dfs(Node node, int id)
		{
			node.ID = id;
			node.Visited = true;
			try
			{
				Node nd = gridArray[node.row, node.colum + 1];
				if(nd.Value == node.Value && !nd.Visited)
				{
					Dfs(nd, id);
				}
			}catch(Exception){}

			try
			{
				Node nd = gridArray[node.row, node.colum - 1];
				if (nd.Value == node.Value && !nd.Visited)
				{
					Dfs(nd, id);
				}
			}
			catch (Exception){}

			try
			{
				Node nd = gridArray[node.row + 1, node.colum];
				if (nd.Value == node.Value && !nd.Visited)
				{
					Dfs(nd, id);
				}
			}
			catch (Exception) { }

			try
			{
				Node nd = gridArray[node.row - 1, node.colum];
				if (nd.Value == node.Value && !nd.Visited)
				{
					Dfs(nd, id);
				}
			}
			catch (Exception) { }
		}
	}


	class Node
	{
		public int Value { get; set; }
		public bool Visited { get; set; }
		public int ID { get; set; }

		public int row, colum;

		public Node(int value, int r, int c)
		{
			this.Value = value;
			Visited = false;
			ID = -1;
			row = r;
			colum = c;
		}
	}

	class Question
	{
		public int startR, startC;
		public int endR, endC;

		public Pos start;
		public Pos end;

		public Question(int startR, int startC, int endR, int endC)
		{
			this.startR = startR;
			this.startC = startC;
			this.endR = endR;
			this.endC = endC;
			start = new Pos(startR, startC);
			end = new Pos(endR, endC);
		}
	}

	class Pos
	{
		public int r, c;

		public Pos(int r, int c)
		{
			this.r = r;
			this.c = c;
		}
	}
}
