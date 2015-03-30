using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Call
{
    private string date;
    private string time;
    private uint dialedPhone;
    private uint duration;
    private string durationMinSec;
    private uint seconds;
    private uint minutes;

    public string Date
    {
        get { return this.date; }
        set { date = value; }
    }

    public string Time
    {
        get { return this.time; }
        set { date = value; }
    }

    public uint DialedPhone
    {
        get { return this.dialedPhone; }
        set { dialedPhone = value; }
    }

    public uint Duration
    {
        get { return this.duration; }
        set { duration = value; }
    }

    public string DurationMinSec
    {
        get
        {
            seconds = duration % 60;
            minutes = duration / 60;
            return durationMinSec = minutes.ToString() + ":" + seconds.ToString();
        }
    }

    public uint Minutes
    {
        get { return this.minutes; }
    }

    public uint Seconds
    {
        get { return this.seconds; }
    }

    public Call()
    {
    }

    public Call(string date, string time, uint dialedPhone, uint duration)
    {
        this.date = date;
        this.time = time;
        this.dialedPhone = dialedPhone;
        this.duration = duration;
    }
}