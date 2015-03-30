using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
	public abstract class Course
	{
		private string name;
		private string teacherName;
		private IList<string> students;

		public string Name 
		{
			get
			{
				return this.name;
			}
			protected set
			{
				if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
				{
					 throw new ArgumentException("Name cannot be null, white space or empty.");
				}
				this.name = value;
			}
		}

		public string TeacherName
		{
			get
			{
				return this.teacherName;
			}
			set
			{
				this.teacherName = value;
			}
		}

		public IList<string> Students
		{
			get
			{
				return this.students;
			}
			set
			{
				if (value != null)
				{
					this.students = new List<string>();

					foreach (string student in value)
					{
						this.students.Add(string.Copy(student));
					}
				}
				else
				{
					this.students = null;
				}
			}
		}

		protected Course(string name, string teacherName, IList<string> students)
		{
			this.Name = name;
			this.TeacherName = teacherName;
			this.Students = students;
		}

		protected string GetStudentsAsString()
		{
			if (this.Students == null || this.Students.Count == 0)
			{
				return "{ No students in this course }";
			}
			else
			{
				return "{ " + string.Join(", ", this.Students) + " }";
			}
		}

		public override string ToString()
		{
			StringBuilder result = new StringBuilder();
			result.Append("LocalCourse { Name = ");
			result.Append(this.Name);
			if (this.TeacherName != null)
			{
				result.Append("; Teacher = ");
				result.Append(this.TeacherName);
			}
			result.Append("; Students = ");
			result.Append(this.GetStudentsAsString());
			return result.ToString();
		}
	}
}
