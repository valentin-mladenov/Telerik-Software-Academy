using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Write a program that reads a string
//from the console and prints all
//different letters in the string
//along with information how many
//times each letter is found.

class All_Letters_How_Many_Times
{
    static void Main()
    {
        //string text = "Write a program that reads a string from the console and prints all different letters in the string along with information how many times each letter is found.";

        string text = Console.ReadLine();

        char temp;
        int min;
        char[] textArr = text.ToCharArray();

        for (int i = 0; i < textArr.Length - 1; i++)
        {
            min = i;

            for (int j = i + 1; j < textArr.Length; j++)
            {
                if (textArr[j] < textArr[min])
                {
                    min = j;
                }
            }

            temp = textArr[i];
            textArr[i] = textArr[min];
            textArr[min] = temp;
        }

        StringBuilder tempArr = new StringBuilder();

        for (int i = 0; i < textArr.Length-1; i++)
        {
            if ((textArr[i] < 65 || textArr[i] > 123) || (textArr[i] > 90 && textArr[i] < 97))
            {
                
            }          
            else if (textArr[i] != textArr[i+1])
            {
                tempArr.Append(textArr[i]);
                Console.WriteLine("Letter: {0}, repeates {1} times.", textArr[i], tempArr.Length);
                tempArr.Clear();
            }
            else
            {
                tempArr.Append(textArr[i]);
            }
        }

        if ((textArr[textArr.Length - 1] < 65 || textArr[textArr.Length - 1] > 123) || (textArr[textArr.Length - 1] > 90 && textArr[textArr.Length - 1] < 97))
        {

        }
        else
        {
            if (textArr[textArr.Length - 2] == textArr[textArr.Length - 1])
            {
                tempArr.Append(textArr[textArr.Length - 1]);
                Console.WriteLine("Letter: {0}, repeates {1} times.", textArr[textArr.Length - 1], tempArr.Length);
                tempArr.Clear();
            }
            if (textArr[textArr.Length - 2] != textArr[textArr.Length - 1])
            {
                Console.WriteLine("Letter: {0}, repeates {1} times.", textArr[textArr.Length - 1], 1);
            }
        }
    }
}