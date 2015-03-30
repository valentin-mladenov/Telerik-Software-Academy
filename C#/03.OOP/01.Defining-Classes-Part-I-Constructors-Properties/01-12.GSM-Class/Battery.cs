using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Battery
{
    public enum BatteryType
    {
        Non, LiPoly, LiIon, NiMH, NiCd
    }

    private BatteryType batteryTypes;
    private string batteryModel;
    private float? idleHours;
    private float? talkHours;

    public BatteryType BatteryTypes
    {
        get { return batteryTypes; }
    }

    public Battery()
    {

    }

    public Battery(string batteryModel)
    {
        this.batteryModel = batteryModel;
        idleHours = null;
        talkHours = null;
    }

    public Battery(string batteryModel, float idleHours, float talkHours)
        : this(batteryModel)
    {
        if (idleHours < 0)
        {
            throw new ArgumentOutOfRangeException("Incorrect idle hours!");
        }
        else
        {
            this.idleHours = idleHours;
        }
        if (talkHours < 0)
        {
            throw new ArgumentOutOfRangeException("Incorrect talk hours!");
        }
        else
        {
            this.talkHours = talkHours;
        }
    }

    public Battery(BatteryType batteryTypes, string batteryModel, float idleHours, float talkHours)
        : this(batteryModel, idleHours, talkHours)
    {
        this.batteryTypes = batteryTypes;
    }

    public string BatteryModel
    {
        get { return this.batteryModel; }
        set { batteryModel = value; }
    }

    public float? IdleHours
    {
        get { return this.idleHours; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Incorrect idle hours!");
            }
            else
            {
                idleHours = value;
            }
        }
    }

    public float? TalkHours
    {
        get { return this.talkHours; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Incorrect talk hours!");
            }
            else
            {
                talkHours = value;
            }
        }
    }
}