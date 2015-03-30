using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
		private string town;

        public string Town
		{
			get
			{
				return this.town;
			}
			set
			{
				this.town = value;
			}
		}

		public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
			: base(courseName, teacherName, students)
		{
			this.Town = town;
		}

		public OffsiteCourse(string courseName, string teacherName, IList<string> students)
			: this(courseName, teacherName, students, null)
		{
		}

        public OffsiteCourse(string courseName, string teacherName)
			: this(courseName, teacherName,new List<string>(), null)
        {
        }

		public OffsiteCourse(string name)
			: this(name, null, new List<string>(), null)
		{
		}

        public override string ToString()
        {
			StringBuilder result = new StringBuilder();
			result.Append(base.ToString());
            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }
            result.Append(" }");
            return result.ToString();
        }
    }
}
