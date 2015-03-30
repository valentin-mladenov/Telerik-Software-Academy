using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_15.Students_Class
{
    public static class ExtentionMethods
    {
        public static void StudentsByGroupName(this List<Student> students)
        {
            var result = students.OrderBy(x => x.Group.DepartamentName)
                                 .ThenBy(x=>x.FirstName)
                                 .ThenBy(x=>x.LastName).ToList();

            foreach (var item in result)
            {
                Console.WriteLine("From " + item.Group.DepartamentName + ", " + item.FirstName + " " + item.LastName);
            }
            Console.WriteLine();
        }
    }
}
