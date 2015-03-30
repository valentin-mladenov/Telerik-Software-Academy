using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
	public class Minesweeper
	{
		//Points Class moved to a different file.

		//no more magic numbers, i hope i catch them all... like pokemons :)
		const int MaximumPoints = 35;
		const int MaximumMines = 15;
		const int NextRandomNumber = 50;
		const int TopPlayers = 6;
		const int FieldRows = 5;
		const int FieldColumns = 10;

		private static readonly Random random = new Random();
		private static readonly List<Points> theBestFive = new List<Points>(TopPlayers);

		static void Main()
		{
			string inputCommand = string.Empty;
			char[,] field = CreateField();
			char[,] mines = CreateMines();
			
			int pointCounter = 0;
			int row = 0;
			int column = 0;
			
			bool isNewGame = true;
			bool isHitMine = false;
			bool isEndGame= false;

			while (inputCommand != "exit") //remove the 'do' part
			{
				if (isNewGame)
				{
					Console.WriteLine("Game “Minesweeper”. Try to find where the mines are, without hit any.");
					Console.WriteLine("Commands: \n'top' - Shows top 5 players, \n'restart' - new game, \n'exit' - over and out!, \n Row and column format - '0 0'");
					DrawBoard(field);
					isNewGame = false;
				}

				Console.Write("Enter your command: ");
				inputCommand = Console.ReadLine().Trim();

				if (inputCommand.Length >= 3)
				{
					if (int.TryParse(inputCommand[0].ToString(), out row) &&
						int.TryParse(inputCommand[2].ToString(), out column) &&
						row <= field.GetLength(0) &&
						column <= field.GetLength(1))
					{
						inputCommand = "turn";
					}
				}

				switch (inputCommand)
				{
					case "top":
						PrintTop5Players(theBestFive);
						break;
					case "restart":
						field = CreateField();
						mines = CreateMines();
						DrawBoard(field);
						isHitMine = false;
						isNewGame = false;
						break;
					case "exit":
						Console.WriteLine("\nMade in Bulgaria!");
						Console.WriteLine("Goodbye!\n");
						break;
					case "turn":
						if (mines[row, column] != '*')
						{
							if (mines[row, column] == '-')
							{
								PlayerMove(field, mines, row, column);
								pointCounter++;
							}
							if (MaximumPoints == pointCounter)
							{
								isEndGame = true;
							}
							else
							{
								DrawBoard(field);
							}
						}
						else
						{
							isHitMine = true;
						}
						break;
					default:
						Console.WriteLine("\nERROR! Unknown command. Try again.\n");
						break;
				}
				if (isHitMine)
				{
					DrawBoard(mines);
					Console.Write("\nGame over! You died with {0} points. ", pointCounter);
					Console.WriteLine("Please input a nickname: ");
					string nickname = Console.ReadLine();

					AddToTop5(nickname, pointCounter);

					PrintTop5Players(theBestFive);

					isHitMine = false;
					FieldReset(field, mines, pointCounter, isNewGame);
				}
				if (isEndGame)
				{
					Console.WriteLine("\nCongratulations, you won!");
					DrawBoard(mines);
					Console.WriteLine("lease input a nickname: ");
					string nickname = Console.ReadLine();

					AddToTop5(nickname, pointCounter);

					PrintTop5Players(theBestFive);

					isEndGame = false;
					FieldReset(field, mines, pointCounter, isNewGame);
				}
			}

			Console.Read();
		}

		private static void AddToTop5(string nickname, int pointCounter) //New created method to optimize code
		{
			Points currentPlayer = new Points(nickname, pointCounter);
			if (theBestFive.Count < 5)
			{
				theBestFive.Add(currentPlayer);
			}
			else
			{
				for (int i = 0; i < theBestFive.Count; i++)
				{
					if (theBestFive[i].Count < currentPlayer.Count)
					{
						theBestFive.Insert(i, currentPlayer);
						theBestFive.RemoveAt(theBestFive.Count - 1);
						break;
					}
				}
			}
			theBestFive.Sort((Points r1, Points r2) => r2.Name.CompareTo(r1.Name));
			theBestFive.Sort((Points r1, Points r2) => r2.Count.CompareTo(r1.Count));
		}

		private static void FieldReset(char[,] field, char[,] mines, int pointCounter, bool isNewGame) //New created method to optimize code
		{
			field = CreateField();
			mines = CreateMines();
			pointCounter = 0;
			isNewGame = true;
		}

		private static void PrintTop5Players(List<Points> points)
		{
			if (points.Count > 0)
			{
				Console.WriteLine("Points:");
				for (int i = 0; i < points.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} points.", i + 1, points[i].Name, points[i].Count);
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("\nNo players added!\n");
			}
		}

		private static void PlayerMove(char[,] field, char[,] mines, int row, int column)
		{
			char currentPosition = MinesArroungPlayer(mines, row, column);
			mines[row, column] = currentPosition;
			field[row, column] = currentPosition;
		}

		private static void DrawBoard(char[,] board)
		{
			int row = board.GetLength(0);
			int col = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
			for (int i = 0; i < row; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < col; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}
				Console.Write("|");
				Console.WriteLine();
			}
			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] CreateField()
		{
			char[,] board = new char[FieldRows, FieldColumns];

			for (int i = 0; i < board.GetLength(0); i++)
			{
				for (int j = 0; j < board.GetLength(1); j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] CreateMines()
		{

			char[,] playField = new char[FieldRows, FieldColumns];

			for (int i = 0; i < playField.GetLength(0); i++)
			{
				for (int j = 0; j < playField.GetLength(1); j++)
				{
					playField[i, j] = '-';
				}
			}

			List<int> MineCoordinates = new List<int>();
			while (MineCoordinates.Count < MaximumMines)
			{
				int currentRandomNumber = random.Next(NextRandomNumber);
				if (!MineCoordinates.Contains(currentRandomNumber))
				{
					MineCoordinates.Add(currentRandomNumber);
				}
			}

			foreach (int mines in MineCoordinates)
			{
				int col = (mines / playField.GetLength(1));
				int row = (mines % playField.GetLength(1));
				if (row == 0 && mines != 0)
				{
					col--;
					row = playField.GetLength(1);
				}
				else
				{
					row++;
				}
				playField[col, row - 1] = '*';
			}

			return playField;
		}

		//Not needed code i only commented just to be seen, can be deleted freely.
		//private static void smetki(char[,] pole)
		//{
		//	int kol = pole.GetLength(0);
		//	int row = pole.GetLength(1);

		//	for (int i = 0; i < kol; i++)
		//	{
		//		for (int j = 0; j < row; j++)
		//		{
		//			if (pole[i, j] != '*')
		//			{
		//				char kolkoo = kolko(pole, i, j);
		//				pole[i, j] = kolkoo;
		//			}
		//		}
		//	}
		//}

		private static char MinesArroungPlayer(char[,] mines, int row, int col)
		{
			int count = 0;
			int rows = mines.GetLength(0);
			int kols = mines.GetLength(1);

			if (row - 1 >= 0)
			{
				if (mines[row - 1, col] == '*')
				{
					count++;
				}
			}
			if (row + 1 < rows)
			{
				if (mines[row + 1, col] == '*')
				{
					count++;
				}
			}
			if (col - 1 >= 0)
			{
				if (mines[row, col - 1] == '*')
				{
					count++;
				}
			}
			if (col + 1 < kols)
			{
				if (mines[row, col + 1] == '*')
				{
					count++;
				}
			}
			if ((row - 1 >= 0) && (col - 1 >= 0))
			{
				if (mines[row - 1, col - 1] == '*')
				{
					count++;
				}
			}
			if ((row - 1 >= 0) && (col + 1 < kols))
			{
				if (mines[row - 1, col + 1] == '*')
				{
					count++;
				}
			}
			if ((row + 1 < rows) && (col - 1 >= 0))
			{
				if (mines[row + 1, col - 1] == '*')
				{
					count++;
				}
			}
			if ((row + 1 < rows) && (col + 1 < kols))
			{
				if (mines[row + 1, col + 1] == '*')
				{
					count++;
				}
			}
			return char.Parse(count.ToString());
		}
	}
}
