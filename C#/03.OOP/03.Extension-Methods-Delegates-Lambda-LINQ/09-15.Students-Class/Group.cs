using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Task 16: * Create a class Group with properties GroupNumber and DepartmentName.
// Introduce a property Group in the Student class. Extract all students from "Mathematics" department. Use the Join operator.

namespace _09_15.Students_Class
{
    public class Group
    {
        private int groupNumber;
        private string departamentName;

        public Group(int groupNumber, string departamentName)
        {
            this.groupNumber = groupNumber;
            this.departamentName = departamentName;
        }

        public int GroupNumber
        {
            get { return this.groupNumber; }
            private set
            {
                this.groupNumber = value;
            }
        }

        public string DepartamentName
        {
            get { return this.departamentName; }
            set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Departament name can't be null, whithspace or empty.");
                }
                else
                {
                    this.departamentName = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Departament: " + this.departamentName + " with group number: " + this.groupNumber);

            return str.ToString();
        }
    }
}
