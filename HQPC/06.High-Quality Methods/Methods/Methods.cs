using System;

//// There is a lot warnings by StyleCop, coz i use Tabs instead of Spaces.

namespace Methods
{
    class Methods
    {
        static double CalcTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                Console.Error.WriteLine("Sides should be positive.");
                throw new ArgumentOutOfRangeException();
            }

            double halfPerimeter = (sideA + sideB + sideC) / 2;
			if (halfPerimeter <= sideA || halfPerimeter <= sideB || halfPerimeter <= sideC)
			{
				Console.Error.WriteLine("Invalid sides values. One value is bigger or equal to the sum of another two.");
				throw new ArgumentOutOfRangeException();
			}
			//// heron formulae
			double area = Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) *
				(halfPerimeter - sideB) * (halfPerimeter - sideC));
            return area;
        }

        static string DigitToWord(int number)
        {
			string output;
            switch (number)
            {
				case 0: output = "zero";
					break;
				case 1: output = "one";
					break;
				case 2: output = "two";
					break;
				case 3: output = "three";
					break;
				case 4: output = "four";
					break;
				case 5: output = "five";
					break;
				case 6: output = "six";
					break;
				case 7: output = "seven";
					break;
				case 8: output = "eight";
					break;
				case 9: output = "nine";
					break;
				default: output = "Number should be between (0-9)!"; 
					break;
            }

            return output;
        }

        static int FindMaxNumber(params int[] elements)
        {

            if (elements == null || elements.Length == 0)
            {
				Console.Error.WriteLine("Empty array or null reference.");
				throw new ArgumentNullException();
            }

			int maxElement = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
				if (elements[i] > maxElement)
                {
					maxElement = elements[i];
                }
            }
			return maxElement;
        }

		static void PrintNumberWithPrecisionTwo(double number)
		{
				Console.WriteLine("{0:f2}", number);
		}

		static void PrintNumberAsPrecent(double number)
		{
				Console.WriteLine("{0:p0}", number);
		}

        static void PrintNumberAlignmentEight(double number)
        {
                Console.WriteLine("{0,8}", number);
        }

		static bool IsLineInOnePlane(double point1, double point2)
		{
			if (point1 == point2)
			{
				return true;
			}
			return false;
		}

        static double CalcDistance(double x1, double y1, double x2, double y2,
			out bool isHorizontalLine, out bool isVerticalLine)
        {
			isHorizontalLine = IsLineInOnePlane(y1, y2);
			isVerticalLine = IsLineInOnePlane(x1, x2);

            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

			Console.WriteLine(DigitToWord(5));

			Console.WriteLine(FindMaxNumber(5, -1, 3, 2, 14, 2, 3));

			PrintNumberWithPrecisionTwo(1.3);
			PrintNumberAsPrecent(0.75);
			PrintNumberAlignmentEight(2.30);

            bool isHorizontalLine, isVerticalLine;
			Console.WriteLine(CalcDistance(3, -1, 3, 2.5, out isHorizontalLine, out isVerticalLine));
			Console.WriteLine("Is horizontal line? " + isHorizontalLine);
			Console.WriteLine("Is vertical line? " + isVerticalLine);

			string peterTown = "Sofia";
			DateTime peterBirthDate = DateTime.Parse("17.03.1992");
			Student peter = new Student()
			{
				FirstName = "Peter",
				LastName = "Ivanov",
			};
			peter.PersonalInfo = new StudentInforamtion(peterBirthDate, peterTown);
			

			string stellaTown = "Vidin";
			string stellaHobbies = "gamer, high results";
			DateTime stellaBirthDate = DateTime.Parse("03.11.1993");	
			Student stella = new Student()
			{
				FirstName = "Stella",
				LastName = "Markova",
			};
			stella.PersonalInfo = new StudentInforamtion(stellaBirthDate, stellaTown, stellaHobbies);

			Console.WriteLine("{0} older than {1} -> {2}",
				peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
