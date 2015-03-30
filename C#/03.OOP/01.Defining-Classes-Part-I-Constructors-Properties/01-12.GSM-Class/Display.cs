using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Display
{
    private float? displaySize;
    private int? displayColors;

    public float? DisplaySize
    {
        get { return this.displaySize; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Incorrect Display size!");
            }
            else
            {
                displaySize = value;
            }
        }
    }

    public int? DisplayColors
    {
        get { return this.displayColors; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Incorrect Display colors!");
            }
            else
            {
                displayColors = value;
            }
        }
    }

    public Display()
    {
    }

    public Display(float displaySize)
    {
        if (displaySize < 0)
        {
            throw new ArgumentOutOfRangeException("Incorrect Display size!");
        }
        else
        {
            this.displaySize = displaySize;
        }
        displayColors = null;
    }

    public Display(int displayColors)
    {
        if (displayColors < 0)
        {
            throw new ArgumentOutOfRangeException("Incorrect Display colors!");
        }
        else
        {
            this.displayColors = displayColors;
        }
        displaySize = null;
    }

    public Display(float displaySize, int displayColors)
        : this(displaySize)
    {
        if (displayColors < 0)
        {
            throw new ArgumentOutOfRangeException("Incorrect Display colors!");
        }
        else
        {
            this.displayColors = displayColors;
        }
    }
}