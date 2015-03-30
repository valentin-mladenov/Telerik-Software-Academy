namespace MyStudentSystem.ConsoleApp
{
    using System;

    using MyStudentSystem.Data.StudentSystemData;
    using MyStudentSystem.Model;

    class MyStudentSystemConsoleApp
    {
        public static void Main()
        {
            var db = new StudentSystemData();

            var student = new Student { FullName = "Pesho Peshev"};

            db.Students.Add(student);
            db.SaveChanges();

            foreach (var stud in db.Students.All())
            {
                Console.WriteLine(stud.FullName);
            }
        }
    }
}