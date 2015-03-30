using System;

namespace Abstraction
{

		/// <summary>
		/// Represents a circle.
		/// </summary>
    public class Circle : Figure
    {
		/// <summary>
		/// Gets the radius.
		/// </summary>
		public double Radius { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Circle" /> class.
		/// </summary>
		/// <param name="radius">The radius of the circle.</param>
		/// <exception cref="System.ArgumentException">
		/// Thrown when radius is zero or negatgive.
		/// </exception>
        public Circle(double radius)
        {
			if (radius <= 0)
			{
				throw new ArgumentException("Radius cannot be zero or negative.");
			}
			this.Radius = radius;
        }

		/// <summary>
		/// Calculates the perimeter of the cirle.
		/// </summary>
		/// <returns>The perimeter.</returns>
		public override double Perimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

		/// <summary>
		/// Calculates the area of the circle.
		/// </summary>
		/// <returns>The area.</returns>
		public override double Surface()
		{
			double surface = Math.PI * this.Radius * this.Radius;
			return surface;
		}
	}
}
