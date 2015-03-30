using System;
using System.Linq;
using System.Text;

namespace _01_03.Students
{
    public enum Universities
    {
        VINS, TUV, VSU
    }
    public enum Specialities
    {
        Telecommunications, Marketing, Business, Architecture, Phisics, Mathematics, Informatics, Law, Philosophy
    }
    public enum Faculties
    {
        Philosophy, Law, Mathematics, Phisics, Business, Management, Telecommunications, Architecture
    }

    class Student : ICloneable, IComparable<Student>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string ssNumber;
        private string address;
        private long mobilePhone;
        private string eMail;
        private int course;
        private Specialities speciality;
        private Universities university;
        private Faculties faculty;

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The first name must have at least several characters.");
                }
                else
                {
                    this.firstName = value;
                }
            }
        }

        public string MiddleName
        {
            get { return this.middleName; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The middle name must have at least several characters.");
                }
                else
                {
                    this.middleName = value;
                }
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The last name must have at least several characters.");
                }
                else
                {
                    this.lastName = value;
                }
            }
        }

        public string SSN
        {
            get { return this.ssNumber; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("SSN must have at least several characters.");
                }
                else
                {
                    long.Parse(value); // Exeption trowing
                    this.ssNumber = value;
                }
            }
        }

        public string Address
        {
            get { return this.address; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The student adress must have at least several characters.");
                }
                else
                {
                    this.address = value;
                }
            }
        }

        public long MobilePhone
        {
            get { return this.mobilePhone; }
            private set { this.mobilePhone = value; }
        }

        public string EMail
        {
            get { return this.eMail; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The E-Mail must have at least several characters.");
                }
                else
                {
                    this.eMail = value;
                }
            }
        }

        public int Course
        {
            get { return this.course; }
            private set { this.course = value; }
        }

        public Specialities Speciality
        {
            get { return this.speciality; }
            private set { this.speciality = value; }
        }

        public Universities University
        {
            get { return this.university; }
            private set { this.university = value; }
        }

        public Faculties Faculty
        {
            get { return this.faculty; }
            private set { this.faculty = value; }
        }

        public Student(string firstName, string middleName, string lastName, string ssn, string address,
            long mobilePhone, string eMail, int course, Specialities speciality, Universities university, Faculties faculty)
        {
            this.address = address;
            this.course = course;
            this.eMail = eMail;
            this.faculty = faculty;
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = middleName;
            this.mobilePhone = mobilePhone;
            this.speciality = speciality;
            this.ssNumber = ssn;
            this.university = university;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            
            str.AppendLine("Student full name: " + this.firstName + " " + this.middleName + " " + this.lastName);
            str.AppendLine("Address: " + this.address);
            str.AppendLine("Mobile phone number: " + this.mobilePhone);
            str.AppendLine("E-mail: " + this.eMail + ", SSN: " + this.ssNumber);
            str.AppendLine("University: " + this.university);
            str.AppendLine("Faculty: " + this.faculty);
            str.AppendLine("Speciality: " + this.speciality);
            return str.ToString();
        }

        public override bool Equals(object obj)
        {
            Student stud = obj as Student;

            if (stud == null)
            {
                return false;
            }
            else if (!Object.Equals(this.FirstName, stud.FirstName))
            {
                return false;
            }
            else if (!Object.Equals(this.LastName, stud.LastName))
            {
                return false;
            }
            else if (!Object.Equals(this.SSN, stud.SSN))
            {
                return false;
            }
            else if (!Object.Equals(this.Address, stud.Address))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool operator ==(Student stud1, Student stud2)
        {
            return Student.Equals(stud1, stud2);
        }

        public static bool operator !=(Student stud1, Student stud2)
        {
            return !(Student.Equals(stud1, stud2));
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ MobilePhone.GetHashCode();
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Student Clone()
        {
            Student clone = new Student
                                    (
                                    this.FirstName,
                                    this.MiddleName, 
                                    this.LastName, 
                                    this.SSN, 
                                    this.Address, 
                                    this.MobilePhone,
                                    this.EMail,
                                    this.Course, 
                                    this.Speciality, 
                                    this.University,
                                    this.Faculty
                                    );
            return clone;
        }

        public int CompareTo(Student stud)
        {
            string first = this.firstName + " " + this.middleName + " " + this.lastName;
            string second = stud.firstName + " " + stud.middleName + " " + stud.lastName;

            if (first != second)
            {
                return String.Compare(first, second);
            }
            else if (this.SSN != stud.SSN)
            {
                return String.Compare(this.SSN, stud.SSN);
            }
            else
            {
                return 0;
            }
        }
    }
}
