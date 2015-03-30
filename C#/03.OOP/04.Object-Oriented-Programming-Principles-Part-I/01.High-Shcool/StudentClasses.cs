using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.High_Shcool
{
    public class StudentClasses : IComentable
    {
        private List<Student> students;
        private List<Teacher> teachers;
        private string identifier;
        private List<string> comment;

        public string Identifier
        {
            get { return this.identifier; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The identifier must have at least several characters.");
                }
                else
                {
                    this.identifier = value;
                }
            }
        }

        public void StudentClass(List<Student> students, List<Teacher> teachers, string identifier)
        {
            this.students = students;
            this.teachers = teachers;
            this.identifier = identifier;
            this.comment = new List<string>();
        }

        public void AddStudent(Student stud)
        {
            this.students.Add(stud);
        }

        public void RemoveStudent(Student stud)
        {
            this.students.Remove(stud);
        }

        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            this.teachers.Remove(teacher);
        }

        public string[] Comment { get { return this.comment.ToArray(); } }

        public void AddComment(string comment)
        {
            this.comment.Add(comment);
        }
    }
}
