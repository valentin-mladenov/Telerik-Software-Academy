namespace MyStudentSystem.Model
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;

        public Student()
        {
            this.FacultyNumber = Guid.NewGuid();
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
        }

        public int StudentId { get; set; }

        public string FullName { get; set; }

        public Guid FacultyNumber { get; set; }

        public int CourseID { get; set; }

        public virtual ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }

            set
            {
                this.courses = value;
            }
        }

        public int HomeworkID { get; set; }

        public virtual ICollection<Homework> Homeworks
        {
            get
            {
                return this.homeworks;
            }
            set
            {
                this.homeworks = value;
            }
        }
    }
}