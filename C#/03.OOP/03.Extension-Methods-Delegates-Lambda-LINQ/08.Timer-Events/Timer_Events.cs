using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

//* 
//Read in MSDN about the keyword event in C#
//and how to publish events. Re-implement the
//above using .NET events and following the best practices.

public class TimerEvents
{
    public delegate void ExecuteMathod();

    public ExecuteMathod now;
    private Timer newTimer;

    public void OnHold(object obj, ElapsedEventArgs events)
    {
        now();
    }

    public void Run(int miliseconds)
    {
        newTimer.Elapsed += new ElapsedEventHandler(OnHold);
        newTimer.Interval = miliseconds;
        newTimer.Enabled = true;
    }

    public TimerEvents()
    {
        newTimer = new Timer(30000);
    }

    public static void Main()
    {
        TimerEvents execute = new TimerEvents();
        execute.now += TestMetnod;
        execute.Run(2000);

        Console.WriteLine("Press the Enter key to exit the program.");
        Console.ReadLine();
    }
    public static void TestMetnod()
    {
        Console.WriteLine("Message that appears every couple of seconds");
    }
}