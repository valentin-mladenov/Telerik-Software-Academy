using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Refactor_Class_In_Straight_Line
{
	class RefactorClass
	{
		//I'm not sure but i think it is correct.
		public class Chef
		{
			private Bowl GetBowl()
			{
				//... 
			}
			private Carrot GetCarrot()
			{
				//...
			}
			private Potato GetPotato()
			{
				//...
			}
			private void Cut(Vegetable vegetable)
			{
				//...
			}

			public void Cook();//was outside the class no current use, proubably should be deleted.

			public void Cook()
			{
				Bowl bowl;
				bowl = GetBowl();

				Potato potato = GetPotato();
				Peel(potato);
				Cut(potato);
				bowl.Add(potato);

				Carrot carrot = GetCarrot();
				Peel(carrot);
				Cut(carrot);
				bowl.Add(carrot);
			}
		}
	}
}