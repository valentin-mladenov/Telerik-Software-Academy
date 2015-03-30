using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


public class Path
{
    private List<Point3D> pathCount = new List<Point3D>();

    public List<Point3D> PathCount
    {
        get { return this.pathCount; }
    }

    public void Add(Point3D point)
    {
        pathCount.Add(point);
    }

    public void AddAtIndex(int index, Point3D point)
    {
        if (index > pathCount.Count)
        {
            pathCount.Capacity = index;
            pathCount.Insert(index, point);
        }
        else
        {
            pathCount.Insert(index, point);
        }
    }

    public void RemovePoint(Point3D point)
    {
        pathCount.Remove(point);
    }

    public void DeleteAtIndex(int index)
    {
        if (index > pathCount.Count)
        {
            throw new ArgumentOutOfRangeException("Index out of range.");
        }
        else
        {
            pathCount.RemoveAt(index);
        }
    }

    public void ClearAll()
    {
        pathCount.Clear();
    }

    public override string ToString()
    {
        StringBuilder str = new StringBuilder();
        foreach (var point in pathCount)
        {
            str.Append(point.ToString());
            str.Append(" / ");
        }
        
        return str.ToString();
    }
}