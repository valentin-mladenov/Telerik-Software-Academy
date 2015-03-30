using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
		private string lab;

        public string Lab
		{
			get
			{
				return this.lab;
			}
			set
			{
				this.lab = value;
			}
		}

		public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
			: base(courseName,teacherName,students)
		{
			this.Lab = lab;
		}

        public LocalCourse(string name)
			: this(name, null, new List<string>(),null)
        {
        }

        public LocalCourse(string courseName, string teacherName)
			: this(courseName, teacherName, new List<string>(),null)
        {
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
			: this (courseName,teacherName,students,null)
        {
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
			result.Append(base.ToString());
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }
            result.Append(" }");
            return result.ToString();
        }
    }
}
