// Write a program to compare the performance of square root,
// natural logarithm, sinus for float, double and decimal values.

namespace PereformanceOfMathFuncsOnValueTypes
{
	using System;
	using System.Diagnostics;
	using System.Linq;

	class PereformanceOfMathFuncs
	{
		static void MathFuncPereformence<T>(T value)
		{
			// square root
			dynamic inner = value;
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			if (typeof(T).ToString() == "System.Decimal")
			{
				inner = Math.Sqrt((double)inner);
			}
			else
			{
				inner = Math.Sqrt(inner);
			}
			stopwatch.Stop();
			Console.WriteLine("Square root time: " + stopwatch.Elapsed.TotalMilliseconds + " ms.");

			// natural logarithm
			inner = value;
			stopwatch.Start();
			if (typeof(T).ToString() == "System.Decimal")
			{
				inner = Math.Log10((double)inner);
			}
			else
			{
				inner = Math.Log10(inner);
			}
			stopwatch.Stop();
			Console.WriteLine("Natural logarithm time: " + stopwatch.Elapsed.TotalMilliseconds + " ms.");

			// sinus
			inner = value;
			stopwatch.Start();
			if (typeof(T).ToString() == "System.Decimal")
			{
				inner = Math.Sin((double)inner);
			}
			else
			{
				inner = Math.Sin(inner);
			}
			stopwatch.Stop();
			Console.WriteLine("Sinus time: " + stopwatch.Elapsed.TotalMilliseconds + " ms.");
		}

		static void Main(string[] args)
		{
			// TEST integers, for first run.
			int testA = 152346754;
			Console.WriteLine("Check for TEST INT values: {0}.", testA);
			MathFuncPereformence(testA);
			Console.WriteLine();

			// floats
			float floatA = 1349.75634f;
			Console.WriteLine("Check for FLOAT values: {0}.", floatA);
			MathFuncPereformence(floatA);
			Console.WriteLine();

			// doubles
			double doubleA = 1349605.23464245978d;
			Console.WriteLine("Check for DOUBLE values: {0}.", doubleA);
			MathFuncPereformence(doubleA);
			Console.WriteLine();

			// decimals
			decimal decimalA = 13496059564.234563495m;
			Console.WriteLine("Check for DECIMAL values: {0}.", decimalA);
			MathFuncPereformence(decimalA);
			Console.WriteLine();

			Console.WriteLine("It turns out a test run is needed to have correct results.");
		}
	}
}
