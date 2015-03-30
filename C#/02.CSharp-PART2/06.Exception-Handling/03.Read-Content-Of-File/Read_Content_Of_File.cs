using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;

//Write a program that enters file name
//along with its full file path (e.g.
//C:\WINDOWS\win.ini), reads its contents
//and prints it on the console. Find in
//MSDN how to use System.IO.File.ReadAllText(…).
//Be sure to catch all possible exceptions
//and print user-friendly error messages.

class Read_Content_Of_File
{
    static void ReadFile(string file)
    {
        string text = File.ReadAllText(file);

        Console.WriteLine(text);
    }

    static void Main()
    {
        try
        {
            Console.WriteLine("Enter the path of the file to read:");
            string file = Console.ReadLine();

            ReadFile(file);
        }

        catch (ArgumentNullException ane)
        {
            Console.Error.WriteLine("Path is null. ", ane.Message);
        }
        catch (ArgumentException ae)
        {
            Console.Error.WriteLine("The Path is zero-length string or contains one or more invalid characters. \n" + ae.Message);
        }
        catch (PathTooLongException ptle)
        {
            Console.Error.WriteLine("The specified path, file name, or both exceed the system-defined maximum length. \n" + ptle.Message);
        }
        catch (DirectoryNotFoundException dnfe)
        {
            Console.Error.WriteLine("The specified path is invalid. \n" + dnfe.Message);
        }
        catch (FileNotFoundException fnfe)
        {
            Console.Error.WriteLine("The file specified in path was not found. \n" + fnfe.Message);
        }
        catch (NotSupportedException nse)
        {
            Console.Error.WriteLine("Path is in an invalid format. \n" + nse.Message);
        }
        catch (IOException ioe)
        {
            Console.Error.WriteLine(ioe.Message);
        }
        catch (UnauthorizedAccessException uoae)
        {
            Console.Error.WriteLine("Unauthorized Access. \n" + uoae.Message);
        }
        catch (SecurityException se)
        {
            Console.WriteLine("You don't have the required permission to access this file!" + se.Message);
        }
    }
}