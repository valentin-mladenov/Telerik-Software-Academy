using System;
using System.Collections.Generic;
using System.Text;

class ExceptionsHomework
{
	public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
	{
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("Count (" + count + ") must be higher or equal to 0.");
		}

		if (startIndex < 0)
		{
			throw new ArgumentOutOfRangeException("Start index (" + startIndex + ") must be higher or equal to 0.");
		}

		if (arr == null)
		{
			throw new ArgumentNullException("Array (" + arr + ") cannot be null.");
		}

		if (startIndex + count > arr.Length)
		{
			throw new ArgumentOutOfRangeException("Count (" + count + ") plus start index " + startIndex + " are outside the array. Array length: " + arr.Length + ".");
		}

		List<T> result = new List<T>();
		for (int i = startIndex; i < startIndex + count; i++)
		{
			result.Add(arr[i]);
		}

		return result.ToArray();
	}

	public static string ExtractEnding(string str, int count)
	{
		if (count > str.Length)
		{
			throw new ArgumentOutOfRangeException("Count (" + count + ") cannot be higher than string length (" + str.Length + ").");
		}

		StringBuilder result = new StringBuilder();
		for (int i = str.Length - count; i < str.Length; i++)
		{
			result.Append(str[i]);
		}

		return result.ToString();
	}

	public static void CheckPrime(int number)
	{
		bool isPrime = true;
		for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
		{
			if (number % divisor == 0)
			{
				isPrime = false;
				break;
			}
		}

		if (isPrime)
		{
			Console.WriteLine(number + " is prime.");
		}
		else
		{
			Console.WriteLine(number + " is not prime");
		}
	}

	static void Main()
	{
		try
		{
			var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
			Console.WriteLine(substr);

			var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
			Console.WriteLine(string.Join(" ", subarr));

			var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
			Console.WriteLine(string.Join(" ", allarr));

			var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
			Console.WriteLine(string.Join(" ", emptyarr));

			Console.WriteLine(ExtractEnding("I love C#", 2));
			Console.WriteLine(ExtractEnding("Nakov", 4));
			Console.WriteLine(ExtractEnding("beer", 4));
			Console.WriteLine(ExtractEnding("Hi", 1));

			CheckPrime(23);
			CheckPrime(33);

			List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
			Student peter = new Student("Peter", "Petrov", peterExams);
			double peterAverageResult = peter.CalcAverageExamResultInPercents();
			Console.WriteLine("Average results = {0}%", peterAverageResult); // changing the output in correct manner

		}
		catch (ArgumentOutOfRangeException aoorex)
		{
			Console.Error.WriteLine(aoorex.Message);
		}
		catch (ArgumentNullException anex)
		{
			Console.Error.WriteLine(anex.Message);
		}
	}
}
