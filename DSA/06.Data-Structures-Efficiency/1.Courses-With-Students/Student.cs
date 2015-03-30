// A text file students.txt holds information about
// students and their courses in the following format:
// Kiril  | Vanov    | C#
// Stefka | Nikolova | SQL
// Stela  | Mineva   | Java
// Milena | Petrova  | C#
// Ivan   | Grigorov | C#
// Ivan   | Kolev    | SQL
// Using SortedDictionary<K,T> print the courses in alphabetical order and
// for each of them prints the students ordered by family and then by name:
// Expected output:
// C#: Ivan Grigorov, Kiril Ivanov, Milena Petrova
// Java: Stela Mineva
// SQL: Ivan Kolev, Stefka Nikolova

namespace _1.Courses_With_Students
{
    using System;

    public class Student : IComparable<Student>
    {
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        public int CompareTo(Student other)
        {
            if (this.LastName == other.LastName)
            {
                return string.Compare(this.FirstName, other.FirstName, StringComparison.Ordinal);
            }

            return string.Compare(this.LastName, other.LastName, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return this.FullName;
        }
    }
}