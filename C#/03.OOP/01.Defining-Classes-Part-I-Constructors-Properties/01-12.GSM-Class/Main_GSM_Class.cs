using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Here are all classes combine in one exercise
//i made a big mess tring to separate them.
//So made them whole.

//Here are all exercises.


class All_GSM_Class
{
    static void Main()
    {
        decimal price = 360.99M;
        GSM nokia = new GSM("6600", "Nokia");
        nokia.Price = price;
        nokia.Owner = "Valjo";

        nokia.Battery.BatteryModel = "BT-L4";
        nokia.BatteryTypes = Battery.BatteryType.NiCd;
        nokia.Battery.IdleHours = 3.26f;
        nokia.Battery.TalkHours = 1.02f;

        nokia.Display.DisplayColors = 16700000;
        nokia.Display.DisplaySize = 5;

        Console.WriteLine(nokia.ToString());


        //TEST GSM Class
        GSM iPhone = GSM.IPhone4S;
        iPhone.Battery.BatteryModel = "Apple Special";
        Console.WriteLine(iPhone);

        GSM[] gsms = new GSM[] 
            { 
                new GSM("N70", "Nokia"),
                new GSM("Sony Ericson K570i", "Sony", 250, "Pesho", new Battery(Battery.BatteryType.LiIon,"model1", 20f,5f),new Display(2,256)),
                new GSM("Galaxy S3III", "Samsung", 500, "Goro", new Battery(Battery.BatteryType.NiCd,"model4", 22f,7f),new Display(4,16700000)),
                new GSM("N70", "Nokia", 270, "Ivan", new Battery(Battery.BatteryType.LiIon, "model2", 20f,5f),new Display()),
                new GSM("Galaxy S3III", "Samsung", 150, "Stoyan", new Battery(),new Display(7,16700000)),               
            };

        foreach (GSM gsm in gsms)
        {
            Console.WriteLine(gsm.ToString());
            Console.WriteLine("----------------------------");
        }


        //GSMCallHistoryTest 
        GSMCallHistoryTest testPhone = new GSMCallHistoryTest();
        testPhone.AddCalls(5);

        Console.WriteLine(testPhone);
        Console.WriteLine("Price for all phone calls in history: {0}", Math.Round(testPhone.TotalPriceOfCalls(), 2) + " лв.");
        testPhone.DeleteLongestCall();
        //Console.WriteLine(testPhone);
        Console.WriteLine("Price for all phone calls in history: {0}", Math.Round(testPhone.TotalPriceOfCalls(), 2) + " лв.");
        testPhone.DeleteHistory();
        Console.WriteLine("History is deleted!");
        Console.WriteLine(testPhone);
    }
}