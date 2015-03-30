using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reads an integer
//number and calculates and prints its
//square root. If the number is invalid
//or negative, print "Invalid number".
//In all cases finally print "Good bye".
//Use try-catch-finally.

class Sqrt_Of_Integer
{
    static double Sqrt(int number)
    {
        if (number < 0)
        {
            throw new ArgumentOutOfRangeException("The number is negative by nature. Please submit a positive number.");
        }
        double result = Math.Round(Math.Sqrt(number), 2);
        return result;
    }

    static void Main()
    {
        try
        {
            Console.Write("Enter a 32Bit integer number: ");
            int number = int.Parse(Console.ReadLine());

            double result = Sqrt(number);

            Console.WriteLine(result);
        }
        catch (ArgumentOutOfRangeException aoore)
        {

            Console.Error.WriteLine("ERROR: " + aoore.Message);
        }
        catch (FormatException fe)
        {
            Console.Error.WriteLine("Cannot parse! " + fe.Message);
        }
        catch (OverflowException) 
        {
            Console.Error.WriteLine("The number is too big to fit in Int32!");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}