using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Extention_Methods
{
    public static T Sum<T>(this IEnumerable<T> list)
    {
        dynamic sum = 0;
        foreach (var item in list)
        {
            sum = item + sum;
        }
        return sum;
    }

    public static T Product<T>(this IEnumerable<T> list)
    {
        dynamic product = 1;
        foreach (var item in list)
        {
            product = item * product;
        }
        return product;
    }

    public static T Min<T>(this IEnumerable<T> list)
    {
        dynamic min = decimal.MaxValue;
        foreach (var item in list)
        {
            if (item < min)
            {
                min = item;
            }
        }
        return min;
    }

    public static T Max<T>(this IEnumerable<T> list)
    {
        dynamic max = decimal.MinValue;
        
        foreach (var item in list)
        {
            if (item > max)
            {
                max = item;
            }
        }
        return max;
    }

    public static T Average<T>(this IEnumerable<T> list)
    {
        dynamic sum = 0;
        int count = 0;
        foreach (var item in list)
        {
            sum = item + sum;
            count++;
        }
        if (count == 0)
        {
            throw new ArgumentException("The collection is empty.");
        }
        T average = sum / count;
        return average;
    }

    static void Main()
    {
        decimal[] numbers = { 1, 8, -5, 13, 7, 3, 2, 4, 1, 3, 4 };

        Console.WriteLine(numbers.Sum<decimal>());
        Console.WriteLine(numbers.Product<decimal>());
        Console.WriteLine(numbers.Min<decimal>());
        Console.WriteLine(numbers.Max<decimal>());
        Console.WriteLine(numbers.Average<decimal>());
        Console.WriteLine(numbers.Min<decimal>());
    }
}