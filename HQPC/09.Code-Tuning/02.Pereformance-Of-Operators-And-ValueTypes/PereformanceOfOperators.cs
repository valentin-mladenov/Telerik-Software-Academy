//Write a program to compare the performance of add,
//subtract, increment, multiply, divide for int, long,
//float, double and decimal values.

namespace _02.Pereformance_Of_Operators_And_ValueTypes
{
	using System;
	using System.Diagnostics;
	using System.Linq;

	class PereformanceOfOperators
	{
		static void OperatorPereformence<T>(T value1, T value2)
		{
			// add
			dynamic inner = value1;
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			inner += value2;
			stopwatch.Stop();
			Console.WriteLine("Add time: " + stopwatch.Elapsed.TotalMilliseconds + " ms.");

			// subtract
			inner = value1;
			stopwatch.Start();
			inner -= value2;
			stopwatch.Stop();
			Console.WriteLine("Subtract time: " + stopwatch.Elapsed.TotalMilliseconds + " ms.");

			// increment
			inner = value1;
			stopwatch.Start();
			inner++;
			stopwatch.Stop();
			Console.WriteLine("Increment time: " + stopwatch.Elapsed.TotalMilliseconds + " ms.");

			// multiply
			inner = value1;
			stopwatch.Start();
			inner *= value2;
			stopwatch.Stop();
			Console.WriteLine("Multiply time: " + stopwatch.Elapsed.TotalMilliseconds + " ms.");

			// divide
			inner = value1;
			stopwatch.Start();
			inner /= value2;
			stopwatch.Stop();
			Console.WriteLine("Divide time: " + stopwatch.Elapsed.TotalMilliseconds + " ms.");
		}

		static void Main()
		{
			// TEST integers, for first run.
			int testA = 152346754;
			int testB = 205786;
			Console.WriteLine("Check for TEST INT values: {0}, {1}.", testA, testB);
			OperatorPereformence(testA, testB);
			Console.WriteLine();

			// integers
			int integerA = 152346754;
			int integerB = 205786;
			Console.WriteLine("Check for INT values: {0}, {1}.", integerA, integerB);
			OperatorPereformence(integerA, integerB);
			Console.WriteLine();

			// longs
			long longA = 13496053495;
			long longB = 204537567452;
			Console.WriteLine("Check for LONG values: {0}, {1}.", longA, longB);
			OperatorPereformence(longA, longB);
			Console.WriteLine();

			// floats
			float floatA = 1349.75634f;
			float floatB = 204536.5745f;
			Console.WriteLine("Check for FLOAT values: {0}, {1}.", floatA, floatB);
			OperatorPereformence(floatA, floatB);
			Console.WriteLine();

			// doubles
			double doubleA = 13496053495.23464d;
			double doubleB = 20453.7567452d;
			Console.WriteLine("Check for DOUBLE values: {0}, {1}.", doubleA, doubleB);
			OperatorPereformence(doubleA, doubleB);
			Console.WriteLine();

			// decimals
			decimal decimalA = 13496059564.234563495m;
			decimal decimalB = 20453756.1234567452m;
			Console.WriteLine("Check for DECIMAL values: {0}, {1}.", decimalA, decimalB);
			OperatorPereformence(decimalA, decimalB);
			Console.WriteLine();

			Console.WriteLine("It turns out a test run is needed to have correct results.");
		}
	}
}
