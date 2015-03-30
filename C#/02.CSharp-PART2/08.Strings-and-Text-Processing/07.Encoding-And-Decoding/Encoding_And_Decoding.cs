using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that encodes and decodes
//a string using given encryption key
//(cipher). The key consists of a sequence
//of characters. The encoding/decoding is
//done by performing XOR (exclusive or)
//operation over the first letter of the
//string with the first of the key, the
//second – with the second, etc. When
//the last key character is reached,
//the next is the first.

class Encoding_And_Decoding
{
    static string EncriptDecript(string text, string key)
    {
        StringBuilder encription = new StringBuilder(text.Length);

        for (int i = 0; i < text.Length; i++)
        {
            encription.Append((char)(text[i] ^ key[i % key.Length]));
        }
        return encription.ToString();
    } 
    static void Main()
    {
        string text = "Write a program that encodes and decodes a string using given encryption key (cipher). The key consists of a sequence of characters. The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, the second – with the second, etc. When the last key character is reached, the next is the first.";
        string key = "hghyujkmnbhjklkjnhjuki";

        // If you want you can enter the text and key yourself. :)
        //string text = Console.ReadLine();
        //string key = Console.ReadLine();

        string encripted = EncriptDecript(text, key);

        Console.WriteLine(encripted);

        string decripted = EncriptDecript(encripted, key);

        Console.WriteLine(decripted);
    }
}