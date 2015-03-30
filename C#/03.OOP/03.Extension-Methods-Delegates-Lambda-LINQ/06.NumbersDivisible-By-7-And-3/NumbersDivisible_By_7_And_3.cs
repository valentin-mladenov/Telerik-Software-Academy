using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that prints from given array of integers
//all that are divisible by 7 and 3. Use the built-in
//extension methods and lambda expressions.
//Rewrite the same with LINQ.


class NumbersDivisible_By_7_And_3
{
    static void Main()
    {
        int[] numbers = { 1, 23, 50, 21, 7, 3, 42, 84, 21, 33, 168 };

        //LINQ (if divisible by 21, is divisible by 7 and 3 combine too)
        int[] divisible21 = (from num in numbers
                             where num % 21 == 0
                             select num).ToArray();
        Console.WriteLine(string.Join(", ", divisible21));

        //Lambda (if divisible by 21, is divisible by 7 and 3 combine too)
        int[] divLambda21 = (numbers.Where(num => num % 21 == 0)).ToArray();
        Console.WriteLine(string.Join(", ",divLambda21));
    }
}