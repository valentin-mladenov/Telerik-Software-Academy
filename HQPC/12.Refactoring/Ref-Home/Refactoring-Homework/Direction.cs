namespace GameFifteen
{
	using System;
	using System.Linq;

	public class Direction
	{
		private readonly int[,] clocwiseDirectionTurns = { { 1, 1 }, { 1, 0 },
														{ 1, -1 }, { 0, -1 },
														{ -1, -1 }, { -1, 0 },
														{ -1, 1 }, { 0, 1 } };

		private int x;
		private int y;

		public int X
		{
			get
			{
				return this.x;
			}
			set
			{
				this.x = value;
			}
		}
		public int Y
		{
			get
			{
				return this.y;
			}
			set
			{
				this.y = value;
			}
		}

		public Direction(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		public void UpdateDirection()
		{
			for (int i = 0; i < this.clocwiseDirectionTurns.Length / 2; i++)
			{
				if (this.clocwiseDirectionTurns[i, 0] == this.X &&
					this.clocwiseDirectionTurns[i, 1] == this.Y)
				{
					if (i == this.clocwiseDirectionTurns.Length / 2 - 1)
					{
						this.X = this.clocwiseDirectionTurns[0, 0];
						this.Y = this.clocwiseDirectionTurns[0, 1];
					}
					else
					{
						this.X = this.clocwiseDirectionTurns[i + 1, 0];
						this.Y = this.clocwiseDirectionTurns[i + 1, 1];
					}
					break;
				}
			}
		}

		public bool IsNearEmptyCell(int[,] arr, int row, int col)
		{
			for (int i = 0; i < this.clocwiseDirectionTurns.Length / 2; i++)
			{
				if (row + this.clocwiseDirectionTurns[i, 0] >= arr.GetLength(0)
					|| row + this.clocwiseDirectionTurns[i, 0] < 0)
				{
					continue;
				}
				else if (col + this.clocwiseDirectionTurns[i, 1] >= arr.GetLength(1)
					|| col + this.clocwiseDirectionTurns[i, 1] < 0)
				{
					continue;
				}

				if (arr[row + this.clocwiseDirectionTurns[i, 0],
					col + this.clocwiseDirectionTurns[i, 1]] == 0)
				{
					return true;
				}
			}
			return false;
		}

		public void FindCellToTeleport(int[,] arr, out int row, out int col)
		{
			row = 0;
			col = 0;
			for (int rows = 0; rows < arr.GetLength(0); rows++)
			{
				for (int cols = 0; cols < arr.GetLength(1); cols++)
				{
					if (arr[rows, cols] == 0)
					{
						row = rows;
						col = cols;
						this.X = this.clocwiseDirectionTurns[0,0];
						this.Y = this.clocwiseDirectionTurns[0, 1];
						return;
					}
				}
			}
		}
	}
}