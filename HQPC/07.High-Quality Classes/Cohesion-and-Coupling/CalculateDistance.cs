using System;

namespace CohesionAndCoupling
{
	/// <summary>
	/// Distance calculator.
	/// </summary>
	public class CalculateDistance
	{
		/// <summary>
		/// Calculate distance in two dimensional space.
		/// </summary>
		/// <param name="x1">The horisontal coordinate of first point.</param>
		/// <param name="y1">The vertical coordinate of first point.</param>
		/// <param name="x2">The horisontal coordinate of second point.</param>
		/// <param name="y2">The vertical coordinate of second point.</param>
		/// <returns>The distance between the two points.</returns>
		public static double In2D(double x1, double y1, double x2, double y2)
		{
			double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
			return distance;
		}

		/// <summary>
		/// Calculate distance in three dimensional space.
		/// </summary>
		/// <param name="x1">The horisontal coordinate of first point.</param>
		/// <param name="y1">The vertical coordinate of first point.</param>
		/// <param name="z1">The horisontal coordinate of second point.</param>
		/// <param name="x2">The vertical coordinate of second point.</param>
		/// <param name="y2">The horisontal coordinate of third point.</param>
		/// <param name="z2">The vertical coordinate of third point.</param>
		/// <returns>The distance between the three points.</returns>
		public static double In3D(double x1, double y1, double z1, double x2, double y2, double z2)
		{
			double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
			return distance;
		}
	}
}
