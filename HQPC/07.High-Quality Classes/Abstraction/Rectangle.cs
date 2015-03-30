using System;

namespace Abstraction
{
	/// <summary>
	/// Represents a rectangle.
	/// </summary>
	public class Rectangle : Figure
    {
		/// <summary>
		/// Gets the Width.
		/// </summary>
		public double Width { get; private set; }

		/// <summary>
		/// Gets the heigth.
		/// </summary>
		public double Height { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Rectangle" /> class.
		/// </summary>
		/// <param name="width">The width of the rectangle.</param>
		/// <param name="height">The heigth of the rectangle.</param>
		/// <exception cref="System.ArgumentException">
		/// Thrown when heigth is zero or negatgive.
		/// Thrown when width is zero or negatgive.
		/// </exception>
        public Rectangle(double width, double height)
        {
			if (height <= 0)
			{
				throw new ArgumentException("Height cannot be zero or negative.");
			}
			if (width <= 0)
			{
				throw new ArgumentException("Width cannot be zero or negative.");
			}
			this.Width = width;
			this.Height = height;
        }

		/// <summary>
		/// Calculates the perimeter of the rectangle.
		/// </summary>
		/// <returns>The perimeter.</returns>
        public override double Perimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

		/// <summary>
		/// Calculates the surface of the rectangle.
		/// </summary>
		/// <returns>The area.</returns>
		public override double Surface()
		{
			double surface = this.Width * this.Height;
			return surface;
		}
	}
}
