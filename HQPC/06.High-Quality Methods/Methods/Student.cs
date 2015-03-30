using System;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
		public StudentInforamtion PersonalInfo { get; set; }

		public bool IsOlderThan(Student otherStudent)
		{
			bool isOlder = false;
			DateTime thisDate = this.PersonalInfo.BirthDate;
			DateTime otherDate = otherStudent.PersonalInfo.BirthDate;

			if (thisDate > otherDate)
			{
				isOlder =  true;
			}

			return isOlder;
		}
    }

	public class StudentInforamtion
	{
		public DateTime BirthDate { get; set; }
		public string Town { get; set; }
		public string Hobbies { get; set; }

		public StudentInforamtion(DateTime birthDate, string town = null, string hobbies = null)
		{
			this.BirthDate = birthDate;
			this.Town = town;
			this.Hobbies = hobbies;
		}
	}
}
