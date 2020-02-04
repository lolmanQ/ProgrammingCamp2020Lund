using System;
using System.Collections.Generic;

namespace Random_for_maffia
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
		public List<Person> people = new List<Person>();
		public List<string> rollList = new List<string>();

		Random rnd = new Random();

		public void Run()
		{
			Input();
			Go();
			Output();
		}

		void Input()
		{
			string nameString = Console.ReadLine();
			string rolls = Console.ReadLine();
			string[] nameArray = nameString.Split(' ');
			string[] tempRollsArray = rolls.Split(' ');
			foreach(string name in nameArray)
			{
				people.Add(new Person(name));
			}

			foreach (string item in tempRollsArray)
			{
				rollList.Add(item);
			}
		}

		void Go()
		{
			foreach (Person person in people)
			{
				int randomIndex = rnd.Next(0, rollList.Count - 1);
				person.role = rollList[randomIndex];
				rollList.RemoveAt(randomIndex);
			}
		}

		void Output()
		{
			foreach(Person person in people)
			{
				Console.Clear();
				Console.WriteLine(person.name);
				Console.ReadLine();
				Console.WriteLine(person.role);
				Console.ReadLine();
			}
			Console.WriteLine("Gud tid");
			foreach (Person person in people)
			{
				Console.WriteLine("-------");
				Console.WriteLine(person.name);
				Console.WriteLine(person.role);
			}
		}
	}

	class Person
	{
		public string name;
		public string role;

		public Person(string name)
		{
			this.name = name;
		}
	}
}
