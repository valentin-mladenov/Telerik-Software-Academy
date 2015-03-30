namespace GameFifteen
{
	using System;
	using System.Linq;
	using System.Text;

	public class Matrix
	{
		private int lengthA;
		private int lengthB;
		private int[,] body;

		public Matrix(int lengthA)
		{
			this.LengthA = lengthA;
			this.LengthB = lengthA;
			this.body = new int[this.LengthA, this.LengthB];

		}

		public Matrix(int lengthA, int lengthB)
		{
			this.LengthA = lengthA;
			this.LengthB = lengthB;
			this.body = new int[this.LengthA, this.LengthB];
		}

		public int[,] Body
		{
			get
			{
				return this.body;
			}
			private set { }
		}

		public int LengthA
		{
			get
			{
				return this.lengthA;
			}
			set
			{
				if (value < 0 || value > 100)
				{
					throw new ArgumentOutOfRangeException("Matrix length must be between 0 and 100");
				}
				this.lengthA = value;
			}
		}

		public int LengthB
		{
			get
			{
				return this.lengthB;
			}
			set
			{
				if (value < 0 || value > 100)
				{
					throw new ArgumentOutOfRangeException("Matrix length must be between 0 and 100");
				}
				this.lengthB = value;
			}
		}

		private void WalkingTheMatrix(int[,] matrix, Direction direction, ref int count, int row, int col)
		{
			while (true)
			{
				matrix[row, col] = count;

				if (!direction.IsNearEmptyCell(matrix, row, col))
				{
					count++;
					break;
				}
				else
				{
					count++;
				}

				while ((row + direction.X >= matrix.GetLength(0)
					|| row + direction.X < 0
					|| col + direction.Y >= matrix.GetLength(1)
					|| col + direction.Y < 0
					|| matrix[row + direction.X, col + direction.Y] != 0))
				{
					direction.UpdateDirection();
				}

				row += direction.X;
				col += direction.Y;
			}
		}

		public void Walk(Direction direction)
		{
			int count = 1,
				row = 0,
				col = 0;

			WalkingTheMatrix(this.body, direction, ref count, row, col);

			if (count < this.body.Length)
			{
				direction.FindCellToTeleport(this.body, out row, out col);

				WalkingTheMatrix(this.body, direction, ref count, row, col);
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < this.body.GetLength(0); i++)
			{
				for (int j = 0; j < this.body.GetLength(1); j++)
				{
					sb.Append(this.body[i, j]);

					if (j < this.body.GetLength(1) - 1)
					{
						sb.Append(" ");
					}
				}
				sb.AppendLine();
			}

			return sb.ToString();
		} 

		public void Print()
		{
			Console.WriteLine(this.body.ToString());
		}
	}
}
