using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Students_And_Workers
{
    class Worker : Human
    {
        public const int WorkDaysInWeek = 5;
        public double WeekSalary { get; private set; }
        public double WorkHoursPerDay { get; private set; }

        public Worker(string firstName, string lastName, double WeekSalary, double WorkHoursPerDay)
            : base(firstName, lastName)
        {
            this.WorkHoursPerDay = WorkHoursPerDay;
            this.WeekSalary = WeekSalary;
        }

        public double MoneyPerHour() 
        {
            return WeekSalary / (WorkHoursPerDay * WorkDaysInWeek);
        }
    }
}