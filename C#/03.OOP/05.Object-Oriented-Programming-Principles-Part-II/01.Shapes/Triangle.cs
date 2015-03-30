using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    class Triangle : Shape
    {
        public Triangle(double width,double height)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException("Width should be a positive number!");
            }
            else if (height <= 0)
            {
                throw new ArgumentOutOfRangeException("Height should be a positive number!");
            }
            else
            {
                base.Width = width;
                base.Height = height;
            }
        }

        public override double CalculateSurface()
        {
            return base.CalculateSurface() / 2;
        }
    }
}