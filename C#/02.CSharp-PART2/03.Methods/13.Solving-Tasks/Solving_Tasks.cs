using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that can solve these tasks:
//Reverses the digits of a number
//Calculates the average of a sequence of integers
//Solves a linear equation a * x + b = 0

//Create appropriate methods.
//Provide a simple text-based menu for the user
//to choose which task to solve.

//Validate the input data:
//The decimal number should be non-negative
//The sequence should not be empty
//a should not be equal to 0


class Solving_Tasks
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

    static string ReverseDigits(string number)
    {
        char[] digitName = number.ToCharArray();
        int revLenght = digitName.Length;
        char[] reversedArray = new char[revLenght];

        for (int i = 0; i < digitName.Length; i++)
        {
            reversedArray[i] = digitName[revLenght - 1 - i];
        }

        string finish = string.Join("", reversedArray);
        return finish;
    }

    static float Average(float[] array)
    {
        float temp = 0;
        for (int i = 0; i < array.Length; i++)
        {
            temp = array[i] + temp;
        }
        temp = temp/array.Length;
        return temp;
    }

    static float LinearEquation()
    {
        Console.Write("Enter Number 'a':");
        float numberA = float.Parse(Console.ReadLine());
        Console.Write("Enter Number 'b':");
        float numberB = float.Parse(Console.ReadLine());
        float numberX = -numberB/numberA;

        Console.WriteLine();
        return numberX;
    }

    static void Main()
    {
        Console.WriteLine("What task you want to solve:");
        Console.WriteLine("For reversing digits of a number press '1'.");
        Console.WriteLine("For calculating the average of a sequence of integers press '2'.");
        Console.WriteLine("For solving a linear equation a * x + b = 0 press '3'.");
        char function = char.Parse(Console.ReadLine());

        if (function == '1')
        {
        Console.Write("Enter a Number:");
        string number = Console.ReadLine();

        Console.WriteLine("The reversed number is: {0}", ReverseDigits(number));
        }
        else if (function == '2')
        {
            Console.Write("Enter how many numbers:");
            int arrayLength = int.Parse(Console.ReadLine());

            float[] average = ArrayInput(arrayLength);

            Console.WriteLine("The average of the sequence is: {0}", Average(average));
        }
        else if (function == '3')
        {
            Console.WriteLine("The ansuer of the linear equation is: {0}", LinearEquation());
        }
        else
        {
            Console.WriteLine("ERROR!!! Incorect input. Try again.");
            Main();
        }
    }
}