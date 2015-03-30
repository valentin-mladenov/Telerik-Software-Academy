namespace UnitTesting
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class Course
	{
		private const int MaxCourseStudents = 30;

		private string courseName;
		private readonly List<Student> students;

		public void AddStudent(Student student)
		{
			bool isInCourse = IsStudentInCourse(student);

			if (students.Count==MaxCourseStudents)
			{
				throw new ArgumentOutOfRangeException("Max cappacity of students reached. Can not add more.");
			}
			else if (isInCourse)
			{
				throw new ArgumentException("This student is added to this course all ready.");
			}
			else
			{
				this.students.Add(student);
			}
		}

		public void RemoveStudent(Student student)
		{
			bool isInCourse = IsStudentInCourse(student);

			if (isInCourse)
			{
				this.students.Remove(student);
			}
			else
			{
				throw new ArgumentException("This student is not signed in this course.");
			}
		}

		public List<Student> GetStudents
		{
			get { return this.students; }
		}

		public string Name
		{
			get { return this.courseName; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException("Name can not be null, empty string or white space.");
				}
				else
				{
					this.courseName = value;
				}
			}
		}

		public Course(string courseName)
		{
			this.Name = courseName;
			this.students = new List<Student>(MaxCourseStudents);
		}

		private bool IsStudentInCourse(Student student)
		{
			bool isInCourse = false;
			for (int i = 0; i < this.students.Count; i++)
			{
				if (this.students[i].Number == student.Number)
				{
					isInCourse = true;
				}
			}

			return isInCourse;
		}
	}
}
