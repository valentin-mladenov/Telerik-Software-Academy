using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Students_And_Workers
{
    class Student : Human
    {
        private int grade;

        public int Grade
        {
            get { return this.grade; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The grade can't be a zero or negetive number.");
                }
                else
                {
                    this.grade = value;
                }
            }
        }

        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.grade = grade;
        }

        //public override string ToString()
        //{
        //    return this.FirstName + " " + this.LastName + ", grade: " + this.Grade + ".";
        //}
    }
}