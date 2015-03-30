using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class PointToPointCalc
{
    public static double DistanceCalc(Point3D first, Point3D second)
    {
        double sideX = first.pointX - second.pointX;
        double sideY = first.pointY - second.pointY;
        double sideZ = first.pointZ - second.pointZ;

        double distance = Math.Sqrt(sideX * sideX + sideY * sideY + sideZ * sideZ);

        return distance;
    }
}