using System;

class Declare_Boolean_Variable
{
    static void Main()
    {
        bool isFemale = false;
        char yourGender;
        Console.WriteLine("Are you Female.");
        Console.WriteLine("Press \"Y\" if yes and \"N\" if no. ");
        yourGender = (char)Console.Read();
        if (yourGender == 'N')
        {
            Console.WriteLine("The statement is {0}.", isFemale);
        }
        else
        {
            if (yourGender == 'Y')
            {
                Console.WriteLine("The statement is {0}.", !isFemale);
            }
            else
            {
                Console.WriteLine("Wrong letter.");
            }
        }
    }
}
