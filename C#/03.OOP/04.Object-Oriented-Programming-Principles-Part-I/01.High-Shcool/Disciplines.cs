using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.High_Shcool
{
    public class Disciplines : IComentable
    {
        private string name;
        private int lectures;
        private int exercises;
        private List<string> comment;

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The identifier must have at least several characters.");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public int Lectures
        {
            get { return this.lectures; }
            private set { this.lectures = value; }
        }

        public int Exercises
        {
            get { return this.exercises; }
            private set { this.exercises = value; }
        }

        public Disciplines(string name, int lectures, int exercises)
        {
            this.name = name;
            this.lectures = lectures;
            this.exercises = exercises;
            this.comment=new List<string>();
        }

        public string[] Comment { get { return this.comment.ToArray(); } }

        public void AddComment(string comment)
        {
            this.comment.Add(comment);
        }

        public Teacher Teacher
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
