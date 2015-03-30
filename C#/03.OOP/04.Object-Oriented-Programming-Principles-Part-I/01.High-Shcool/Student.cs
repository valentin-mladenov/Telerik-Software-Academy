using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.High_Shcool
{
    public class Student : Person, IComentable
    {
        private int classNumber;
        private List<string> comment;

        public Student(string name, int classNumber)
            : base(name)
        {
            this.classNumber = classNumber;
            this.comment = new List<string>();
        }

        public string[] Comment { get { return this.comment.ToArray(); } }

        public int ClassNumber
        {
            get { return this.classNumber; }
            private set { this.classNumber = value; }
        }
        
        public void AddComment(string comment)
        {
            this.comment.Add(comment);
        }
    }
}
