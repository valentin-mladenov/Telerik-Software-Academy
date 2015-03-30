using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reads a list
//of words, separated by spaces and
//prints the list in an alphabetical order.

class List_In_Alphabetical_Order
{
    static void Main()
    {
        string text = "Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.";

        string[] separators = { " ", "\t", ",", ".", "\n" };
        string[] textArr = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(textArr);

        foreach (string item in textArr)
        {
            Console.WriteLine(item);
        }
    }
}