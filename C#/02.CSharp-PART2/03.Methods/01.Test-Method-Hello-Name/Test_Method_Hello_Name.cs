using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a method that asks the user for
//his name and prints “Hello, <name>”
//(for example, “Hello, Peter!”).
//Write a program to test this method.


class Test_Method_Hello_Name
{
    static void PrintHello(string name)
    {       
        Console.WriteLine("Hello, {0}", name);
    }

    static void Main()
    {
        Console.WriteLine("Enter name:");
        string name = Console.ReadLine();

        PrintHello(name);
    }
}