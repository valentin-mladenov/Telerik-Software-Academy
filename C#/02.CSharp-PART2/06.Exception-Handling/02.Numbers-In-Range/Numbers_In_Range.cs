using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a method ReadNumber(int start, int end)
//that enters an integer number in given range
//[start…end]. If an invalid number or non-number
//text is entered, the method should throw an
//exception. Using this method write a program
//that enters 10 numbers:
//a1, a2, … a10, such that 1 < a1 < … < a10 < 100


class Numbers_In_Range
{
    static void ReadNumber(int start, int end)
    {
        int[] array = new int[10];
        try
        {
            array[0] = int.Parse(Console.ReadLine());
            if (array[0] <= start)
            {
                throw new ArgumentOutOfRangeException("The number is lesser than Start number.");
            }
            if (array[0] >= end)
            {
                throw new ArgumentOutOfRangeException("The number is bigger than End number.");
            }

            for (int i = 1; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
                if (array[i] <= start)
                {
                    throw new ArgumentOutOfRangeException("The number is lesser than Start.");
                }
                if (array[i] >= end)
                {
                    throw new ArgumentOutOfRangeException("The number is bigger than End.");
                }
                if (array[i - 1] >= array[i])
                {
                    throw new ArgumentOutOfRangeException("The number is lesser than Prevous number.");
                }
            }

            foreach (int num in array)
            {
                Console.Write("{0} ", num);
            }
            Console.WriteLine();
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
            Console.WriteLine("Bye. ;)");
        }
    }

    static void Main(string[] args)
    {
        int start = 1;
        int end = 100;

        ReadNumber(start, end);       
    }
}