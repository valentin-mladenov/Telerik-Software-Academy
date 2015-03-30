using System;

                //Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum. 

class Print_Number_N_Sum
{
    static void Main()
    {
        Console.WriteLine("How many numbers to calculate?");
        double count = double.Parse(Console.ReadLine());
        double sum = 0;
        for (int i = 0; i < count; i++) 
        {
            Console.WriteLine("Please enter a number:");
            double newNumbers = double.Parse(Console.ReadLine());
            sum += newNumbers;            
        }
        Console.WriteLine("The sum is: {0}",sum);
    }
}