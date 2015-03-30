using System;
using System.Linq;

//Task 01:
//Define a class Student, which contains data about a student
//– first, middle and last name, SSN, permanent address, mobile
//phone e-mail, course, specialty, university, faculty. Use an 
//enumeration for the specialties, universities and faculties. 
//Override the standard methods, inherited by  System.Object:
//Equals(), ToString(), GetHashCode() and operators == and !=.

//Task 02:
//Add implementations of the ICloneable interface.
//The Clone() method should deeply copy all object's
//fields into a new object of type Student.

//Task 03:
//Implement the  IComparable<Student> interface to compare
//students by names (as first criteria, in lexicographic
//order)and by social security number (as second criteria,
//in increasing order).

namespace _01_03.Students
{
    class StudentsMain
    {
        static void Main()
        {
            Student stud = new Student("rthrd", "wsdfg", "432", "12594564", "dfkjhdkl",
                                        78951236547, "reyhfdgkf", 4, Specialities.Architecture,
                                        Universities.VSU, Faculties.Architecture);

            Console.WriteLine(stud);

            Student s1 = new Student("Pesho", "Ivanov", "Ivanov", "8832738273", "Imaginary Str 44", 3849384398,
                "pesho@test.net", 2, Specialities.Law, Universities.VINS, Faculties.Management);

            Student s2 = new Student("Pesho", "Ivanov", "Ivanov", "7839938273", "Imaginary Str 44", 39483439,
                "pesho@test.net", 3, Specialities.Informatics, Universities.TUV, Faculties.Telecommunications);

            Console.WriteLine("s1 HashCode: " + s1.GetHashCode());
            Console.WriteLine("s2 HashCode: " + s2.GetHashCode());
            Console.WriteLine("stud HashCode: "+ stud.GetHashCode());
            Console.WriteLine("s1 equals s2: " + s1.Equals(s2));
            Console.WriteLine("s1 == s2: " + (s1 == s2));
            Console.WriteLine("s1 != s2: " + (s1 != s2));
            Console.WriteLine();
            Console.WriteLine(s2.ToString());
            Console.WriteLine();
            Console.WriteLine(s1.ToString());
            Console.WriteLine();

            Student s3 = (Student)s2.Clone();

            Console.WriteLine("s2 == s3: " + (s2 == s3));
            Console.WriteLine("s2 != s3: " + (s2 != s3));
            Console.WriteLine("s2.CompareTo(s3): " + s2.CompareTo(s3));
            Console.WriteLine("s1.CompareTo(s2): " + s1.CompareTo(s2));
        }
    }
}
