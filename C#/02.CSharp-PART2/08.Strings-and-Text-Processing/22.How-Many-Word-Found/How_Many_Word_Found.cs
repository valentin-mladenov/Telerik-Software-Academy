using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reads a string
//from the console and lists all
//different words in the string
//along with information how
//many times each word is found.

class How_Many_Word_Found
{
    static void Main()
    {
        string text = "Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found.";

        string[] separators = { " ", "\t", ",", ".", "\n" };
        string[] textArr = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(textArr);

        int temp = 0;
        for (int i = 0; i < textArr.Length - 1; i++)
        {
            if (textArr[i] != textArr[i + 1])
            {
                temp++;
                Console.WriteLine(String.Format("Word: {0,-12} |repeates {1} times.", textArr[i], temp));
                temp = 0;
            }
            else
            {
                temp++;
            }
        }
        if (textArr[textArr.Length - 2] == textArr[textArr.Length - 1])
        {
            temp++;
            Console.WriteLine(String.Format("Word: {0,-12} |repeates {1} times.", textArr[textArr.Length - 1], temp));
            temp = 0;
        }
        if (textArr[textArr.Length - 2] != textArr[textArr.Length - 1])
        {
            Console.WriteLine(String.Format("Word: {0,-12} |repeates {1} times.", textArr[textArr.Length - 1], 1));
        }
    }
}