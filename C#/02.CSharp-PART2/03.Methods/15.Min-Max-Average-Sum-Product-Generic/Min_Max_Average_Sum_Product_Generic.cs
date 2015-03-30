using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//* Modify your last program and try to
//make it work for any number type, not
//just integer (e.g. decimal, float, byte,
//etc.). Use generic method (read in
//Internet about generic methods in C#).


class Min_Max_Average_Sum_Product_Generic
{
    static decimal[] ArrayInput(int arrLeng)
    {
        decimal[] count = new decimal[arrLeng];

        for (int i = 0; i < count.Length; i++)
        {
            Console.Write("Number {0} = ", i + 1);
            count[i] = decimal.Parse(Console.ReadLine());
        }
        return count;
    }

    static T Average<T>(T[] array)
    {
        dynamic temp = 0;
        for (int i = 0; i < array.Length; i++)
        {
            temp = array[i] + temp;
        }
        temp = temp / array.Length;
        return temp;
    }

    static void MinMax<T>(T[] array)
    {
        dynamic maxNumber = array[0];
        dynamic minNumber = array[0];

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > maxNumber)
            {
                maxNumber = array[i];
            }
        }

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < minNumber)
            {
                minNumber = array[i];
            }
        }

        Console.WriteLine("The maximum number in the sequence is: {0}", maxNumber);
        Console.WriteLine("The minimum number in the sequence is: {0}", minNumber);
    }

    static void ArraySum<T>(T[] array)
    {
        dynamic sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum = array[i] + sum;
        }

        Console.WriteLine("The sum of the sequence is: {0}", sum);
    }

    static void ArrayProduct<T>(T[] array)
    {
        dynamic product = 1;
        for (int i = 0; i < array.Length; i++)
        {
            product = array[i] * product;
        }

        Console.WriteLine("The product of the sequence is: {0}", product);
    }

    static void Main()
    {
        Console.Write("Enter how many numbers:");
        int arrayLength = int.Parse(Console.ReadLine());

        //The Methods work with any numeric system,
        //but the user input i can't control.
        //The array must be declared otherwise.
        //Here i use "decimal" user input, if 
        //changed here to "byte", ArrayInput Method
        //must be changed to "byte" as well.
        decimal[] array = ArrayInput(arrayLength);

        Console.WriteLine("The average of the sequence is: {0}", Average(array));

        MinMax(array);

        ArraySum(array);

        ArrayProduct(array);
    }
}