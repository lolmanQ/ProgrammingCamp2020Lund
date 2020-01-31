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
		public void Start(){
			Input();
			Console.WriteLine(orderArray[1,2]);
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
	}
}
