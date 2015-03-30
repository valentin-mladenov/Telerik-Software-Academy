namespace MyStudentSystem.Model
{
    using System.Collections.Generic;

    public class Course
    {
        private ICollection<Student> students;
        private ICollection<Material> materials;
        private ICollection<Homework> homeworks; 

        public Course()
        {
            this.materials = new HashSet<Material>();
            this.homeworks = new HashSet<Homework>();
            this.students = new HashSet<Student>();
        }

        public int CourseID { get; set; }

        public string Name { get; set; }

        public virtual string Description { get; set; }

        public int MaterialID { get; set; }

        public virtual ICollection<Material> Materials
        {
            get
            {
                return this.materials;
            }
            set
            {
                this.materials = value;
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

        public int StudentID { get; set; }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }
    }
}