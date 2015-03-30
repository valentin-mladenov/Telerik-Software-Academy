using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public static class PathStorage
{
    private static List<Path> pathStore;

    static PathStorage()
    {
        pathStore = new List<Path>();   
    }

    public static List<Path> ReadFromFlie(string text)
    {
        System.Text.Encoding encoding = System.Text.Encoding.GetEncoding(1251);
        StreamReader pathRead = new StreamReader(text, encoding);
        Point3D point = new Point3D();
        Path path = new Path();
        
        using (pathRead)
        {
            string row = pathRead.ReadLine();
            while (row != null)
            {
                string[] paths = row.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in paths)
                {
                    string[] points = item.Split(',');
                    if (points.Length == 3)
                    {
                        point.pointX = double.Parse(points[0]);
                        point.pointY = double.Parse(points[1]);
                        point.pointZ = double.Parse(points[2]);
                        path.Add(point);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("The coordinates must have exactly 3 points X, Y, Z.");
                    }
                }
                pathStore.Add(path);
                row = pathRead.ReadLine();
            }
        }
        return pathStore;
    }

    public static void WritheToFile(List<Path> pathStore, string text)
    {
        System.Text.Encoding encoding = System.Text.Encoding.GetEncoding(1251);
        StreamWriter pathsWrithe = new StreamWriter(text);
        StringBuilder str = new StringBuilder();

        foreach (var path in pathStore)
        {
            foreach (var item in path.PathCount)
            {
                str.Append(string.Format("{0}, {1}, {2} /", item.pointX, item.pointY, item.pointZ));
            }
            pathsWrithe.Write(str.ToString());
            str.Clear();
        }
        pathsWrithe.Close();
    }
}