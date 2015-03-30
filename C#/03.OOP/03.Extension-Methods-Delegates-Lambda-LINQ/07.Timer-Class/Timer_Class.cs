using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

//Using delegates write a class Timer that
//has can execute certain method at each t seconds.

class Timer_Class
{
    public delegate void Timer(string param, int seconds, int times);

    public static void Loop(string param, int seconds, int times)
    {
        Stopwatch stop = new Stopwatch();
        stop.Start();
        while (times!=0)
        {
            if (stop.ElapsedMilliseconds == seconds * 1000)
            {
                Console.WriteLine(param);
                stop.Restart();
                times--;
            }
        }
    }


    static void Main()
    {
        Timer time = new Timer(Loop);
        time("Tick-Tock", 1, 5);
    }
}