using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_04.Point_3D
{
    class Point3DMain
    {
        static void Main()
        {
            //task one
            Point3D xyz1 = new Point3D() { pointX = 2, pointY = 3, pointZ = 4 };
            Point3D xyz2 = new Point3D() { pointX = 5, pointY = 23, pointZ = 7 };
            Console.WriteLine(xyz1);
            Console.WriteLine(xyz2);
           
            //task two
            Point3D point0 = Point3D.Point0;
            Console.WriteLine(Point3D.Point0);

            //task three
            Console.WriteLine(PointToPointCalc.DistanceCalc(xyz1, xyz2));

            //Task four
            string text = @"..\..\Path.txt";

            List<Path> paths = new List<Path>();
            Path first = new Path();
            Path second = new Path();

            first.Add(xyz1);
            first.AddAtIndex(0, xyz2);
            first.Add(new Point3D(9, 5, 9));
            first.Add(new Point3D(4, -6, -3));
            first.AddAtIndex(3, new Point3D(2, -5, 8));

            second.Add(new Point3D(1, 2, -7));
            second.Add(xyz2);
            second.AddAtIndex(0, xyz1);
            second.Add(new Point3D(-4, 4, -3));
            second.AddAtIndex(2, new Point3D(3, 6, 9));
            
            paths.Add(first);
            paths.Add(second);

            PathStorage.ReadFromFlie(text);
            PathStorage.WritheToFile(paths, text);
            List<Path> loadedPaths = PathStorage.ReadFromFlie(text);
            Console.WriteLine("Paths for save");
            Print(paths);
            Console.WriteLine("Loaded paths");
            Print(loadedPaths);

            Console.WriteLine();
        }

        private static void Print(List<Path> paths)
        {
            foreach (var item in paths)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
