using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

//Write a program to calculate n! for
//each n in the range [1..100]. 
//Hint: Implement first a method that
//multiplies a number represented as
//array of digits by given integer number. 


class Calc_N_Fact_From_1_To_100
{
    static BigInteger[] MyBigInteger(BigInteger[] array)
    {
        int temp = 1;
        array[0] = 1;
        array[1] = 1;

        for (int i = 1; i < array.Length; i++)
        {
            array[i] = temp * array[i - 1];
            temp = i + 1;
        }
        return array;
    }

    static void Main()
    {
        BigInteger[] array = new BigInteger[100];

        BigInteger[] final = MyBigInteger(array);

        string finish = string.Join(",\n", final);
        Console.WriteLine(finish);
    }
}