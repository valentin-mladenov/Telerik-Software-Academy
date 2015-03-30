using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank_System
{
    class LoanAcc : Account, IDepositable
    {
        const byte monthCompanyDiscount = 2;
        const byte monthIndividualDiscount = 3;
        const byte interestModifierCompany = 0;
        const byte interestModifierIndiv = 0;

        public LoanAcc(Customer customer, decimal balance, decimal interest)
            : base(customer, balance, interest)
        {

        }

        public override decimal InterestInMonths(int months)
        {
            if (this.Customer is Company)
            {
                
                if (months > monthCompanyDiscount)
                {
                    return (months - monthCompanyDiscount) * base.Interest;
                }
                else
                {
                    return (base.Interest * interestModifierCompany) * months;
                }
            }
            else
            {
                if (months <= monthIndividualDiscount)
                {
                    return base.Interest * interestModifierIndiv;
                }
                else
                {
                    return base.Interest * (months - monthIndividualDiscount);
                }
            }
        }
    }
}
