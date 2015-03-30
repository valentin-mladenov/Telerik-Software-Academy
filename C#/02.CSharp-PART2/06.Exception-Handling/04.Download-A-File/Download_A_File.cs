using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;

//Write a program that downloads a file from Internet
//(e.g. http://www.devbg.org/img/Logo-BASD.jpg) and
//stores it the current directory. Find in Google
//how to download files in C#. Be sure to catch all
//exceptions and to free any used resources in the
//finally block.

class Download_A_File
{


    static void Main()
    {
        try
        {
            Console.Write("Enter URL Path to download image : ");
            string download = Console.ReadLine();
            Console.Write("Enter Filename : ");
            string file =  @"..\..\" + Console.ReadLine();

            WebClient wecClient = new WebClient();
            wecClient.DownloadFile(new Uri(download), file);

        }
        catch (ArgumentNullException ane)
        {
            Console.Error.WriteLine("The address or/and The fileName parameter is null.  " + ane.Message);
        }
        catch (WebException we)
        {
            Console.Error.WriteLine("WebException" + we.Message);
        }
        catch (InvalidOperationException ioe)
        {
            Console.Error.WriteLine("The local file specified by fileName is in use by another thread. " + ioe.Message);
        }
        catch (UriFormatException ufe)
        {
            Console.Error.WriteLine(ufe.Message);
        }
        finally
        {
            Console.WriteLine("Bye. :)");
        }
    }
}