using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Students_And_Workers
{
    class StudentsAndWorkersMain
    {
        static void Main()
        {
            List<Student> students = new List<Student>
            {
                new Student("Pesho", "Goshev", 12), new Student("Gosho", "Peshev", 5),
                new Student("Velina", "Dimova", 5), new Student("Valjo", "Ganev", 6),
                new Student("Anna", "Petrova", 21), new Student("Misho", "Kalchev", 1),
                new Student("Nikolaj", "Kolev", 4), new Student("Polina", "Krasteva", 34),
                new Student("Belica", "Paunova", 3), new Student("Marko", "Slavov", 2),
            };

            List<Worker> workers = new List<Worker>
            {
                new Worker("Elena", "Ganeva", 330.23, 5), new Worker("Delqn", "Petrov", 2130.23, 3),
                new Worker("Georgi", "Ivanov", 830.23, 8), new Worker("Ivan", "Cholakov", 530.23, 8),
                new Worker("Venci", "Milanov", 250.23, 6), new Worker("Sabina", "Todorova", 630.23, 4),
                new Worker("Katq", "Katelieva", 2030.53, 8), new Worker("Teodora", "Ilieva", 1230.23, 8),
                new Worker("Bashibuzuk", "Kurdjalijski", 430.23, 8), new Worker("Chernica", "Beleva", 200.24, 8),
            };
            List<Human> humans = new List<Human>();

            var sortStudsByGrade = from stud in students
                                   orderby stud.Grade
                                   select new Human(stud.FirstName, stud.LastName);
            foreach (var item in sortStudsByGrade)
            {
                humans.Add(item);
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var moneyPerHour = from work in workers
                               orderby work.MoneyPerHour()
                               select new Human(work.FirstName, work.LastName);
            foreach (var item in moneyPerHour)
            {
                humans.Add(item);
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var sortHumans = from human in humans
                             orderby human.FirstName, human.LastName
                             select human;
            foreach (var item in sortHumans)
	        {
                Console.WriteLine(item);
	        }
            Console.WriteLine();
        }
    }
}
