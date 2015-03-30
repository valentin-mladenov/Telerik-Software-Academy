using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank_System
{
    abstract class Account : IDepositable
    {
        private Customer customer;
        private decimal balance;
        private decimal interest;

        public Customer Customer
        {
            get { return this.customer; }
            set { this.customer = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public decimal Interest
        {
            get { return this.interest; }
            set { this.interest = value; }
        }

        public virtual decimal InterestInMonths(int months)
        {
            return months * this.interest;
        }

        public Account(Customer customer, decimal balance, decimal interest)
        {
            this.customer = customer;
            this.balance = balance;
            this.interest = interest;
        }

        public void DepositMoney(decimal money)
        {
            this.balance += money;
        }
    }
}
