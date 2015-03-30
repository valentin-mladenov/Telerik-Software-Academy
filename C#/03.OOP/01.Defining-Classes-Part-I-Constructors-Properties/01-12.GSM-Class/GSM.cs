using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GSM
{
    private const decimal callPrice = 0.37M;

    public Display Display = new Display();
    public Battery Battery = new Battery();
    public Battery.BatteryType BatteryTypes;

    private static GSM iPhone4S;
    private string model;
    private string manifacturer;
    private decimal? price;
    private string owner;
    private static List<Call> callHistory = new List<Call>();
    private decimal totalPriceOfCalls;

    public decimal TotalPriceOfCalls()
    {
        decimal totalMin = 0;
        decimal totalSecs = 0;
        for (int i = 0; i < callHistory.Count; i++)
        {
            totalMin = (callHistory[i].Minutes * callPrice) + totalMin;
            totalSecs = callHistory[i].Seconds * (callPrice / 60) + totalSecs;
        }
        return totalPriceOfCalls = totalMin + totalSecs;
    }

    public decimal CallPrice
    {
        get { return callPrice; }
    }

    public List<Call> CallHistory
    {
        get { return callHistory; }
    }

    public void AddCall(Call call)
    {
        callHistory.Add(call);
    }

    public virtual void AddCallToHistory(string date, string time, uint dialedPhone, uint duration)
    {
        Call call = new Call(date, time, dialedPhone, duration);
        callHistory.Add(call);
    }

    public bool DeleteCall(Call call)
    {
        for (int i = 0; i < callHistory.Count; i++)
        {
            if (callHistory[i].Date == call.Date &&
                callHistory[i].DialedPhone == call.DialedPhone &&
                callHistory[i].Duration == call.Duration &&
                callHistory[i].Time == call.Time)
            {
                callHistory.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public void DeleteHistory()
    {
        callHistory.Clear();
    }

    public static GSM IPhone4S
    {
        get { return iPhone4S; }
    }

    static GSM()
    {
        iPhone4S = new GSM("iPhone4S", "Apple");
        iPhone4S.BatteryTypes = Battery.BatteryType.LiIon;
        iPhone4S.Display.DisplaySize = 4;
        iPhone4S.Display.DisplayColors = 16700000;
    }

    public GSM()
    {
    }

    public GSM(string model, string manifacturer)
    {
        this.model = model;
        this.manifacturer = manifacturer;
        price = null;
        owner = null;
    }

    public GSM(string model, string manifacturer, decimal price)
        : this(model, manifacturer)
    {
        if (price < 0)
        {
            throw new ArgumentOutOfRangeException("Incorrect price!!!");
        }
        else
        {
            this.price = price;
        }
        owner = null;
    }

    public GSM(string model, string manifacturer, decimal price, string owner)
        : this(model, manifacturer, price)
    {
        this.owner = owner;
    }

    public GSM(string model, string manifacturer, decimal price, string owner,
        Battery Battery, Display Display)
        : this(model, manifacturer, price, owner)
    {
        this.Battery = Battery;
        this.Display = Display;
    }

    //public GSM(string model, string manifacturer, decimal price, string owner,
    //Battery Battery, Display Display, decimal callPrice)
    //    : this(model, manifacturer, price, owner, Battery, Display)
    //{
    //    this.callPrice = callPrice;
    //}

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public string Manifacturer
    {
        get { return this.manifacturer; }
        set { this.manifacturer = value; }
    }

    public string Owner
    {
        get { return this.owner; }
        set { this.owner = value; }
    }

    public decimal? Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Incorrect price!!!");
            }
            else
            {
                this.price = value;
            }
        }
    }

    public override string ToString()
    {
        StringBuilder str = new StringBuilder();
        str.Append("GSM Info");
        str.Append(Environment.NewLine);
        str.Append("GSM model: " + Model);
        str.Append(Environment.NewLine);
        str.Append("GSM Manifacturer: " + Manifacturer);
        if (Price != null)
        {
            str.Append(Environment.NewLine);
            str.Append("GSM Price: " + Price + " $.");
        }
        if (Owner != null)
        {
            str.Append(Environment.NewLine);
            str.Append("GSM owner: " + Owner);
        }
        if (Battery.BatteryModel != null || Battery.IdleHours != null ||
            Battery.TalkHours != null || BatteryTypes != Battery.BatteryType.Non)
        {
            str.Append(Environment.NewLine);
            str.Append(Environment.NewLine);
            str.Append("Battery info.");
            if (Battery.BatteryModel != null)
            {
                str.Append(Environment.NewLine);
                str.Append("Battery model: " + Battery.BatteryModel);
            }
            if (Battery.IdleHours != null)
            {
                str.Append(Environment.NewLine);
                str.Append("Battery idle hours: " + Battery.IdleHours);
            }
            if (Battery.TalkHours != null)
            {
                str.Append(Environment.NewLine);
                str.Append("Battery talk hours: " + Battery.TalkHours);
            }
            if (BatteryTypes != Battery.BatteryType.Non)
            {
                str.Append(Environment.NewLine);
                str.Append("Battery type: " + BatteryTypes);
            }
        }
        if (Display.DisplaySize != null || Display.DisplayColors != null)
        {
            str.Append(Environment.NewLine);
            str.Append(Environment.NewLine);
            str.Append("Display info.");
            if (Display.DisplaySize != null)
            {
                str.Append(Environment.NewLine);
                str.Append("GSM display size: " + Display.DisplaySize + " inches.");
            }
            if (Display.DisplayColors != null)
            {
                str.Append(Environment.NewLine);
                str.Append("GSM display colors: " + Display.DisplayColors);
            }
        }
        str.Append(Environment.NewLine);
        return str.ToString();
    }
}