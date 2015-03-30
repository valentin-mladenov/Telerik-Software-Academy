using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.High_Shcool
{
    public class Teacher : Person, IComentable
    {
        private List<Disciplines> disciplines;
        private List<string> comment;

        public Teacher(string name, List<Disciplines> disciplines)
            : base(name)
        {
            this.disciplines = disciplines;
            this.comment = new List<string>();
        }

        public void AddDiscipline(Disciplines disc)
        {
            this.disciplines.Add(disc);
        }

        public void RemoveDiscipline(Disciplines disc)
        {
            this.disciplines.Remove(disc);
        }

        public string[] Comment { get { return this.comment.ToArray(); } }

        public void AddComment(string comment)
        {
            this.comment.Add(comment);
        }
    }
}