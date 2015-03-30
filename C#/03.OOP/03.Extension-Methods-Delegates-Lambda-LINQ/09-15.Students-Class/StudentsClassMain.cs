using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_15.Students_Class
{
    public class StudentsClassMain
    {
        static void PrintForEach(IEnumerable<Student> studs)
        {
            foreach (var item in studs)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static void GroupNumber2LINQ(List<Student> studs)
        {
            const int groupNum = 2;
            var result = from stud in studs
                       orderby stud.FirstName
                       where (stud.GroupNumber == groupNum)
                       select stud;
            PrintForEach(result);
        }

        static void GroupNumber2Lambda(List<Student> studs)
        {
            var result = studs.FindAll(x => x.GroupNumber == 2)
                              .OrderBy(stud => stud.FirstName);
            PrintForEach(result);
        }

        static void EmailInAbvBg(List<Student> studs)
        {
            const string email = "abv.bg";
            var result = from stud in studs
                         where stud.Email.Contains(email)
                         select stud;
            PrintForEach(result);
        }

        static void PhonesInSofia(List<Student> studs)
        {
            const string phone = "02";
            var result = from stud in studs
                         where stud.Telephone.StartsWith(phone)
                         select stud;
            PrintForEach(result);
        }

        static void Exelent6(List<Student> studs)
        {
            const int mark = 6;
            var result = from stud in studs
                         where stud.Marks.Contains(mark)
                         select new { FullName = stud.FirstName + " " + stud.LastName, Marks = stud.AllMarks() };

            foreach (var item in result)
            {
                Console.WriteLine("{0} has marks {1}.", item.FullName, item.Marks);
            }
            Console.WriteLine();
        }

        static void Weak2x2(List<Student> studs)
        {
            const int mark = 2;
            const int count = 2;
            var result = from stud in studs
                         where stud.Marks.Count(x => x == mark) == count
                         select new { FullName = stud.FirstName + " " + stud.LastName, Marks = stud.AllMarks() };

            foreach (var item in result)
            {
                Console.WriteLine("{0} has marks {1}.", item.FullName, item.Marks);
            }
            Console.WriteLine();
        }

        static void Marks2006(List<Student> studs)
        {
            const string year = "06";
            const int startIndex = 4;
            int strLength = year.Length;

            var result = from stud in studs
                         where stud.FN.Substring(startIndex, strLength) == year
                         select stud;

            foreach (var item in result)
            {
                Console.WriteLine(string.Join(", ",item.Marks));
            }
            Console.WriteLine();
        }

        static void MathGroup(List<Student> studs)
        {
            const string departament = "Mathematics";

            var result = from stud in studs
                         where stud.Group.DepartamentName == departament
                         select stud;

            foreach (var item in result)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
            Console.WriteLine();
        }

        static void StudentsByGroupNameLINQ(List<Student> studs)
        {
            var result = from stud in studs
                         orderby stud.Group.DepartamentName, stud.FirstName, stud.LastName
                         select stud;

            foreach (var item in result)
            {
                Console.WriteLine("From " + item.Group.DepartamentName +", "+ item.FirstName + " " + item.LastName);
            }
            Console.WriteLine();
        }

        static void Main()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Grigor", "Petrov", "316106", "02876455", "grigor@abv.bg", new List<int> {3, 4}, 2, new Group(15, "Physics")),
                new Student("Petar", "Marinov", "316206", "02899123", "petar@gmail.com", new List<int> {6, 5, 2, 6}, 2, new Group(3, "Mathematics")),
                new Student("Dobri", "Gospodinov", "324806", "73654789", "dobri@abv.bg", new List<int> {6, 5, 6}, 4, new Group(9, "Medicine")),
                new Student("Anna", "Dimova", "395103", "52999999", "anna@gmail.com", new List<int> {6, 6}, 2, new Group(11, "Mathematics")),
                new Student("Penka", "Stoicheva", "318206", "0899111111", "penka@abv.bg", new List<int>{2, 2, 3, 3}, 5, new Group(22, "Mathematics")),
                new Student("Anetana", "Dimovska", "395173", "52998999", "antna@gmail.com", new List<int> {2, 4, 3, 2, 3}, 1, new Group(11, "Chemistry"))
            };

            //Task 09: group number 2 ordered by first name, LINQ
            GroupNumber2LINQ(students);

            // Task 10: group number 2 ordered by first name, Lambda
            GroupNumber2Lambda(students);

            // task 11: Extract all students that have email in abv.bg. Use string methods and LINQ.
            EmailInAbvBg(students);

            // Task 12: Extract all students with phones in Sofia. Use LINQ.
            PhonesInSofia(students);

            // Task 13: Select all students that have at least one mark Excellent (6) into a new
            // anonymous class that has properties – FullName and Marks. Use LINQ.
            Exelent6(students);

            // Task 14: Write down a similar program that extracts the
            // students with exactly two marks "2". Use extension methods.
            Weak2x2(students);

            // Task 15: Extract all Marks of the students that enrolled in 2006.
            // (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
            Marks2006(students);

            // Task 16: * Create a class Group with properties GroupNumber and DepartmentName.
            // Introduce a property Group in the Student class. Extract all students from "Mathematics" department. Use the Join operator.
            MathGroup(students);

            // Task 18: Create a program that extracts all students grouped by GroupName and then prints them to the console. Use LINQ.
            StudentsByGroupNameLINQ(students);

            // Task 19: Rewrite the previous using extension methods.
            students.StudentsByGroupName();
        }
    }
}
