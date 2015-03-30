using System;

                    //A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a 
                    //phone number. Write a program that reads the information about a company and its manager and prints them on the console.


class Information_About_Company_And_Manager
{
    static void Main()
    {
        Console.WriteLine("Please enter the name of the company:");
        string companyName = Console.ReadLine();
        Console.WriteLine("Please enter the company's address:");
        string companyAddress = Console.ReadLine();
        Console.WriteLine("Please enter the phone number of the company:");
        long companyPhone = long.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the company's fax number:");
        long companyFax = long.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the website of the company:");
        string companyWebsite = Console.ReadLine();
        Console.WriteLine("Please enter the manager's first name:");
        string firstName = Console.ReadLine();
        Console.WriteLine("Now please enter the manager's last name:");
        string lastName = Console.ReadLine();
        Console.WriteLine("Please enter the age of the manager:");
        byte managerAge = byte.Parse(Console.ReadLine());
        Console.WriteLine("And at last, but not least the manager's phone number:");
        long managerPhone = long.Parse(Console.ReadLine());
        string managerFullName = firstName + " " + lastName;

        Console.WriteLine("The company {0} with adress {1} can be contacted via phone: {2}", companyName,companyAddress,companyPhone);
        Console.WriteLine("fax:{0} or on-line on:{1} and have {2} for manager.", companyFax, companyWebsite, managerFullName);
        Console.WriteLine("If you want to contact it's the manager {0} who is {1} years old, you can do that on his private phone: {2}.", managerFullName, managerAge, managerPhone);
    }
}