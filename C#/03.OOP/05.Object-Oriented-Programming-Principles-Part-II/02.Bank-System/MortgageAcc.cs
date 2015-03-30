using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank_System
{
    class MortgageAcc : Account, IDepositable
    {
        const byte monthCompanyDiscount = 12;
        const byte monthIndividualDiscount = 6;
        const decimal interestModifierCompany = (decimal)0.5;
        const byte interestModifierIndiv = 0;

        public MortgageAcc(Customer customer, decimal balance, decimal interest)
            : base(customer, balance, interest)
        {

        }

        public override decimal InterestInMonths(int months)
        {
            if (this.Customer is Company)
            {
                decimal first12 = (base.Interest * interestModifierCompany) * monthCompanyDiscount;
                if (months >= monthCompanyDiscount)
                {
                    return (months - monthCompanyDiscount) * base.Interest + first12;
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
