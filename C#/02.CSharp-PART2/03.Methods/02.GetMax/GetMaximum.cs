using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a method GetMax() with two
//parameters that returns the bigger
//of two integers. Write a program
//that reads 3 integers from the
//console and prints the biggest
//of them using the method GetMax().


class GetMaximum
{
    static int GetMax(int numberA, int numberB)
    {
        int numberMax = Math.Max(numberA, numberB);

        return numberMax;
    }

    static void Main()
    {
        Console.WriteLine("Enter three numbers:");
        int numnberOne = int.Parse(Console.ReadLine());
        int numnberTwo = int.Parse(Console.ReadLine());
        int numnberThree = int.Parse(Console.ReadLine());

        int compare = GetMax(numnberOne, numnberTwo);

        int final = GetMax(compare, numnberThree);

        Console.WriteLine("The biggest one is : {0}", final);
    }
}