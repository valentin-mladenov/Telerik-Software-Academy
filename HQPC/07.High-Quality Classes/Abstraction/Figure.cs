namespace Abstraction
{
	using System;

	/// <summary>
	/// Represents a geometric figure
	/// </summary>
	public abstract class Figure
	{
		/// <summary>
		/// Calculates the preimeter of the figure.
		/// </summary>
		/// <returns>The perimeter.</returns>
		public abstract double Perimeter();

		/// <summary>
		/// Calculates the surface of the figure.
		/// </summary>
		/// <returns>The area.</returns>
		public abstract double Surface();
	}
}
