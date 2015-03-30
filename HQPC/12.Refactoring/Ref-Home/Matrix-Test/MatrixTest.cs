using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteen;

namespace MatrixTest
{
	[TestClass]
	public class DirectionTest
	{
		[TestMethod]
		public void DirectionXPropertyTest()
		{
			Direction direction = new Direction(1, 1);

			Assert.AreEqual(1,direction.X,"Not correct X value");
		}

		[TestMethod]
		public void DirectionYPropertyTest()
		{
			Direction direction = new Direction(1, 1);

			Assert.AreEqual(1, direction.Y, "Not correct Y value");
		}

		[TestMethod]
		public void MatrixCreationTest()
		{
			Matrix matrix = new Matrix(6,6);

			Direction direction = new Direction(1, 1);

			matrix.Walk(direction);

			Assert.AreEqual(
				" 1 16 17 18 19 20\r\n" +
				" 15 2 27 28 29 21\r\n" +
				" 14 31 3 26 30 22\r\n" +
				" 13 36 32 4 25 23\r\n" +
				" 12 35 34 33 5 24\r\n" +
				" 11 10 9 8 7 6", matrix.ToString(), "Not correct matrix output value");
		}

		[TestMethod]
		public void MatrixWalkTest()
		{
			Matrix matrix = new Matrix(6);

			Direction direction = new Direction(1, 1);

			matrix.Walk(direction);

			Assert.AreEqual(
				" 1 16 17 18 19 20" +
				" 15 2 27 28 29 21" +
				" 14 31 3 26 30 22" +
				" 13 36 32 4 25 23" +
				" 12 35 34 33 5 24" +
				" 11 10 9 8 7 6", matrix.ToString(), "Not correct matrix output value");
		}

		[TestMethod]
		public void MatrixBodyTest()
		{
			Matrix matrix = new Matrix(6);

			Direction direction = new Direction(1, 1);

			matrix.Walk(direction);

			Assert.AreEqual(matrix.Body, matrix, "Not correct matrix output value");
		}
	}
}
