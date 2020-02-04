using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
	class Program
	{
		static void Main()
		{
			App app = new App();
			Console.WriteLine(app.StartFibro(50));
			Console.WriteLine(app.Fibo3(50));
		}
	}

	class App
	{
		long[] fiboRemb;
		Dictionary<long, long> fibRemb = new Dictionary<long, long>();
		

		public long StartFibro(long numb)
		{
			fiboRemb = new long[numb + 1];
			return Fibro2(numb);
		}

		long Fibro2(long numb)
		{
			if(fiboRemb[numb] != 0)
			{
				return fiboRemb[numb];
			}
			else if(numb <= 2)
			{
				fiboRemb[numb] = 1;
				return 1;
			}
			long returnValue = Fibro2(numb - 1) + Fibro2(numb - 2);
			fiboRemb[numb] = returnValue;
			return returnValue;
		}

		public long Fibo3(long numb)
		{
			if (fibRemb.ContainsKey(numb))
			{
				return fibRemb[numb];
			}
			else if (numb <= 2)
			{
				fibRemb[numb] = 1;
				return 1;
			}
			long returnValue = Fibro2(numb - 1) + Fibro2(numb - 2);
			fibRemb[numb] = returnValue;
			return returnValue;
		}

		public int Fibro(int numb)
		{
			if(numb == 1 || numb == 2)
			{
				return 1;
			}
			return Fibro(numb - 1) + Fibro(numb - 2);
		}
	}
}
