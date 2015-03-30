namespace GameFifteen
{
using System;

	class Program
	{
		public const int StartX = 1;
		public const int StartY = 1;

		public static int InputN()
		{
			Console.WriteLine("Enter a positive number ");
			string input = Console.ReadLine();
			int n = 0;
			while (!int.TryParse(input, out n) || n < 0 || n > 100)
			{
				Console.WriteLine("You haven't entered a correct positive number.");
				input = Console.ReadLine();
			}
			return n;
		}

		static void Main(string[] args)
		{
			// i did what i can. Write some unit tests... No big deal.

			int n = InputN();
			Matrix matrix = new Matrix(n);
			Direction direction = new Direction(StartX, StartY);

			matrix.Walk(direction);
			matrix.ToString();

			matrix.Print();
		}
	}
}