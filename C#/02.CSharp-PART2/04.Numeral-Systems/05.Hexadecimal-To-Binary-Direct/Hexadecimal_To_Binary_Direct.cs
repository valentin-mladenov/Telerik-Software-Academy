using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program to convert hexadecimal
//numbers to binary numbers (directly).


class Hexadecimal_To_Binary_Direct
{
    static void Main()
    {
        Console.WriteLine("Please enter a hexadecimal number:");
        string hex = Console.ReadLine();
        string ele = hex.ToUpper();

        char[] hexToBin = ele.ToCharArray();
        Array.Reverse(hexToBin);


        string binary = "";

        for (int i = 0; i < hexToBin.Length; i++)
        {
            if (hexToBin[i] == '0')
            {
                binary = "0000 " + binary;
            }
            else if (hexToBin[i] == '1')
            {
                binary = "0001 " + binary;
            }
            else if (hexToBin[i] == '2')
            {
                binary = "0010 " + binary;
            }
            else if (hexToBin[i] == '3')
            {
                binary = "0011 " + binary;
            }
            else if (hexToBin[i] == '4')
            {
                binary = "0100 " + binary;
            }
            else if (hexToBin[i] == '5')
            {
                binary = "0101 " + binary;
            }
            else if (hexToBin[i] == '6')
            {
                binary = "0110 " + binary;
            }
            else if (hexToBin[i] == '7')
            {
                binary = "0111 " + binary;
            }
            else if (hexToBin[i] == '8')
            {
                binary = "1000 " + binary;
            }
            else if (hexToBin[i] == '9')
            {
                binary = "1001 " + binary;
            }
            else if (hexToBin[i] == 'A')
            {
                binary = "1010 " + binary;
            }
            else if (hexToBin[i] == 'B')
            {
                binary = "1011 " + binary;
            }
            else if (hexToBin[i] == 'C')
            {
                binary = "1100 " + binary;
            }
            else if (hexToBin[i] == 'D')
            {
                binary = "1101 " + binary;
            }
            else if (hexToBin[i] == 'E')
            {
                binary = "1110 " + binary;
            }
            else if (hexToBin[i] == 'F')
            {
                binary = "1111 " + binary;
            }
        }
        char zero = '0';
        string NewString = binary.TrimStart(zero);

        Console.WriteLine("Binary representation: {0}", NewString);
    }
}