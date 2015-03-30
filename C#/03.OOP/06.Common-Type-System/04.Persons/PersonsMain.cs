using System;
using System.Linq;

//Create a class Person with two fields – name and age.
//Age can be left unspecified (may contain null value. 
//Override ToString() to display the information of a
//person and if age is not specified – to say so.
//Write a program to test this functionality.

namespace _04.Persons
{
    class PersonsMain
    {
        static void Main()
        {
            Person pers = new Person("Pesho");
            Person pers2 = new Person("Valjo", 35);

            Console.WriteLine(pers.ToString());
            Console.WriteLine(pers2.ToString());
        }
    }
}
