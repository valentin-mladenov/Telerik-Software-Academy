using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class GSMCallHistoryTest : GSM
{
    private uint testCount;

    public GSMCallHistoryTest()
    {
    }

    public void AddCalls(uint testCount)
    {
        this.testCount = testCount;
        Random rand = new Random();

        for (int i = 0; i < this.testCount; i++)
        {
            AddCallToHistory(DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), (uint)rand.Next(100000000, 999999999), (uint)rand.Next(10, 200));
        }
    }

    public void DeleteLongestCall()
    {
        uint longestDuration = 0;
        Call longestCall = new Call();

        foreach (Call call in this.CallHistory)
        {
            if (call.Duration > longestDuration)
            {
                longestCall = call;
            }
        }
        this.DeleteCall(longestCall);
    }

    public override string ToString()
    {
        if (CallHistory.Count > 0)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < CallHistory.Count; i++)
            {
                str.Append(Environment.NewLine);
                str.Append("Date: " + this.CallHistory[i].Date);
                str.Append(Environment.NewLine);
                str.Append("Time: " + this.CallHistory[i].Time);
                str.Append(Environment.NewLine);
                str.Append("Tel. number: " + this.CallHistory[i].DialedPhone);
                str.Append(Environment.NewLine);
                str.Append("Duration: " + this.CallHistory[i].DurationMinSec);
                str.Append(Environment.NewLine);
            }
            return str.ToString();
        }
        else
        {
            return "History is empty!";
        }
    }
}