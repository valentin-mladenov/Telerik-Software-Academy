namespace _1.Courses_With_Students
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class CoursesWithStudentsApp
    {
        private static char[] separators = { '|', '(', '"', ',', ')', '|' };

        public static void Main()
        {
            Encoding encoding = Encoding.GetEncoding(1251);
            string textfile = @"..\..\students.txt";
            var streamReader = new StreamReader(textfile, encoding);
            var sortedCourses = new SortedDictionary<string, ICollection<Student>>();

            using (streamReader)
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    var lineSplit = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    var firstName = lineSplit[0].Trim();
                    var lastName = lineSplit[1].Trim();
                    var course = lineSplit[2];

                    var student = new Student(firstName, lastName);

                    if (sortedCourses.ContainsKey(course))
                    {
                        sortedCourses[course].Add(student);
                    }
                    else
                    {
                        var students = new SortedSet<Student> { student };
                        sortedCourses.Add(course, students);
                    }

                    line = streamReader.ReadLine();
                }
            }

            foreach (var sortedCourse in sortedCourses)
            {
                var result = new StringBuilder();
                result.Append(sortedCourse.Key + ": ");
                result.Append(string.Join(", ", sortedCourse.Value));
                Console.WriteLine(result.ToString());
            }
        }
    }
}
