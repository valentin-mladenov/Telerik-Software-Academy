using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_15.Students_Class
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private string facultNumber;
        private string telephone;
        private string email;
        private List<int> marks;
        private int groupNumber;
        private Group group;

        public Student(string firstName, string lastName, string facultNumber, string telephone,
                       string email, List<int> marks, int groupNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.facultNumber = facultNumber;
            this.telephone = telephone;
            this.email = email;
            this.marks = marks;
            this.groupNumber = groupNumber;
        }

        public Student(string firstName, string lastName, string facultNumber, string telephone,
                       string email, List<int> marks, int groupNumber, Group group)
        : this(firstName, lastName, facultNumber, telephone, email, marks, groupNumber)
        {
            this.group = group;
        }


        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name can't be null, whithspace or empty.");
                }
                else
                {
                    this.firstName = value;
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
                    throw new ArgumentException("Last name can't be null, whithspace or empty.");
                }
                else
                {
                    this.lastName = value;
                }
            }
        }

        public string FN
        {
            get { return this.facultNumber; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Faculty number can't be null, whitespace or empty!");
                }
                else
                {
                    this.facultNumber = value;
                }
            }
        }

        public string Telephone
        {
            get { return this.telephone; }
            private set
            {
                this.telephone = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("E-mail can't be null, whitespace or empty!");
                }
                else
                {
                    this.email = value;
                }
            }
        }

        public int GroupNumber
        {
            get { return this.groupNumber; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Group number can't be zero or negetive number!");
                }
                else
                {
                    this.groupNumber = value;
                }
            }
        }

        public List<int> Marks
        {
            get { return this.marks; }
        }

        public int MarkCount
        {
            get { return this.marks.Count; }
        }

        public void AddMark(byte mark)
        {
            if (mark <2 || mark >6)
            {
                throw new ArgumentOutOfRangeException("Mark must be between 2 and 6.");
            }
            else
            {
                this.marks.Add(mark);
            }
        }

        public void RemoveAtMark(int index)
        {
            if (index<0|| index>this.marks.Count)
            {
                throw new IndexOutOfRangeException("Index must be in the mark collection.");
            }
            else
            {
                this.marks.RemoveAt(index);
            }
        }

        public bool HasMark(byte mark)
        {
            if (mark < 2 || mark > 6)
            {
                throw new ArgumentOutOfRangeException("Mark must be between 2 and 6.");
            }
            else
            {
                return this.marks.Contains(mark);
            }
        }

        public string AllMarks()
        {
            return string.Join(", ", this.marks);
        }

        public Group Group
        {
            get { return this.group; }
            set
            {
                this.group = value;
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            //str.AppendLine(this.GetType().Name);
            str.AppendFormat("Name: {0} {1}", this.firstName, this.lastName);
            str.AppendLine();
            str.AppendLine("FN: " + this.facultNumber);
            str.AppendLine("Telephone: " + this.telephone);
            str.AppendLine("E-mail: " + this.email);
            str.AppendLine("Marks: " + string.Join(", ", this.marks));
            str.AppendLine("Group number: " + this.groupNumber);
            str.AppendLine(Group.ToString());

            return str.ToString();
        }
    }
}
