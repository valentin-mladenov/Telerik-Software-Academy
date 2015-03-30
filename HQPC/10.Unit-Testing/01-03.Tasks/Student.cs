namespace UnitTesting
{
	using System;
	using System.Linq;

	public class Student
	{
		private int number;
		private string name;

		public int Number
		{
			get { return this.number; }
			private set{
				if (value<10000)
				{
					throw new ArgumentOutOfRangeException("The id number is less than allowed minimum");
					
				}
				else if (value>99999)
				{
					throw new ArgumentOutOfRangeException("The id number is more than allowed maximum");
				}
				else
				{
					this.number = value;
				}
			}
		}

		public string Name
		{
			get { return this.name; }
		 	private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException("Name can not be null, empty string or white space.");
				}
				else
				{
					this.name = value;
				}
			}
		}

		public Student(string name, int number)
		{
			this.Name = name;
			this.Number = number;
		}
	}
}
