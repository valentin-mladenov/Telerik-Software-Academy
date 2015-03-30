namespace UnitTesting
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private readonly List<Course> courses;

        private readonly List<Student> students;

        private string schoolName;

        public string Name
        {
            get
            {
                return this.schoolName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name can not be null, empty string or white space.");
                }
                else
                {
                    this.schoolName = value;
                }
            }
        }

        public List<Student> GetStudents
        {
            get
            {
                return this.students;
            }
        }

        public List<Course> GetCourses
        {
            get
            {
                return this.courses;
            }
        }

        public School(string name)
        {
            this.Name = name;
            this.courses = new List<Course>();
            this.students = new List<Student>();
        }

        public void AddCourse(Course course)
        {
            bool isCourseAdded = CourseFinder(course);
            if (isCourseAdded)
            {
                throw new ArgumentException("Course allready added.");
            }
            else
            {
                this.courses.Add(course);
            }
        }

        public void DeleteCourse(Course course)
        {
            bool isCourseAdded = CourseFinder(course);
            if (!isCourseAdded)
            {
                throw new ArgumentException("Not such course to delete.");
            }
            else
            {
                this.courses.Remove(course);
            }
        }

        public void AddStudent(Student student)
        {
            bool isStudentInSchool = StudentFinder(student);
            if (isStudentInSchool == true)
            {
                throw new ArgumentException("Student is in school allready.");
            }
            else
            {
                this.students.Add(student);
            }
        }

        public void DeleteStudent(Student student)
        {
            bool isStudentInSchool = StudentFinder(student);
            if (isStudentInSchool == false)
            {
                throw new ArgumentException("Not such a student to delete.");
            }
            else
            {
                this.students.Remove(student);
            }
        }

        private bool StudentFinder(Student student)
        {
            bool isInScool = false;
            if (this.students.Count == 0)
            {
                return isInScool;
            }
            else
            {
                for (int i = 0; i < this.students.Count; i++)
                {
                    if (this.students[i].Number == student.Number)
                    {
                        isInScool = true;
                        break;
                    }
                }
            }
            return isInScool;
        }

        private bool CourseFinder(Course course)
        {
            bool isInScool = false;
            if (this.courses.Count == 0)
            {
                return isInScool;
            }
            else
            {
                for (int i = 0; i < this.courses.Count; i++)
                {
                    if (this.courses[i].Name == course.Name)
                    {
                        isInScool = true;
                        break;
                    }
                }
            }
            return isInScool;
        }
    }
}