using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
	public class Points
	{
		private string name;
		private int count;

		public string Name
		{
			get { return this.name; }
		}

		public int Count
		{
			get { return count; }
		}

		public Points(string name, int count)
		{
			this.name = name;
			this.count = count;
		}
	}
}
