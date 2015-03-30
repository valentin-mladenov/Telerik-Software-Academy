using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reads from the console
//a string of maximum 20 characters. If the
//length of the string is less than 20, the
//rest of the characters should be filled
//with '*'. Print the result string into
//the console.

class String_Lenght_Of_20_Chars
{
    static void Main()
    {
        string input = Console.ReadLine();
        string output = "";

        if (input.Length >20)
        {
            output = input.Remove(20);
        }
        else if (input.Length < 20)
        {
            StringBuilder temp = new StringBuilder(input);
            while (temp.Length < 20)
            {
                temp.Append("*");
            }
            output = temp.ToString();
        }
        else
        {
            output = input;
        }
        Console.WriteLine(output);
    }
}