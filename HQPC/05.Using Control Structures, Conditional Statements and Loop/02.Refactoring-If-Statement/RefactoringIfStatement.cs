using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Refactoring_If_Statement
{
	class RefactoringIfStatement
	{
		static void Main(string[] args)
		{
			//part One
			//-----------------------------------
			//Original code has no {}.
			//Potato potato;
			////... 
			//if (potato != null)
			//	if (!potato.HasNotBeenPeeled && !potato.IsRotten)
			//		Cook(potato);

			Potato potato;
			//... 
			if (potato != null)
			{
				if (!(potato.IsRotten || potato.HasNotBeenPeeled))// check is rotten must be first.
				{
					Cook(potato);
				}
			}

			//Prat Two
			//-----------------------------------
			//Original code has too many nested boolean operations.
			//if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell)))
			//{
			//	VisitCell();
			//}

			//Boolean ops was messy, converted them to more readeble state.
			bool isInRangeY = MIN_Y <= y && y <= MAX_Y; //can be simplified more, proububly.
			bool isInRangeX = MIN_X <= x && x <= MAX_X; //can be simplified more, proububly.
			bool isInRange = isInRangeX && isInRangeY;
			bool shouldVisitCell = !shouldNotVisitCell;

			if (isInRange && shouldVisitCell)
			{
			   VisitCell();
			}
		}
	}
}
