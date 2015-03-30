using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    abstract class Shape
    {
        private double width;
        private double height;

        public double Width
        {
            get { return this.width; }
            set { this.width = value; }
        }
        public double Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        public virtual double CalculateSurface()
        {
            return height * width;
        }
    }
}
