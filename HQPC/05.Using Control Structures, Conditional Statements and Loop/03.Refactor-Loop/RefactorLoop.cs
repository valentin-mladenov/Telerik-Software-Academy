using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Original code.
//int i = 0;
//for (i = 0; i < 100; )
//{
//	if (i % 10 == 0)
//	{
//		Console.WriteLine(array[i]);
//		if (array[i] == expectedValue)
//		{
//			i = 666;
//		}
//		i++;
//	}
//	else
//	{
//		Console.WriteLine(array[i]);
//		i++;
//	}
//}
//// More code here
//if (i == 666)
//{
//	Console.WriteLine("Value Found");
//}

namespace _03.Refactor_Loop
{
	class RefactorLoop
	{
		//const int TheNumberOfTheBeast = 666; My new constant is not needed.

		static void Main(string[] args)
		{
			//int i = 0; This is not JavaScript
			//Was used 100 the MAGIC number, converted to array.Length
			
			for (int i = 0; i < array.Length; i++)
			{
				Console.WriteLine(array[i]);

				if (i % 10 == 0 && array[i] == expectedValue)
				{
					//i = TheNumberOfTheBeast; //practicly not needed any more
					Console.WriteLine("The song: Iron Maiden - The number of the beast, has been found.");
					break; //used to stop the loop, coz we listen IRON MAIDEN now. :)
				}
			}
			// More code here.
			// No more code here. :)
			//After removing all comments the code is pretty small.
		}
	}
}
