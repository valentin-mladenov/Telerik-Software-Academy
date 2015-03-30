namespace ATMDataBase.ConsoleApp
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Transactions;

    using ATMDataBase.Data;
    using ATMDataBase.Data.ATMDatabaseData;
    using ATMDataBase.Model;

    public class ATMTransactions
    {
        public void AddAccountCards(ATMDatabaseData db)
        {
            for (int i = 0; i < 50; i++)
            {
                var cardAccount = new CardAccount(
                    (1234567890 + i).ToString(CultureInfo.InvariantCulture),
                    (1234 + i).ToString(CultureInfo.InvariantCulture),
                    1234.76M + (i * 200));
                //Console.WriteLine(i);
                db.CardAccounts.Add(cardAccount);
            }

            db.SaveChanges();
        }

        public bool WithdrawlMoney(ATMDatabaseData db, ATMDataBaseContext context, bool testing)
        {
            using (
                var transaction = new TransactionScope(
                    TransactionScopeOption.RequiresNew,
                    new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead }))
            {
                var withdrawlCard = "1234567892";
                var withdrawlPin = "1236";
                var withdrawlMoney = 100.01M;
                var account = context.CardAccounts.First(acc => acc.CardNumber == withdrawlCard);

                if (account != null && withdrawlPin == account.CardPin && account.CardCash >= withdrawlMoney)
                {
                    account.CardCash -= withdrawlMoney;
                    this.CreateTransactionLog(db, account, withdrawlMoney, testing);
                    db.SaveChanges();
                    if (!testing)
                    {
                        transaction.Complete();
                    }
                    
                    transaction.Dispose();
                    return true;
                }
                else
                {
                    transaction.Dispose();
                    return false;
                }
            }
        }

        private void CreateTransactionLog(ATMDatabaseData db, CardAccount account, decimal withdrawlMoney, bool testing)
        {
            using (
                var history = new TransactionScope(
                    TransactionScopeOption.RequiresNew,
                    new TransactionOptions() { IsolationLevel = IsolationLevel.Snapshot }))
            {
                db.TransactionHistories.Add(new TransactionHistory(account, withdrawlMoney));
                if (!testing)
                {
                    history.Complete();
                }

                history.Dispose();
            }
        }
    }
}
