using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Refactor_Code
{
	public class Refactor_Code_Task_One
	{
		public class Size
		{
			//changed bad named fields and seted to private 
			private double width;
			private double heigth;


			//added properties Width and Height
			public double Width
			{
				get
				{
					return this.width;
				}
				protected set
				{
					this.width = value;
				}
			}

			public double Heigth
			{
				get
				{
					return this.heigth;
				}
				protected set
				{
					this.heigth = value;
				}
			}
			//end of properties

			//fixed constructor to use properties.
			public Size(double width, double heigth)
			{
				this.Width = width;
				this.Heigth = heigth;
			}
		}

		public static Size GetRotatedSize(Size figure, double rotationAngle)
		{
			double rotationCos = Math.Abs(Math.Cos(rotationAngle));
			double rotationSin = Math.Abs(Math.Sin(rotationAngle));

			double rotatedFigWidth = rotationCos * figure.Width + rotationSin * figure.Heigth;
			double rotatedFigHeight = rotationSin * figure.Width + rotationCos * figure.Heigth;

			Size rotatedFigure = new Size(rotatedFigWidth, rotatedFigHeight);

			return rotatedFigure;

			//Old return value totaly unreadeble.
			//return new Size(Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * s.wIdTh + Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * s.Viso4ina, Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * s.wIdTh + Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * s.Viso4ina);
		}
	}
}