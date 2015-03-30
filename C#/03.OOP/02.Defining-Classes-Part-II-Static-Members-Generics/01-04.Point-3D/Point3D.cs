using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public struct Point3D
{
    public double pointX { get; set; }
    public double pointY { get; set; }
    public double pointZ { get; set; }

    public static readonly Point3D point0 = new Point3D() { pointX = 0, pointY = 0, pointZ = 0 };

    public static Point3D Point0
    {
        get { return point0; }
    }

    public Point3D(int x, int y, int z)
        : this()
    {
        pointX = x;
        pointY = y;
        pointZ = z;
    }

    public override string ToString()
    {
        StringBuilder str = new StringBuilder();
        str.Append(pointX + ", " + pointY + ", " + pointZ);

        return str.ToString();
    }
}