

namespace _1.All_Employees_From_TA_DB
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;

    public class WorkingWithTelerikAcademyDB
    {
        // Using Entity Framework write a SQL query to select all employees from the
        // Telerik Academy database and later print their name, department and town.
        // Try the both variants: with and without .Include(…). Compare the number
        // of executed SQL statements and the performance.
        public static void Task1AllEmployees(TelerikAcademyDB db)
        {
            var sw = new Stopwatch();
            Console.WriteLine("I provide a Task1.trc file with connections. In TRC-files folder.");
            // first connection to DB ignored
            var start = db.Employees.Count();

            sw.Start();
            var querySelect =
                db.Employees.Select(
                    employee =>
                    new
                        {
                            Name = employee.FirstName + " " + employee.LastName,
                            Department = employee.Department.Name,
                            Town = employee.Address.Town.Name
                        }).ToList();
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine("Correct way one connection: " + sw.ElapsedMilliseconds + " milliseconds.");

            sw.Restart();
            var queryWrong = db.Employees.ToList();

            Console.WriteLine("Wrong way with many connections: " + sw.ElapsedMilliseconds + " milliseconds.");

            Console.WriteLine();
            Console.WriteLine(
                "On my PC the correct way pereform fast as the wrong way, but with only one connection. The wrong way pereformance will degrade fast if the database is bigger or not on local level.");
        }

        // Using Entity Framework write a query that selects all employees from the
        // Telerik Academy database, then invokes ToList(), then selects their addresses,
        // then invokes ToList(), then selects their towns, then invokes ToList() and
        // finally checks whether the town is "Sofia". Rewrite the same in more
        // optimized way and compare the performance
        public static void Task2AllEmployees(TelerikAcademyDB db)
        {
            var sw = new Stopwatch();
            Console.WriteLine("I provide a Task2.trc file with connections. In TRC-files folder.");

            // first connection to DB ignored
            var start = db.Employees.Count();

            sw.Start();
            var querySelect =
                db.Employees.Select(
                    employee =>
                    new
                        {
                            Name = employee.FirstName + " " + employee.LastName,
                            Address = employee.Address.AddressText,
                            Town = employee.Address.Town.Name
                        }).Where(town => town.Town == "Sofia").ToList();
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine("Correct way one connection: " + sw.ElapsedMilliseconds + " milliseconds.");

            foreach (var employee in querySelect)
            {
                Console.WriteLine(employee.Name + " lives at " + employee.Address + " in " + employee.Town + ".");
            }

            sw.Restart();
            var queryWrong =
                db.Employees.ToList()
                    .Select(address => address.Address)
                    .ToList()
                    .Select(town => town.Town)
                    .ToList()
                    .Where(townName => townName.Name == "Sofia")
                    .ToList();
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine("Wrong way with many connections: " + sw.ElapsedMilliseconds + " milliseconds.");

            foreach (var town in queryWrong)
            {
                Console.WriteLine("Town name: " + town.Name + ".");
            }


            Console.WriteLine();
            Console.WriteLine(
                "On my PC the correct way pereform 2.1 times faster than the wrong way.");
        }

        public static void Main()
        {
            var db = new TelerikAcademyDB();

            using (db)
            {
                Console.WriteLine("If not working check the connection string.");
                Console.WriteLine();
                Console.WriteLine("Task1---------------------------------------");
                Task1AllEmployees(db);
                Console.WriteLine("Task2---------------------------------------");
                Task2AllEmployees(db);
            }
        }
    }
}