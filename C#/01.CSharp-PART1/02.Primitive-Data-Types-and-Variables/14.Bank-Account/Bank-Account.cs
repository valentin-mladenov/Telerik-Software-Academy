using System;

class Bank_Account
{
    static void Main()
    {
        string firstName = "Valentin";
        string middleName = "Svetoslavov";
        string lastName = "Mladenov";
        string holderName = firstName + " " + middleName + " " + lastName;
        decimal balance = 1587.78M;
        string bankName = "SG Expressbank";
        string holderIBAN = "BG12SG1987000897565";
        string bankBIC = "BGSG1978";
        ulong creditCard1 = 19870008975651L;
        ulong creditCard2 = 19870008975652L;
        ulong creditCard3 = 19870008975653L;
        Console.WriteLine("Holder Name is: {0} \nBalance: {1} \nBank: {2} \nIBAN: {3} \nBIC: {4} \nCredit cards №: {5}, {6}, {7}", holderName, balance, bankName, holderIBAN, bankBIC, creditCard1, creditCard2, creditCard3);
    }

}
//    Console.WriteLine("Holder Name is: {0}, balance: {1}.", holderName, balance);
//    Console.WriteLine("IBAN: {0}", holderIBAN);
//    Console.WriteLine("Bank: {0}, BIC: {1}", bankName, bankBIC);
//    Console.WriteLine("Credit cards №: \n {0} \n {1} \n {2}",creditCard1, creditCard2, creditCard3);