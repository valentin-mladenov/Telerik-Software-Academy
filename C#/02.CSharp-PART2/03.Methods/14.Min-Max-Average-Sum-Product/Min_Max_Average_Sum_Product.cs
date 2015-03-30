using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write methods to calculate minimum,
//maximum, average, sum and product of
//given set of integer numbers.
//Use variable number of arguments.


class Min_Max_Average_Sum_Product
{
    static float[] ArrayInput(int arrLeng)
    {
        float[] count = new float[arrLeng];

        for (int i = 0; i < count.Length; i++)
        {
            Console.Write("Number {0} = ", i + 1);
            count[i] = float.Parse(Console.ReadLine());
        }
        return count;
    }

    static float Average(float[] array)
    {
        float temp = 0;
        for (int i = 0; i < array.Length; i++)
        {
            temp = array[i] + temp;
        }
        temp = temp / array.Length;
        return temp;
    }

    static void MinMax(float[] array)
    {
        float maxNumber = array[0];
        float minNumber = array[0];

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

    static void ArraySum(float[] array)
    {
        float sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum = array[i] + sum;
        }

        Console.WriteLine("The sum of the sequence is: {0}", sum);
    }

    static void ArrayProduct(float[] array)
    {
        float product = 1;
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

        float[] array = ArrayInput(arrayLength);

        Console.WriteLine("The average of the sequence is: {0}", Average(array));

        MinMax(array);

        ArraySum(array);

        ArrayProduct(array);
    }
}