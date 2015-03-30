namespace MyStudentSystem.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Migrations.Model;

    public class Homework
    {
        [Key]
        public int HomworkID { get; set; }

        public string Content { get; set; }

        public DateTime TimeSent { get; set; }

        public int CourseID { get; set; }

        public virtual Course Course { get; set; }

        public int StudentID { get; set; }

        public virtual Student Student { get; set; }
    }
}