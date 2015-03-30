using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Refactor_Class
{
	class RefactorClass
	{
		
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
			private void Cut(Vegetable potato)
			{
				//...
			}
			public void Cook();

			public void Cook()
			{
				Bowl bowl;
				bowl = GetBowl();

				Potato potato = GetPotato();
				Carrot carrot = GetCarrot();
				
				Peel(potato);
				Peel(carrot);
				
				Cut(potato);
				Cut(carrot);

				bowl.Add(carrot);
				bowl.Add(potato);
			}
		}
	}
}