using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StudentsMain
{
    static void Main()
    {
        var students = new[]
        {
            new {FirstName = "Ivan", LastName = "Ivanov", Age = 17},
            new {FirstName = "Georgi",  LastName = "Simeonov", Age = 19},
            new {FirstName = "Ivan",  LastName = "Todorov", Age = 20},
            new {FirstName = "Petyr",  LastName = "Chipev", Age = 21},
            new {FirstName = "Anton",  LastName = "Donchev", Age = 22},
            new {FirstName = "Filip",  LastName = "Andreev", Age = 23},
            new {FirstName = "Svetslav",  LastName = "Bozov", Age = 28},
        };

        // Tas 03. First name is before last name alphabetically.
        Console.WriteLine("Task 03: First name is before last name alphabetically.");
        var firstLast = from student in students
                        where student.FirstName.CompareTo(student.LastName) < 0
                        select student;
        foreach (var item in firstLast)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine();

        // Task 04. first name and last name of all students with age between 18 and 24.
        Console.WriteLine("Task 04: first name and last name of all students with age between 18 and 24.");
        var between = from student in students
                      where student.Age > 18 && student.Age < 24
                      select student;
        foreach (var item in between)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine();

        // Task 05. Using the extension methods OrderBy() and ThenBy() with lambda expressions
        //sort the students by first name and last name in descending order. Rewrite the same with LINQ.
        Console.WriteLine("Task 05: Extension methods OrderBy() and ThenBy() in descending order with lambda expr.");

        var studSortLambda = students.OrderByDescending(stud => stud.FirstName)
                                .ThenByDescending(stud => stud.LastName);
        foreach (var item in studSortLambda)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine();

        // Task 05. Using the extension methods OrderBy() and ThenBy() in descending order with LINQ.
        // Simply dosen't work!?
        Console.WriteLine("Task 05: Extension methods OrderBy() and ThenBy() in descending order with LINQ.");
        var studSortLINQ = from stud in students
                           orderby stud.FirstName descending, stud.LastName descending
                           select stud;
        foreach (var item in students)
        {
            Console.WriteLine(item.ToString());
        }
    }
}