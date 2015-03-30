using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    class Circle : Shape
    {
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException("Radius should be a positive number!");
            }
            else
            {
                base.Height = radius;
                base.Width = radius;
            }
        }

        public override double CalculateSurface()
        {
            return base.CalculateSurface() * Math.PI;
        }
    }
}