using System;

//Write a program that, depending on the user's choice inputs int, double or string 
//variable. If the variable is integer or double, increases it with 1. If the variable 
//is string, appends "*" at its end. The program must show the value of that variable
//as a console output. Use switch statement.


class Int_Double_Or_String_Variable
{
    static void Main()
    {
        Console.WriteLine("Please enter 1 for INT, 2 for DOUBLE or 3 for STRING.");        
        byte anyVariable = byte.Parse(Console.ReadLine());

        switch (anyVariable)
        {
            case 1: Console.WriteLine("Enter your INT number:");
                    int intVariable = int.Parse(Console.ReadLine());
                    Console.WriteLine("INT number + 1: " + (intVariable + 1)); break;

            case 2: Console.WriteLine("Enter your DOUBLE number:");
                    double doubleVariable = double.Parse(Console.ReadLine());
                    Console.WriteLine("DOUBLE number + 1: " + (doubleVariable + 1)); break;

            case 3: Console.WriteLine("Enter your STRING variable:");
                    string stringVariable = Console.ReadLine();
                    Console.WriteLine("STRING variable + *: " + stringVariable + "*"); break;

            default: Console.WriteLine("You must enter 1, 2 or 3. Incorrect input!");
                    Main (); break;
        }
    }
}