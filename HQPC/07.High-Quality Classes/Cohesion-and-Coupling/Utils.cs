using System;

namespace CohesionAndCoupling
{
	/// <summary>
	/// Creates geometrical figure parallelepiped.
	/// </summary>
	public class Parallelepiped
	{
		/// <summary>
		/// Gets the width of the parallelepiped.
		/// </summary>
		public double Width { get; private set; }
		/// <summary>
		/// Gets the heigth of the parallelepiped.
		/// </summary>
		public double Height { get; private set; }
		/// <summary>
		/// Gets the depth of the parallelepiped.
		/// </summary>
		public double Depth { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Parallelepiped" /> class.
		/// </summary>
		/// <param name="width">The width of the parallelepiped.</param>
		/// <param name="height">The heigth of the parallelepiped.</param>
		/// <param name="depth">The depth of the parallelepiped.</param>
		/// <exception cref="System.ArgumentException">
		/// Thrown when heigth, depth or width are zero or negatgive.
		/// </exception>
		public Parallelepiped(double width, double height, double depth)
		{
			if (width <= 0)
			{
				throw new ArgumentException("Width cannot be zero or negative.");
			}
			if (height <= 0)
			{
				throw new ArgumentException("Height cannot be zero or negative.");
			}
			if (depth <= 0)
			{
				throw new ArgumentException("Depth cannot be zero or negative.");
			}

			this.Width = width;
			this.Depth = depth;
			this.Height = height;
		}

		/// <summary>
		/// Gets the volume of the parallelepiped.
		/// </summary>
		/// <returns></returns>
		public double CalcVolume()
		{
			double volume = this.Width * this.Height * this.Depth;
			return volume;
		}

		/// <summary>
		/// Calculate distance in two dimensional space.
		/// </summary>
		/// <param name="x1">The horisontal coordinate of first point.</param>
		/// <param name="y1">The vertical coordinate of first point.</param>
		/// <param name="x2">The horisontal coordinate of second point.</param>
		/// <param name="y2">The vertical coordinate of second point.</param>
		/// <returns>The distance between the two points.</returns>
		private double In2D(double x1, double y1, double x2, double y2)
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
		private double In3D(double x1, double y1, double z1, double x2, double y2, double z2)
		{
			double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
			return distance;
		}

		/// <summary>
		/// Claculates the length of the three dimensional diagonal.
		/// </summary>
		/// <returns>The length of the diagoanl.</returns>
		public double CalcDiagonalXYZ()
		{
			double distance = In3D(0, 0, 0, this.Width, this.Height, this.Depth);
			return distance;
		}

		/// <summary>
		/// Claculates the length of the diagonal in XY plane.
		/// </summary>
		/// <returns>The length of the diagoanl.<</returns>
		public double CalcDiagonalXY()
		{
			double distance = In2D(0, 0, this.Width, this.Height);
			return distance;
		}

		/// <summary>
		/// Claculates the length of the diagonal in XZ plane.
		/// </summary>
		/// <returns>The length of the diagoanl.<</returns>
		public double CalcDiagonalXZ()
		{
			double distance = In2D(0, 0, this.Width, this.Depth);
			return distance;
		}

		/// <summary>
		/// Claculates the length of the diagonal in YZ plane.
		/// </summary>
		/// <returns>The length of the diagoanl.<</returns>
		public double CalcDiagonalYZ()
		{
			double distance = In2D(0, 0, this.Height, this.Depth);
			return distance;
		}
	}
}