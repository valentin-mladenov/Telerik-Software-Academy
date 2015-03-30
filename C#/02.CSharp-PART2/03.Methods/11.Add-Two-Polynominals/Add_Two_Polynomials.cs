using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//11. Write a method that adds two polynomials.
//Represent them as arrays of their
//coefficients as in the example below:
//x2 + 5 = 1x2 + 0x + 5  {5, 0, 1}

//12.Extend the program to support also
//subtraction and multiplication of polynomials.



class Add_Two_Polynomials
{
    static int[] FirstPolyInput(int arrLeng)
    {
        int[] count = new int[arrLeng];

        for (int i = 0; i < count.Length; i++)
        {
            Console.Write("X^{0}*", i);
            count[i] = int.Parse(Console.ReadLine());
        }
        return count;
    }

    static int[] SecondPolyInput(int arrLeng)
    {
        int[] count = new int[arrLeng];

        for (int i = 0; i < count.Length; i++)
        {
            Console.Write("X^{0}*", i);
            count[i] = int.Parse(Console.ReadLine());
        }
        return count;
    }

    static int[] PolynomialsAddition(int[] array1, int[] array2)
    {
        int maxLenght = Math.Max(array1.Length, array2.Length);

        if (array1.Length > array2.Length)
        {
            array2 = new int[array1.Length];
        }
        else if (array2.Length > array1.Length)
        {
            array1 = new int[array2.Length];
        }

        int[] addition = new int[maxLenght];


        for (int i = 0; i < addition.Length; i++)
        {
            addition[i] = array1[i] + array2[i];
        }
        return addition;
    }

    static int[] PolynomialsSubstraction(int[] array1, int[] array2)
    {
        int maxLenght = Math.Max(array1.Length, array2.Length);

        if (array1.Length > array2.Length)
        {
            array2 = new int[array1.Length];
        }
        else if (array2.Length > array1.Length)
        {
            array1 = new int[array2.Length];
        }

        int[] substraction = new int[maxLenght];


        for (int i = 0; i < substraction.Length; i++)
        {
            substraction[i] = array1[i] - array2[i];
        }
        return substraction;
    }

    static int[] PolynomialsMultiplication(int[] array1, int[] array2)
    {
        int maxLenght = array1.Length + array2.Length + 2;

        if (array1.Length > array2.Length)
        {
            array2 = new int[array1.Length];
        }
        else if (array2.Length > array1.Length)
        {
            array1 = new int[array2.Length];
        }

        int[] multiplication = new int[maxLenght];

        for (int i = 0; i < array1.Length; i++)
        {
            for (int j = 0; j < array2.Length; j++)
            {
                int temp = i + j;
                multiplication[temp] += (array1[i] * array2[j]);
            }
        }
        return multiplication;
    }

    static void PrintPolynomial(int[] polynomial)
    {
        for (int i = polynomial.Length - 1; i >= 0; i--)
        {
            if ((polynomial[i] != 0) && (i != 0))
            {
                if (polynomial[i-1] >= 0)
                {
                    Console.Write("{0}X^{1} + ", polynomial[i], i);
                }
                else
                {
                    Console.Write("{0}X^{1} ", polynomial[i], i);
                }
            }
            else if (i == 0)
            {
                Console.Write("{0}", polynomial[i]);
            }
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.Write("How many monomials has the first polynomial:");
        int firstPoly = int.Parse(Console.ReadLine());
        Console.Write("How many monomials has the second polynomial:");
        int secondPoly = int.Parse(Console.ReadLine());

        int[] firstPolyArray = FirstPolyInput(firstPoly);
        int[] secondPolyArray = SecondPolyInput(secondPoly);

        Console.WriteLine("What to do with those polynomials: \nfor addition press '+' \nfor substraction press '-' \nfor multiplication press '*'");
        char function = char.Parse(Console.ReadLine());

        if (function == '+')
        {
            int[] addition = PolynomialsAddition(firstPolyArray, secondPolyArray);

            PrintPolynomial(addition);
        }
        else if (function == '-')
        {
            int[] substraction = PolynomialsSubstraction(firstPolyArray, secondPolyArray);

            PrintPolynomial(substraction);
        }
        else if (function == '*')
        {
            int[] multiplication = PolynomialsMultiplication(firstPolyArray, secondPolyArray);

            PrintPolynomial(multiplication);
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("ERROR!!! Incorect input function. Try again.");
            Console.WriteLine();
            Main();
        }
    }
}