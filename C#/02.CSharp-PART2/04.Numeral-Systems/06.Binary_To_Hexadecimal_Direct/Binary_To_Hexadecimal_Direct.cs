using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program to convert binary
//numbers to hexadecimal numbers (directly).


class Binary_To_Hexadecimal_Direct
{
    static void Main()
    {
        Console.WriteLine("Please enter a binary number:");
        string number = Console.ReadLine();

        while ((number.Length & 3) != 0)
        {
            number = "0" + number;
        }
        
        char[] binary = number.ToCharArray();
        Array.Reverse(binary);
        //Console.WriteLine(binary);

        string temp = "";
        string count = "";
        string finish = "";

        for (int i = 0; i < binary.Length; i += 4)
        {
            for (int j = i; j < 4 + i; j++)
            {
                temp = binary[j] + temp;
            }
            switch (temp)
            {
                case "0001": count = "1";
                    break;
                case "0010": count = "2";
                    break;
                case "0011": count = "3";
                    break;
                case "0100": count = "4";
                    break;
                case "0101": count = "5";
                    break;
                case "0110": count = "6";
                    break;
                case "0111": count = "7";
                    break;
                case "1000": count = "8";
                    break;
                case "1001": count = "9";
                    break;
                case "1010": count = "A";
                    break;
                case "1011": count = "B";
                    break;
                case "1100": count = "C";
                    break;
                case "1101": count = "D";
                    break;
                case "1110": count = "E";
                    break;
                case "1111": count = "F";
                    break;
                default:
                    break;
            }
            //Console.WriteLine(count);
            temp = "";
            finish = count + finish;
        }
        Console.WriteLine("Hexadecimal representation: {0}", finish);
    }
}