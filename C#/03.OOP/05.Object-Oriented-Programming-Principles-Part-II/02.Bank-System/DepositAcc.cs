using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank_System
{
    class DepositAcc : Account, IDepositable, IWithdraw
    {
        const short interestModifier = 1000;
        const byte lessThanModifier = 0;

        public DepositAcc(Customer customer, decimal balance, decimal interest)
            : base(customer, balance, interest)
        {

        }

        public void WithdrawMoney(decimal withdraw)
        {
            if (base.Balance < withdraw)
            {
                throw new ArgumentException("You can't withdraw more than you have!?");
            }
            else
            {
                base.Balance -= withdraw;
            }
        }

        public override decimal InterestInMonths(int months)
        {
            if (base.Balance >= interestModifier)
            {
                return months * base.Interest;
            }
            else
            {
                return (base.Interest * lessThanModifier) * months;
            }
        }
    }
}
